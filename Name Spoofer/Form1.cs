using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; // For MemoryStream
using KingSpoofer.Properties; // For Resources
using Newtonsoft.Json;
using Microsoft.Win32; // For Registry access
using System.Diagnostics; // For Process.Start

namespace KingSpoofer
{
    public partial class Form1 : Form
    {
        // Fields for dragging
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private Panel titleBarPanel;
        private const string AppName = "KingSpoofer"; // Used for registry key
        // titleLabel and spooferLabel are declared in Designer.cs, do not redeclare here.

        private List<string> savedNames = new List<string>();

        public Form1()
        {
            InitializeComponent();
            // Make sure KingMod.ico is added to project resources as 'KingMod'
            using (var ms = new MemoryStream(Resources.KingMod))
            {
                this.Icon = new Icon(ms);
            }
            xkingTimer.Start();
            LoadHistory();
            lstSavedNames.DataSource = savedNames;
            // Register FormClosing event
            this.FormClosing += Form1_FormClosing;
            this.Text = "KingSpoofer"; // Set window title

            btnStop.Enabled = false; // Start with Stop button disabled
            toolTip1.SetToolTip(btnStart, "Click to start the spoofer.");
            toolTip1.SetToolTip(btnStop, "Spoofer is stopped.");

            // Load startup setting and hook event for chkRunOnStartup
            // IMPORTANT: chkRunOnStartup control MUST be added to the form in the Designer
            LoadStartupSetting(); 
            Control[] foundControls = this.Controls.Find("chkRunOnStartup", true);
            if (foundControls.Length > 0 && foundControls[0] is CheckBox chkStartup)
            {
                chkStartup.CheckedChanged += chkRunOnStartup_CheckedChanged;
            }
            else
            {
                // Optional: Log or inform user that chkRunOnStartup is missing if it's critical
                // For now, we assume it will be added by the user in the designer.
            }
        }

