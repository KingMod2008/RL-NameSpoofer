using System;
using System.IO;
using Fiddler;
using Microsoft.Win32;

namespace EpicIdSniffer
{
	public class Fiddlers
	{
		public static event Action<string> OnEpicIdCaptured;
		static Fiddlers()
		{
			FiddlerApplication.BeforeRequest += Fiddlers.FiddlerToCatchBeforeRequest;
			FiddlerApplication.BeforeResponse += Fiddlers.FiddlerToCatchBeforeResponse;
			FiddlerApplication.AfterSessionComplete += Fiddlers.Fiddler_Bypass_Session;
			FiddlerApplication.ResetSessionCounter();
		}
		private static void EnsureRootCertificate()
		{
			if (!CertMaker.rootCertExists())
			{
				if (!CertMaker.createRootCert())
				{
					System.Windows.Forms.MessageBox.Show("Failed to create the Fiddler root certificate. HTTPS decryption may not work.", "Certificate Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
			}
			if (!CertMaker.rootCertIsTrusted())
			{
				if (!CertMaker.trustRootCert())
				{
					System.Windows.Forms.MessageBox.Show("Failed to trust the Fiddler root certificate. HTTPS decryption may not work, and you might see security warnings.", "Certificate Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
				}
			}
		}
		public static bool RemoveRootCertificate()
		{
			bool result;
			try
			{
				CertMaker.removeFiddlerGeneratedCerts(true);
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}
		public static void DisableProxy()
		{
			try
			{
				RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
				registryKey.SetValue("ProxyEnable", 0);
				registryKey.DeleteValue("ProxyServer", false);
				registryKey.Close();
				RegistryKey registryKey2 = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
				registryKey2.SetValue("ProxyEnable", 0);
				registryKey2.DeleteValue("ProxyServer", false);
				registryKey2.Close();
			}
			catch
			{
			}
		}
		public static void Start()
		{
			Fiddlers.EnsureRootCertificate();
			FiddlerApplication.Startup(new FiddlerCoreStartupSettingsBuilder().ListenOnPort(8866).RegisterAsSystemProxy().ChainToUpstreamGateway().DecryptSSL().OptimizeThreadPool().Build());
		}
		public static void Stop()
		{
			Fiddlers.DisableProxy();
			FiddlerApplication.Shutdown();
		}
		public static void FiddlerToCatchBeforeResponse(Session oSession)
		{
		}
		private static void FiddlerToCatchBeforeRequest(Session oSession)
		{
			// Only process if EpicId is set and the request matches our target URI
			if (!string.IsNullOrEmpty(Fiddlers.EpicId) && 
				oSession.uriContains("/epic/id/v2/sdk/accounts?accountId=" + Fiddlers.EpicId) &&
				(oSession.hostname.EndsWith("epicgames.com", StringComparison.OrdinalIgnoreCase) || oSession.hostname.EndsWith("epicgames.dev", StringComparison.OrdinalIgnoreCase)) // Be specific about host
			   )
			{
				oSession.bBufferResponse = true; // Buffer response only for the target request
				string value = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DynamicResponse.json");
				oSession.oFlags["x-replywithfile"] = value;
				return; // Session handled
			}

			// For other HTTPS CONNECT requests, if they are not to known game-related hosts,
			// explicitly tell Fiddler not to decrypt them. This helps prevent interference.
			if (oSession.HTTPMethodIs("CONNECT"))
			{
				string hostname = oSession.hostname;
				// List of hostnames that Fiddler *should* (or can) decrypt for game functionality or related services.
				// Add more if other specific game-related endpoints need inspection in the future.
				bool allowDecrypt = hostname.EndsWith("epicgames.com", StringComparison.OrdinalIgnoreCase) ||
								  hostname.EndsWith("epicgames.dev", StringComparison.OrdinalIgnoreCase) || // Common for Epic services
								  hostname.EndsWith("rl.epicgames.com", StringComparison.OrdinalIgnoreCase) || // Rocket League specific
								  hostname.EndsWith("psyonix.net", StringComparison.OrdinalIgnoreCase);

				if (!allowDecrypt)
				{
					oSession["x-no-decrypt"] = "true";
				}
			}
			// All other requests (HTTP, or HTTPS that we allow decryption for, or HTTPS we've handled above)
			// will pass through Fiddler. No need to set oSession.bBufferResponse = true for them here.
		}
		public static void Fiddler_Bypass_Session(Session oSession)
		{
		}
		public static string EpicId = null;
		public static string localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
	}
}
