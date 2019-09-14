namespace DebugGUI {
	partial class DebugGUI {
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent() {
			this.discordPlugin1 = new ACT_DiscordBot.DiscordPlugin();
			this.SuspendLayout();
			// 
			// discordPlugin1
			// 
			this.discordPlugin1.Location = new System.Drawing.Point(12, 12);
			this.discordPlugin1.Name = "discordPlugin1";
			this.discordPlugin1.Size = new System.Drawing.Size(776, 426);
			this.discordPlugin1.TabIndex = 0;
			// 
			// DebugGUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.discordPlugin1);
			this.Name = "DebugGUI";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private ACT_DiscordBot.DiscordPlugin discordPlugin1;
	}
}