        private bool xkingRed = false;
        private void xkingTimer_Tick(object sender, EventArgs e)
        {
            if (xkingRed)
            {
                lblXKing.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                lblXKing.ForeColor = System.Drawing.Color.Red;
            }
            xkingRed = !xkingRed;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string accountId = txtAccountId.Text.Trim();
            if (string.IsNullOrEmpty(accountId))
            {
                MessageBox.Show("Please enter your Epic Account ID.", "NameSpoofer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop further execution if no Account ID
            }

            // Assign the Account ID to the Fiddler part
            EpicIdSniffer.Fiddlers.EpicId = accountId;

            MessageBox.Show("Please launch the game, and once you're in the menu, press Stop.", "NameSpoofer", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            if (!btnStart.Enabled) // If Start button is already disabled (meaning spoofer is running)
            {
                MessageBox.Show("Spoofer is already running. Please click Stop first if you want to restart.", "Already Running", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EpicIdSniffer.Fiddlers.Start();

            btnStart.Enabled = false;
            btnStop.Enabled = true;
            toolTip1.SetToolTip(btnStart, "Spoofer is running. Click Stop first.");
            toolTip1.SetToolTip(btnStop, "Click to stop the spoofer.");

            // Write to DynamicResponse.json
            var responseObj = new[]
            {
                new
                {
                    accountId = accountId, // Use the trimmed and validated accountId
                    displayName = txtNewName.Text.Trim(),
                    preferredLanguage = "en",
                    linkedAccounts = new string[] {},
                    cabinedMode = false
                }
            };
            try
            {
                var json = JsonConvert.SerializeObject(responseObj, Formatting.Indented);
                File.WriteAllText("DynamicResponse.json", json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to write DynamicResponse.json: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Optionally, stop Fiddler if writing the response fails
                // EpicIdSniffer.Fiddlers.Stop();
                return;
            }

            var newName = txtNewName.Text.Trim();
            if (!string.IsNullOrEmpty(newName) && !savedNames.Contains(newName))
            {
                savedNames.Add(newName);
                lstSavedNames.DataSource = null;
                lstSavedNames.DataSource = savedNames;
            }
        }

        private void lstSavedNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSavedNames.SelectedItem != null)
            {
                txtNewName.Text = lstSavedNames.SelectedItem.ToString();
            }
        }

        private void btnDeleteName_Click(object sender, EventArgs e)
        {
            if (lstSavedNames.SelectedItem != null)
            {
                savedNames.Remove(lstSavedNames.SelectedItem.ToString());
                lstSavedNames.DataSource = null;
                lstSavedNames.DataSource = savedNames;
            }
        }
        private void btnStop_Click(object sender, EventArgs e) 
        {
            EpicIdSniffer.Fiddlers.Stop();
            MessageBox.Show("Thanks for using our namespoofer, have fun!", "NameSpoofer", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            btnStart.Enabled = true;
            btnStop.Enabled = false;
            toolTip1.SetToolTip(btnStart, "Click to start the spoofer.");
            toolTip1.SetToolTip(btnStop, "Spoofer is stopped.");
        }
        private void btnClose_Click(object sender, EventArgs e) { Application.Exit(); }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.ForeColor = System.Drawing.Color.Red;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.ForeColor = System.Drawing.Color.White;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            // Optionally, you can call LoadHistory() here if needed
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void titleBarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
                titleBarPanel.MouseMove += titleBarPanel_MouseMove;
                titleBarPanel.MouseUp += titleBarPanel_MouseUp;
            }
        }

        private void titleBarPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void titleBarPanel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
            titleBarPanel.MouseMove -= titleBarPanel_MouseMove;
            titleBarPanel.MouseUp -= titleBarPanel_MouseUp;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveHistory();
        }

        private void SaveHistory()
        {
            try
            {
                var data = new PersistentData
                {
                    SavedNames = savedNames,
                    AccountId = txtAccountId.Text,
                    NewName = txtNewName.Text
                };
                File.WriteAllText("saved_names.json", JsonConvert.SerializeObject(data, Formatting.Indented));
            }
            catch { }
        }

        private void LoadHistory()
        {
            try
            {
                if (File.Exists("saved_names.json"))
                {
                    var json = File.ReadAllText("saved_names.json");
                    var data = JsonConvert.DeserializeObject<PersistentData>(json);
                    if (data != null)
                    {
                        savedNames = data.SavedNames ?? new List<string>();
                        lstSavedNames.DataSource = null;
                        lstSavedNames.DataSource = savedNames;
                        txtAccountId.Text = data.AccountId ?? string.Empty;
                        txtNewName.Text = data.NewName ?? string.Empty;
                    }
                }
            }
            catch { }
        }

        private class PersistentData
        {
            public List<string> SavedNames { get; set; }
            public string AccountId { get; set; }
            public string NewName { get; set; }
        }

        private void btnDiscord_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://discord.gg/XEpNz5XFtx");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not open the link: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Startup Functionality (Ensure chkRunOnStartup is added in Designer) ---
        private void LoadStartupSetting()
        {
            Control[] foundControls = this.Controls.Find("chkRunOnStartup", true);
            if (foundControls.Length > 0 && foundControls[0] is CheckBox chkStartup)
            {
                try
                {
                    using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", false))
                    {
                        if (rk != null)
                        {
                            chkStartup.Checked = (rk.GetValue(AppName) != null);
                        }
                        else
                        {
                            chkStartup.Checked = false; 
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading startup setting: " + ex.Message, "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void chkRunOnStartup_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender is CheckBox chkStartup)) return;

            try
            {
                using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true) 
                                        ?? Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run"))
                {
                    if (rk == null) 
                    {
                        MessageBox.Show("Failed to open or create registry key for startup.", "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        chkStartup.Checked = !chkStartup.Checked; 
                        return;
                    }

                    if (chkStartup.Checked)
                    {
                        rk.SetValue(AppName, Application.ExecutablePath);
                    }
                    else
                    {
                        rk.DeleteValue(AppName, false); 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving startup setting: " + ex.Message, "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                chkStartup.Checked = !chkStartup.Checked; 
            }
        }
    }
}
