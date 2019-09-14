namespace ACT_DiscordBot {
	partial class DiscordPlugin {
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

		#region コンポーネント デザイナーで生成されたコード

		/// <summary> 
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent() {
			this.BtnConnect = new System.Windows.Forms.Button();
			this.logList = new System.Windows.Forms.ListView();
			this.listColTim = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.listColMsg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.textToken = new System.Windows.Forms.TextBox();
			this.labelToken = new System.Windows.Forms.Label();
			this.cmbVoiceChannel = new System.Windows.Forms.ComboBox();
			this.lblChan = new System.Windows.Forms.Label();
			this.cmbServer = new System.Windows.Forms.ComboBox();
			this.lblServer = new System.Windows.Forms.Label();
			this.btnLeave = new System.Windows.Forms.Button();
			this.btnJoin = new System.Windows.Forms.Button();
			this.cmbTextChannel = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.chkAutoConnect = new System.Windows.Forms.CheckBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// BtnConnect
			// 
			this.BtnConnect.Location = new System.Drawing.Point(13, 55);
			this.BtnConnect.Name = "BtnConnect";
			this.BtnConnect.Size = new System.Drawing.Size(75, 23);
			this.BtnConnect.TabIndex = 0;
			this.BtnConnect.Text = "Connect";
			this.BtnConnect.UseVisualStyleBackColor = true;
			this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
			// 
			// logList
			// 
			this.logList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.logList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listColTim,
            this.listColMsg});
			this.logList.FullRowSelect = true;
			this.logList.HideSelection = false;
			this.logList.Location = new System.Drawing.Point(13, 264);
			this.logList.Name = "logList";
			this.logList.Size = new System.Drawing.Size(572, 161);
			this.logList.TabIndex = 62;
			this.logList.UseCompatibleStateImageBehavior = false;
			this.logList.View = System.Windows.Forms.View.Details;
			// 
			// listColTim
			// 
			this.listColTim.Text = "Time";
			this.listColTim.Width = 120;
			// 
			// listColMsg
			// 
			this.listColMsg.Text = "Message";
			this.listColMsg.Width = 315;
			// 
			// textToken
			// 
			this.textToken.Location = new System.Drawing.Point(13, 30);
			this.textToken.Name = "textToken";
			this.textToken.Size = new System.Drawing.Size(239, 19);
			this.textToken.TabIndex = 63;
			// 
			// labelToken
			// 
			this.labelToken.AutoSize = true;
			this.labelToken.Location = new System.Drawing.Point(11, 11);
			this.labelToken.Name = "labelToken";
			this.labelToken.Size = new System.Drawing.Size(58, 12);
			this.labelToken.TabIndex = 64;
			this.labelToken.Text = "Bot Token";
			// 
			// cmbVoiceChannel
			// 
			this.cmbVoiceChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbVoiceChannel.Enabled = false;
			this.cmbVoiceChannel.FormattingEnabled = true;
			this.cmbVoiceChannel.Location = new System.Drawing.Point(13, 198);
			this.cmbVoiceChannel.Name = "cmbVoiceChannel";
			this.cmbVoiceChannel.Size = new System.Drawing.Size(239, 20);
			this.cmbVoiceChannel.TabIndex = 70;
			// 
			// lblChan
			// 
			this.lblChan.AutoSize = true;
			this.lblChan.Location = new System.Drawing.Point(10, 181);
			this.lblChan.Name = "lblChan";
			this.lblChan.Size = new System.Drawing.Size(79, 12);
			this.lblChan.TabIndex = 69;
			this.lblChan.Text = "Voice Channel";
			// 
			// cmbServer
			// 
			this.cmbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbServer.Enabled = false;
			this.cmbServer.FormattingEnabled = true;
			this.cmbServer.Location = new System.Drawing.Point(13, 101);
			this.cmbServer.Name = "cmbServer";
			this.cmbServer.Size = new System.Drawing.Size(239, 20);
			this.cmbServer.TabIndex = 68;
			// 
			// lblServer
			// 
			this.lblServer.AutoSize = true;
			this.lblServer.Location = new System.Drawing.Point(10, 88);
			this.lblServer.Name = "lblServer";
			this.lblServer.Size = new System.Drawing.Size(38, 12);
			this.lblServer.TabIndex = 67;
			this.lblServer.Text = "Server";
			// 
			// btnLeave
			// 
			this.btnLeave.Enabled = false;
			this.btnLeave.Location = new System.Drawing.Point(112, 223);
			this.btnLeave.Name = "btnLeave";
			this.btnLeave.Size = new System.Drawing.Size(94, 21);
			this.btnLeave.TabIndex = 66;
			this.btnLeave.Text = "Leave Channel";
			this.btnLeave.UseVisualStyleBackColor = true;
			// 
			// btnJoin
			// 
			this.btnJoin.Enabled = false;
			this.btnJoin.Location = new System.Drawing.Point(13, 222);
			this.btnJoin.Name = "btnJoin";
			this.btnJoin.Size = new System.Drawing.Size(93, 21);
			this.btnJoin.TabIndex = 65;
			this.btnJoin.Text = "Join Channel";
			this.btnJoin.UseVisualStyleBackColor = true;
			// 
			// cmbTextChannel
			// 
			this.cmbTextChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTextChannel.Enabled = false;
			this.cmbTextChannel.FormattingEnabled = true;
			this.cmbTextChannel.Location = new System.Drawing.Point(13, 150);
			this.cmbTextChannel.Name = "cmbTextChannel";
			this.cmbTextChannel.Size = new System.Drawing.Size(239, 20);
			this.cmbTextChannel.TabIndex = 74;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 133);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(73, 12);
			this.label1.TabIndex = 73;
			this.label1.Text = "Text Channel";
			// 
			// chkAutoConnect
			// 
			this.chkAutoConnect.AutoSize = true;
			this.chkAutoConnect.Location = new System.Drawing.Point(94, 59);
			this.chkAutoConnect.Name = "chkAutoConnect";
			this.chkAutoConnect.Size = new System.Drawing.Size(94, 16);
			this.chkAutoConnect.TabIndex = 75;
			this.chkAutoConnect.Text = "Auto Connect";
			this.chkAutoConnect.UseVisualStyleBackColor = true;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(316, 32);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(214, 16);
			this.checkBox1.TabIndex = 76;
			this.checkBox1.Text = "戦闘終了時にDiscordにDPSログを送信";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// DiscordPlugin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.chkAutoConnect);
			this.Controls.Add(this.cmbTextChannel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmbVoiceChannel);
			this.Controls.Add(this.lblChan);
			this.Controls.Add(this.cmbServer);
			this.Controls.Add(this.lblServer);
			this.Controls.Add(this.btnLeave);
			this.Controls.Add(this.btnJoin);
			this.Controls.Add(this.labelToken);
			this.Controls.Add(this.textToken);
			this.Controls.Add(this.logList);
			this.Controls.Add(this.BtnConnect);
			this.Name = "DiscordPlugin";
			this.Size = new System.Drawing.Size(603, 439);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button BtnConnect;
		private System.Windows.Forms.ListView logList;
		private System.Windows.Forms.ColumnHeader listColTim;
		private System.Windows.Forms.ColumnHeader listColMsg;
		private System.Windows.Forms.TextBox textToken;
		private System.Windows.Forms.Label labelToken;
		private System.Windows.Forms.ComboBox cmbVoiceChannel;
		private System.Windows.Forms.Label lblChan;
		private System.Windows.Forms.ComboBox cmbServer;
		private System.Windows.Forms.Label lblServer;
		private System.Windows.Forms.Button btnLeave;
		private System.Windows.Forms.Button btnJoin;
		private System.Windows.Forms.ComboBox cmbTextChannel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox chkAutoConnect;
		private System.Windows.Forms.CheckBox checkBox1;
	}
}
