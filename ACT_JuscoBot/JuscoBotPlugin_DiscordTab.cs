using Advanced_Combat_Tracker;
using Discord.WebSocket;
using DiscordAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ACT_JuscoBot {
	partial class JuscoBotPlugin {
		bool EnableDiscord = false;

		SettingsSerializer xmlDiscordSetting;

		private void BotReady() {
			btnJoin.Enabled = true;
			populateServerAndChannels();
		}

		private void BtnConnect_Click(object sender, EventArgs e) {
			if (DiscordClient.IsConnected()) {
				Log("すでに接続済");
				return;
			}
			DiscordClient.Init("NjE5NjA5MDQ5NTMyNTk2MjU0.XXLCvQ.MzQcoJVG1qMQNtTAzux__TYO0zE");

			ActGlobals.oFormActMain.OnCombatEnd += OFormActMain_OnCombatEnd;
		}


		private void populateServerAndChannels() {
			try {
				string[] servers = DiscordClient.getServers();
				Log("Found " + servers.Length + " discord server(s).");

				var serverText = cmbServer.Text;
				bool isChanged = string.IsNullOrEmpty(serverText) || !servers.Contains(serverText);

				cmbServer.Items.Clear();
				cmbServer.Items.AddRange(servers);

				if (cmbServer.Items.Count > 0) {
					if (!isChanged) {
						cmbServer.SelectedIndex = cmbServer.Items.IndexOf(serverText);
					} else {
						cmbServer.SelectedIndex = 0;
					}
					cmbServer.Enabled = true;
					populateChannel(cmbTextChannel, DiscordClient.getTextChannels(cmbServer.Text));
					populateChannel(cmbVoiceChannel, DiscordClient.getVoiceChannels(cmbServer.Text));
				}
			} catch (Exception ex) {
				Log("Error populating servers.");
				Log(ex.Message);
			}
		}

		private void populateChannel(ComboBox cmb, SocketGuildChannel[] channels) {
			try {
				var name = cmb.Text;
				cmb.Items.Clear();
				cmb.Items.AddRange(channels);
				if (cmb.Items.Count > 0) {
					var index = 0;
					foreach (var item in cmb.Items) {
						if (item.ToString() == name) break;
						index++;
					}
					if (index >= cmb.Items.Count) index = 0;
					cmb.SelectedIndex = index;
					cmb.Enabled = true;
					Log("Found " + cmb.Items.Count + " available channel(s)");
				} else {
					Log("Error: Could not find any available channels");
				}
			} catch (Exception ex) {
				Log("Error populating channels.");
				Log(ex.Message);
			}
		}

		private void populateVoiceChannel(string server) {
			try {
				cmbVoiceChannel.Items.Clear();
				cmbVoiceChannel.Items.AddRange(DiscordClient.getVoiceChannels(server));
				if (cmbVoiceChannel.Items.Count > 0) {
					cmbVoiceChannel.SelectedIndex = 0;
					cmbVoiceChannel.Enabled = true;
					Log("Found " + cmbVoiceChannel.Items.Count + " available voice channel(s) for " + server);
				} else {
					Log("Error: Could not find any available voice channels for " + server);
				}
			} catch (Exception ex) {
				Log("Error populating channels.");
				Log(ex.Message);
			}
		}


		/// <summary>
		/// Discord設定をロード
		/// </summary>
		private void LoadDiscordTabSettings() {
			if (!EnableDiscord) return;

			xmlDiscordSetting.AddControlSetting(textDiscordBotToken.Name, textDiscordBotToken);
			xmlDiscordSetting.AddControlSetting(chkAutoConnect.Name, chkAutoConnect);
			xmlDiscordSetting.AddControlSetting(cmbServer.Name, cmbServer);
			xmlDiscordSetting.AddControlSetting(cmbTextChannel.Name, cmbTextChannel);
			xmlDiscordSetting.AddControlSetting(cmbVoiceChannel.Text, cmbVoiceChannel);

			if (File.Exists(PathHelper.JuscoBotDiscordSettingFile)) {
				using (FileStream fs = new FileStream(PathHelper.JuscoBotDiscordSettingFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
					using (XmlTextReader xReader = new XmlTextReader(fs)) {
						try {
							while (xReader.Read())
								if (xReader.NodeType == XmlNodeType.Element)
									if (xReader.LocalName == "SettingsSerializer")
										xmlDiscordSetting.ImportFromXml(xReader);
						} catch (Exception ex) {
							labelStatus.Text = "Error loading settings: " + ex.Message;
						}
						xReader.Close();
					}
				}
			}
		}

		/// <summary>
		/// Discord設定をセーブ
		/// </summary>
		/// <returns></returns>
		public bool SaveDiscordSettings() {
			if (!EnableDiscord) return true;

			try {
				if (!Directory.Exists(PathHelper.JuscoBotSettingFolderPath)) Directory.CreateDirectory(PathHelper.JuscoBotSettingFolderPath);
				using (FileStream fs = new FileStream(PathHelper.JuscoBotDiscordSettingFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite)) {
					XmlTextWriter xWriter = new XmlTextWriter(fs, Encoding.UTF8);
					xWriter.Formatting = Formatting.Indented;
					xWriter.Indentation = 1;
					xWriter.IndentChar = '\t';
					xWriter.WriteStartDocument(true);
					xWriter.WriteStartElement("Config");
					xWriter.WriteStartElement("SettingsSerializer");

					xmlDiscordSetting.ExportToXml(xWriter);
					xWriter.WriteEndElement();
					xWriter.WriteEndElement();
					xWriter.WriteEndDocument();
					xWriter.Flush();
					xWriter.Close();
				}
			} catch {
				return false;
			}
			return true;
		}

		void SendEncDPSLog() {
			if (!DiscordClient.IsConnected()) return;

			try {
				StringBuilder sb = new StringBuilder();
				var allies = ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.GetAllies();
				var cnv = CombatantData.ExportVariables;
				var sorted = allies.OrderByDescending(x => {
					int intDPS;
					bool isInt = int.TryParse(cnv["ENCDPS"].GetExportString(x, ""), out intDPS);
					if (isInt) { return intDPS; } else { return 0; }
				});
				sb.AppendFormat("{0,-30} {1,5} {2,6}\r\n", "Name", "Job", "DPS");

				foreach (CombatantData ally in sorted) {
					string name = cnv["name"].GetExportString(ally, "");
					string Job = cnv["Job"].GetExportString(ally, "");
					string ENCDPS = cnv["ENCDPS"].GetExportString(ally, "");
					sb.AppendFormat("{0,-30} {1,5} {2,6}", name, Job, ENCDPS);
					sb.AppendLine();
				}
				DiscordClient.SendMessage("general", sb.ToString());
			} catch (Exception e) {
				DiscordClient.SendMessage("general", e.Message);
			}
		}
	}
}
