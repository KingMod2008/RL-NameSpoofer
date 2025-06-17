
namespace KingSpoofer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblAccountId;
        private System.Windows.Forms.TextBox txtAccountId;
        private System.Windows.Forms.Label lblNewName;
        private System.Windows.Forms.TextBox txtNewName;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label spooferLabel;
        private System.Windows.Forms.Label lblDeveloper;
        private System.Windows.Forms.Label lblXKing;
        private System.Windows.Forms.Timer xkingTimer;
        private System.Windows.Forms.ListBox lstSavedNames;
        private System.Windows.Forms.Button btnDeleteName;
        private System.Windows.Forms.Button btnDiscord;
        private System.Windows.Forms.CheckBox chkRunOnStartup;
        private System.Windows.Forms.ToolTip toolTip1;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblAccountId = new System.Windows.Forms.Label();
            this.txtAccountId = new System.Windows.Forms.TextBox();
            this.lblNewName = new System.Windows.Forms.Label();
            this.txtNewName = new System.Windows.Forms.TextBox();
            this.lblDeveloper = new System.Windows.Forms.Label();
            this.lblXKing = new System.Windows.Forms.Label();
            this.xkingTimer = new System.Windows.Forms.Timer(this.components);
            this.titleLabel = new System.Windows.Forms.Label();
            this.spooferLabel = new System.Windows.Forms.Label();
            this.lstSavedNames = new System.Windows.Forms.ListBox();
            this.btnDeleteName = new System.Windows.Forms.Button();
            this.btnDiscord = new System.Windows.Forms.Button();
            this.chkRunOnStartup = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(83)))));
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(180, 175);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 40);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(320, 175);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(100, 40);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(620, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(24, 24);
            this.btnClose.TabIndex = 999;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseEnter += new System.EventHandler(this.btnClose_MouseEnter);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            // 
            // lblAccountId
            // 
            this.lblAccountId.AutoSize = true;
            this.lblAccountId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAccountId.ForeColor = System.Drawing.Color.White;
            this.lblAccountId.Location = new System.Drawing.Point(180, 55);
            this.lblAccountId.Name = "lblAccountId";
            this.lblAccountId.Size = new System.Drawing.Size(85, 19);
            this.lblAccountId.TabIndex = 104;
            this.lblAccountId.Text = "Account ID:";
            // 
            // txtAccountId
            // 
            this.txtAccountId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtAccountId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountId.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAccountId.ForeColor = System.Drawing.Color.White;
            this.txtAccountId.Location = new System.Drawing.Point(180, 80);
            this.txtAccountId.Name = "txtAccountId";
            this.txtAccountId.Size = new System.Drawing.Size(240, 25);
            this.txtAccountId.TabIndex = 0;
            // 
            // lblNewName
            // 
            this.lblNewName.AutoSize = true;
            this.lblNewName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNewName.ForeColor = System.Drawing.Color.White;
            this.lblNewName.Location = new System.Drawing.Point(180, 115);
            this.lblNewName.Name = "lblNewName";
            this.lblNewName.Size = new System.Drawing.Size(87, 19);
            this.lblNewName.TabIndex = 105;
            this.lblNewName.Text = "New Name:";
            // 
            // txtNewName
            // 
            this.txtNewName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtNewName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNewName.ForeColor = System.Drawing.Color.White;
            this.txtNewName.Location = new System.Drawing.Point(180, 140);
            this.txtNewName.Name = "txtNewName";
            this.txtNewName.Size = new System.Drawing.Size(240, 25);
            this.txtNewName.TabIndex = 1;
            // 
            // lblDeveloper
            // 
            this.lblDeveloper.AutoSize = true;
            this.lblDeveloper.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDeveloper.ForeColor = System.Drawing.Color.Gray;
            this.lblDeveloper.Location = new System.Drawing.Point(180, 220);
            this.lblDeveloper.Name = "lblDeveloper";
            this.lblDeveloper.Size = new System.Drawing.Size(68, 13);
            this.lblDeveloper.TabIndex = 106;
            this.lblDeveloper.Text = "Developer : ";
            // 
            // lblXKing
            // 
            this.lblXKing.AutoSize = true;
            this.lblXKing.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblXKing.ForeColor = System.Drawing.Color.Red;
            this.lblXKing.Location = new System.Drawing.Point(260, 216);
            this.lblXKing.Name = "lblXKing";
            this.lblXKing.Size = new System.Drawing.Size(55, 21);
            this.lblXKing.TabIndex = 107;
            this.lblXKing.Text = "XKing";
            // 
            // xkingTimer
            // 
            this.xkingTimer.Interval = 500;
            this.xkingTimer.Tick += new System.EventHandler(this.xkingTimer_Tick);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(180, 10);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(83, 41);
            this.titleLabel.TabIndex = 102;
            this.titleLabel.Text = "King";
            // 
            // spooferLabel
            // 
            this.spooferLabel.AutoSize = true;
            this.spooferLabel.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.spooferLabel.ForeColor = System.Drawing.Color.Red;
            this.spooferLabel.Location = new System.Drawing.Point(320, 10);
            this.spooferLabel.Name = "spooferLabel";
            this.spooferLabel.Size = new System.Drawing.Size(130, 41);
            this.spooferLabel.TabIndex = 103;
            this.spooferLabel.Text = "Spoofer";
            // 
            // lstSavedNames
            // 
            this.lstSavedNames.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lstSavedNames.ItemHeight = 17;
            this.lstSavedNames.Location = new System.Drawing.Point(10, 7);
            this.lstSavedNames.Name = "lstSavedNames";
            this.lstSavedNames.Size = new System.Drawing.Size(150, 208);
            this.lstSavedNames.TabIndex = 100;
            this.lstSavedNames.SelectedIndexChanged += new System.EventHandler(this.lstSavedNames_SelectedIndexChanged);
            // 
            // btnDeleteName
            // 
            this.btnDeleteName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.btnDeleteName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeleteName.ForeColor = System.Drawing.Color.White;
            this.btnDeleteName.Location = new System.Drawing.Point(10, 225);
            this.btnDeleteName.Name = "btnDeleteName";
            this.btnDeleteName.Size = new System.Drawing.Size(150, 30);
            this.btnDeleteName.TabIndex = 101;
            this.btnDeleteName.Text = "Delete Selected";
            this.btnDeleteName.UseVisualStyleBackColor = false;
            this.btnDeleteName.Click += new System.EventHandler(this.btnDeleteName_Click);
            // 
            // btnDiscord
            // 
            this.btnDiscord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnDiscord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiscord.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDiscord.ForeColor = System.Drawing.Color.White;
            this.btnDiscord.Location = new System.Drawing.Point(450, 175); // You can adjust this location
            this.btnDiscord.Name = "btnDiscord";
            this.btnDiscord.Size = new System.Drawing.Size(100, 40);
            this.btnDiscord.TabIndex = 5; // Ensure TabIndex is unique and logical
            this.btnDiscord.Text = "Join Discord";
            this.btnDiscord.UseVisualStyleBackColor = false;
            this.btnDiscord.Click += new System.EventHandler(this.btnDiscord_Click);
            // 
            // chkRunOnStartup
            // 
            this.chkRunOnStartup.AutoSize = true;
            this.chkRunOnStartup.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkRunOnStartup.ForeColor = System.Drawing.Color.White;
            this.chkRunOnStartup.Location = new System.Drawing.Point(450, 225); // You can adjust this location
            this.chkRunOnStartup.Name = "chkRunOnStartup";
            this.chkRunOnStartup.Size = new System.Drawing.Size(156, 19);
            this.chkRunOnStartup.TabIndex = 4; // Ensure TabIndex is unique and logical
            this.chkRunOnStartup.Text = "Run on Windows startup";
            this.chkRunOnStartup.UseVisualStyleBackColor = true;
            this.chkRunOnStartup.CheckedChanged += new System.EventHandler(this.chkRunOnStartup_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(650, 270);
            this.Controls.Add(this.lstSavedNames);
            this.Controls.Add(this.btnDeleteName);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.spooferLabel);
            this.Controls.Add(this.lblAccountId);
            this.Controls.Add(this.txtAccountId);
            this.Controls.Add(this.lblNewName);
            this.Controls.Add(this.txtNewName);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblDeveloper);
            this.Controls.Add(this.lblXKing);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDiscord);
            this.Controls.Add(this.chkRunOnStartup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "King Spoofer - by XKing";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
    }
}

