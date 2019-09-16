using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Advanced_Combat_Tracker;
using DiscordAPI;
using System.Reflection;
using System.IO;
using System.Xml;
using Discord.WebSocket;
using GoogleAPI;

namespace ACT_JuscoBot {
	public partial class JuscoBotPlugin : UserControl, IActPluginV1 {
		Label labelStatus;

		public JuscoBotPlugin() {
			AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
			InitializeComponent();
		}

		public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText) {
			pluginScreenSpace.Controls.Add(this);
			pluginScreenSpace.Text = "JuscoBot";
			Dock = DockStyle.Fill;

			Init();

			DiscordClient.BotReady += BotReady;

			labelStatus = pluginStatusText;
			labelStatus.Text = "Plugin Started";
		}

		public async void DeInitPlugin() {
			SaveDiscordSettings();
			try {
				await DiscordClient.deInIt();
				DiscordClient.BotReady -= BotReady;

				DeInit();

				ActGlobals.oFormActMain.OnCombatEnd -= OFormActMain_OnCombatEnd;
			} catch (Exception ex) {
				ActGlobals.oFormActMain.WriteExceptionLog(ex, "Error with DeInit of JuscoBot Plugin.");
			}
			labelStatus.Text = "Plugin Exited";
		}

		public async void Init() {
			// DebugUIからだと InitPlugin() が呼ばれないためDebugUI起動時にも初期化したい処理をここに記述
			DiscordClient.Log += Log;
			GoogleDriveAPI.Log += Log;

			xmlDiscordSetting = new SettingsSerializer(this);
			LoadDiscordTabSettings();

			xmlBackupSetting = new SettingsSerializer(this);
			LoadBackupTabSettings();
			if (!string.IsNullOrEmpty(backupSetting.authFilePath)) await GoogleDriveAuth();
		}

		public void DeInit() {
			// DebugUIからだと DeInitPlugin() が呼ばれないためDebugUI終了時にも初期化したい処理をここに記述
			DiscordClient.Log -= Log;
			GoogleDriveAPI.Log -= Log;

			//SaveDiscordSettings();
			//SaveBackupSettings();
		}

		private void Log(string message, bool repeat = false) {
			string[] rows = new string[] { DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), message };
			if (!repeat) {
				logList.Items.Add(new ListViewItem(rows));
			} else {
				logList.Items[logList.Items.Count - 1] = new ListViewItem(rows);
			}
		}

		private void OFormActMain_OnCombatEnd(bool isImport, CombatToggleEventArgs encounterInfo) {
			SendEncDPSLog();
		}

		private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args) {
			try {
				var asm = new AssemblyName(args.Name);
				var plugin = ActGlobals.oFormActMain.PluginGetSelfData(this);
				string file;
				if (plugin != null) {
					file = plugin.pluginFile.DirectoryName;
					file = Path.Combine(file, asm.Name + ".dll");
					if (File.Exists(file)) {
						return Assembly.LoadFile(file);
					}
				}
				file = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "plugins\\JuscoBot");
				file = Path.Combine(file, asm.Name + ".dll");
				if (File.Exists(file)) {
					return Assembly.LoadFrom(file);
				}
			} catch (Exception ex) {
				ActGlobals.oFormActMain.WriteExceptionLog(ex, "Error with loading an assembly for JuscoBt Plugin.");
			}
			return null;
		}

		private async void button1_Click(object sender, EventArgs e) {
			if (!IsAuthd) await GoogleDriveAuth();
		}
	}
}
