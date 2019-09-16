using Discord;
using Discord.Audio;
using Discord.WebSocket;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;


namespace DiscordAPI
{
	public static class DiscordClient {
		private static DiscordSocketClient bot;

		private static IAudioClient audioClient;
		private static AudioOutStream voiceStream;

		public delegate void BotLoaded();
		public static BotLoaded BotReady;

		public delegate void BotMessage(string message, bool repeat = false);
		public static BotMessage Log;

		public static async void Init(string token) {
			try {
				bot = new DiscordSocketClient();
			} catch (NotSupportedException ex) {
				Log?.Invoke("Unsupported Operating System.");
				Log?.Invoke(ex.Message);
			}

			try {
				bot.Log += Bot_Log;
				bot.Ready += Bot_Ready;
				await bot.LoginAsync(TokenType.Bot, token);
				await bot.StartAsync();
			} catch (Exception ex) {
				Log?.Invoke(ex.Message);
				Log?.Invoke("Error connecting to Discord.");
			}
		}

		public static async Task deInIt() {
			bot.Ready -= Bot_Ready;
			if (audioClient?.ConnectionState == ConnectionState.Connected) {
				voiceStream?.Close();
				await audioClient.StopAsync();
			}
			await bot.StopAsync();
			await bot.LogoutAsync();
		}

		public static bool IsConnected() {
			return bot?.ConnectionState == ConnectionState.Connected;
		}

		private static Task Bot_Log(LogMessage arg) {
			Log?.Invoke($"[{arg.Source}] {arg.Message}");
			return Task.CompletedTask;
		}

		private static async Task Bot_Ready() {
			await bot.SetGameAsync("(^v^)v");
			Log?.Invoke("Bot in ready state. Populating servers...");
			BotReady?.Invoke();
		}

		/// <summary>
		/// サーバー一覧取得
		/// </summary>
		/// <returns></returns>
		public static string[] getServers() {
			List<string> servers = new List<string>();

			try {
				foreach (SocketGuild g in bot.Guilds)
					servers.Add(g.Name);
			} catch (Exception ex) {
				Log?.Invoke("Error loading servers in DiscordAPI#getServers().");
				Log?.Invoke(ex.Message);
			}

			return servers.ToArray();
		}

		/// <summary>
		/// テキストチャンネル一覧取得
		/// </summary>
		/// <param name="server"></param>
		/// <returns></returns>
		public static SocketTextChannel[] getTextChannels(string server = null) {
			List<SocketTextChannel> discordchannels = new List<SocketTextChannel>();

			foreach (SocketGuild g in bot.Guilds) {
				if (server == null || g.Name == server) {
					var channels = new List<SocketTextChannel>(g.TextChannels);
					channels.Sort((x, y) => x.Position.CompareTo(y.Position));
					foreach (SocketTextChannel channel in channels)
						discordchannels.Add(channel);
					break;
				}
			}

			return discordchannels.ToArray();
		}

		/// <summary>
		/// ボイスチャンネル一覧取得
		/// </summary>
		/// <param name="server"></param>
		/// <returns></returns>
		public static SocketVoiceChannel[] getVoiceChannels(string server) {
			List<SocketVoiceChannel> discordchannels = new List<SocketVoiceChannel>();

			foreach (SocketGuild g in bot.Guilds) {
				if (g.Name == server) {
					var channels = new List<SocketVoiceChannel>(g.VoiceChannels);
					channels.Sort((x, y) => x.Position.CompareTo(y.Position));
					foreach (SocketVoiceChannel channel in channels)
						discordchannels.Add(channel);
					break;
				}
			}

			return discordchannels.ToArray();
		}

		/// <summary>
		/// プレイ中のゲーム名
		/// </summary>
		/// <param name="text"></param>
		public static void SetGameAsync(string text) {
			bot.SetGameAsync(text);
		}

		/// <summary>
		/// ボイスチャンネルに入る
		/// </summary>
		/// <param name="server"></param>
		/// <param name="channel"></param>
		/// <returns></returns>
		public static async Task<bool> JoinChannel(string server, string channel) {
			SocketVoiceChannel chan = null;

			foreach (SocketVoiceChannel vchannel in getVoiceChannels(server))
				if (vchannel.Name == channel)
					chan = vchannel;

			if (chan != null) {
				try {
					audioClient = await chan.ConnectAsync();
					Log?.Invoke("Joined channel: " + chan.Name);
				} catch (Exception ex) {
					Log?.Invoke("Error joining channel.");
					Log?.Invoke(ex.Message);
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// チャンネルから抜ける
		/// </summary>
		public static async void LeaveChannel() {
			voiceStream?.Close();
			voiceStream = null;
			await audioClient.StopAsync();
		}


		private static object speaklock = new object();
		private static SpeechAudioFormatInfo formatInfo = new SpeechAudioFormatInfo(48000, AudioBitsPerSample.Sixteen, AudioChannel.Stereo);

		public static void Speak(string text, string voice, int vol, int speed) {
			lock (speaklock) {
				if (voiceStream == null)
					voiceStream = audioClient.CreatePCMStream(AudioApplication.Voice, 128 * 1024);
				SpeechSynthesizer tts = new SpeechSynthesizer();
				tts.SelectVoice(voice);
				tts.Volume = vol * 5;
				tts.Rate = speed - 10;
				MemoryStream ms = new MemoryStream();
				tts.SetOutputToAudioStream(ms, formatInfo);

				tts.Speak(text);
				ms.Seek(0, SeekOrigin.Begin);
				ms.CopyTo(voiceStream);
				voiceStream.Flush();
			}
		}

		public static void SpeakFile(string path) {
			lock (speaklock) {
				if (voiceStream == null)
					voiceStream = audioClient.CreatePCMStream(AudioApplication.Voice, 128 * 1024);
				try {
					WaveFileReader wav = new WaveFileReader(path);
					WaveFormat waveFormat = new WaveFormat(48000, 16, 2);
					WaveStream pcm = WaveFormatConversionStream.CreatePcmStream(wav);
					WaveFormatConversionStream output = new WaveFormatConversionStream(waveFormat, pcm);
					output.CopyTo(voiceStream);
					voiceStream.Flush();
				} catch (Exception ex) {
					Log?.Invoke("Unable to read file: " + ex.Message);
				}
			}
		}

		public static void SendMessage(string channelName, string message) {
			var channels = getTextChannels();
			var channel = channels.ToList().Find((c) => c.Name == channelName);
			SendMessage(channel, message);
		}

		public static async void SendMessage(ISocketMessageChannel channel, string message) {
			var result = await channel.SendMessageAsync(message);
		}
	}
}
