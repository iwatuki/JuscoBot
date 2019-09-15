namespace ACT_JuscoBot {
	partial class JuscoBotPlugin {
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
			this.logList = new System.Windows.Forms.ListView();
			this.listColTim = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.listColMsg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabControl = new System.Windows.Forms.TabControl();
			this.TabPageDiscord = new System.Windows.Forms.TabPage();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.chkAutoConnect = new System.Windows.Forms.CheckBox();
			this.cmbTextChannel = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbVoiceChannel = new System.Windows.Forms.ComboBox();
			this.lblChan = new System.Windows.Forms.Label();
			this.cmbServer = new System.Windows.Forms.ComboBox();
			this.lblServer = new System.Windows.Forms.Label();
			this.btnLeave = new System.Windows.Forms.Button();
			this.btnJoin = new System.Windows.Forms.Button();
			this.labelToken = new System.Windows.Forms.Label();
			this.textDiscordBotToken = new System.Windows.Forms.TextBox();
			this.BtnConnect = new System.Windows.Forms.Button();
			this.TabPageBackup = new System.Windows.Forms.TabPage();
			this.textCredPath = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.buttonAuth = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.button4 = new System.Windows.Forms.Button();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.tabControl.SuspendLayout();
			this.TabPageDiscord.SuspendLayout();
			this.TabPageBackup.SuspendLayout();
			this.SuspendLayout();
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
			this.logList.Location = new System.Drawing.Point(13, 362);
			this.logList.Name = "logList";
			this.logList.Size = new System.Drawing.Size(753, 157);
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
			this.listColMsg.Width = 610;
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.TabPageDiscord);
			this.tabControl.Controls.Add(this.TabPageBackup);
			this.tabControl.Location = new System.Drawing.Point(13, 16);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(753, 340);
			this.tabControl.TabIndex = 77;
			// 
			// TabPageDiscord
			// 
			this.TabPageDiscord.Controls.Add(this.checkBox1);
			this.TabPageDiscord.Controls.Add(this.chkAutoConnect);
			this.TabPageDiscord.Controls.Add(this.cmbTextChannel);
			this.TabPageDiscord.Controls.Add(this.label1);
			this.TabPageDiscord.Controls.Add(this.cmbVoiceChannel);
			this.TabPageDiscord.Controls.Add(this.lblChan);
			this.TabPageDiscord.Controls.Add(this.cmbServer);
			this.TabPageDiscord.Controls.Add(this.lblServer);
			this.TabPageDiscord.Controls.Add(this.btnLeave);
			this.TabPageDiscord.Controls.Add(this.btnJoin);
			this.TabPageDiscord.Controls.Add(this.labelToken);
			this.TabPageDiscord.Controls.Add(this.textDiscordBotToken);
			this.TabPageDiscord.Controls.Add(this.BtnConnect);
			this.TabPageDiscord.Location = new System.Drawing.Point(4, 22);
			this.TabPageDiscord.Name = "TabPageDiscord";
			this.TabPageDiscord.Padding = new System.Windows.Forms.Padding(3);
			this.TabPageDiscord.Size = new System.Drawing.Size(745, 314);
			this.TabPageDiscord.TabIndex = 0;
			this.TabPageDiscord.Text = "Discord";
			this.TabPageDiscord.UseVisualStyleBackColor = true;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(315, 35);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(214, 16);
			this.checkBox1.TabIndex = 89;
			this.checkBox1.Text = "戦闘終了時にDiscordにDPSログを送信";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// chkAutoConnect
			// 
			this.chkAutoConnect.AutoSize = true;
			this.chkAutoConnect.Location = new System.Drawing.Point(93, 62);
			this.chkAutoConnect.Name = "chkAutoConnect";
			this.chkAutoConnect.Size = new System.Drawing.Size(94, 16);
			this.chkAutoConnect.TabIndex = 88;
			this.chkAutoConnect.Text = "Auto Connect";
			this.chkAutoConnect.UseVisualStyleBackColor = true;
			// 
			// cmbTextChannel
			// 
			this.cmbTextChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTextChannel.Enabled = false;
			this.cmbTextChannel.FormattingEnabled = true;
			this.cmbTextChannel.Location = new System.Drawing.Point(12, 153);
			this.cmbTextChannel.Name = "cmbTextChannel";
			this.cmbTextChannel.Size = new System.Drawing.Size(239, 20);
			this.cmbTextChannel.TabIndex = 87;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 136);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(73, 12);
			this.label1.TabIndex = 86;
			this.label1.Text = "Text Channel";
			// 
			// cmbVoiceChannel
			// 
			this.cmbVoiceChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbVoiceChannel.Enabled = false;
			this.cmbVoiceChannel.FormattingEnabled = true;
			this.cmbVoiceChannel.Location = new System.Drawing.Point(12, 201);
			this.cmbVoiceChannel.Name = "cmbVoiceChannel";
			this.cmbVoiceChannel.Size = new System.Drawing.Size(239, 20);
			this.cmbVoiceChannel.TabIndex = 85;
			// 
			// lblChan
			// 
			this.lblChan.AutoSize = true;
			this.lblChan.Location = new System.Drawing.Point(9, 184);
			this.lblChan.Name = "lblChan";
			this.lblChan.Size = new System.Drawing.Size(79, 12);
			this.lblChan.TabIndex = 84;
			this.lblChan.Text = "Voice Channel";
			// 
			// cmbServer
			// 
			this.cmbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbServer.Enabled = false;
			this.cmbServer.FormattingEnabled = true;
			this.cmbServer.Location = new System.Drawing.Point(12, 104);
			this.cmbServer.Name = "cmbServer";
			this.cmbServer.Size = new System.Drawing.Size(239, 20);
			this.cmbServer.TabIndex = 83;
			// 
			// lblServer
			// 
			this.lblServer.AutoSize = true;
			this.lblServer.Location = new System.Drawing.Point(9, 91);
			this.lblServer.Name = "lblServer";
			this.lblServer.Size = new System.Drawing.Size(38, 12);
			this.lblServer.TabIndex = 82;
			this.lblServer.Text = "Server";
			// 
			// btnLeave
			// 
			this.btnLeave.Enabled = false;
			this.btnLeave.Location = new System.Drawing.Point(111, 226);
			this.btnLeave.Name = "btnLeave";
			this.btnLeave.Size = new System.Drawing.Size(94, 21);
			this.btnLeave.TabIndex = 81;
			this.btnLeave.Text = "Leave Channel";
			this.btnLeave.UseVisualStyleBackColor = true;
			// 
			// btnJoin
			// 
			this.btnJoin.Enabled = false;
			this.btnJoin.Location = new System.Drawing.Point(12, 225);
			this.btnJoin.Name = "btnJoin";
			this.btnJoin.Size = new System.Drawing.Size(93, 21);
			this.btnJoin.TabIndex = 80;
			this.btnJoin.Text = "Join Channel";
			this.btnJoin.UseVisualStyleBackColor = true;
			// 
			// labelToken
			// 
			this.labelToken.AutoSize = true;
			this.labelToken.Location = new System.Drawing.Point(10, 14);
			this.labelToken.Name = "labelToken";
			this.labelToken.Size = new System.Drawing.Size(58, 12);
			this.labelToken.TabIndex = 79;
			this.labelToken.Text = "Bot Token";
			// 
			// textToken
			// 
			this.textDiscordBotToken.Location = new System.Drawing.Point(12, 33);
			this.textDiscordBotToken.Name = "textToken";
			this.textDiscordBotToken.Size = new System.Drawing.Size(239, 19);
			this.textDiscordBotToken.TabIndex = 78;
			// 
			// BtnConnect
			// 
			this.BtnConnect.Location = new System.Drawing.Point(12, 58);
			this.BtnConnect.Name = "BtnConnect";
			this.BtnConnect.Size = new System.Drawing.Size(75, 23);
			this.BtnConnect.TabIndex = 77;
			this.BtnConnect.Text = "Connect";
			this.BtnConnect.UseVisualStyleBackColor = true;
			// 
			// TabPageBackup
			// 
			this.TabPageBackup.Controls.Add(this.checkBox2);
			this.TabPageBackup.Controls.Add(this.listView1);
			this.TabPageBackup.Controls.Add(this.button4);
			this.TabPageBackup.Controls.Add(this.linkLabel1);
			this.TabPageBackup.Controls.Add(this.label2);
			this.TabPageBackup.Controls.Add(this.textCredPath);
			this.TabPageBackup.Controls.Add(this.button2);
			this.TabPageBackup.Controls.Add(this.buttonAuth);
			this.TabPageBackup.Location = new System.Drawing.Point(4, 22);
			this.TabPageBackup.Name = "TabPageBackup";
			this.TabPageBackup.Padding = new System.Windows.Forms.Padding(3);
			this.TabPageBackup.Size = new System.Drawing.Size(745, 314);
			this.TabPageBackup.TabIndex = 1;
			this.TabPageBackup.Text = "Backup";
			this.TabPageBackup.UseVisualStyleBackColor = true;
			// 
			// textCredPath
			// 
			this.textCredPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textCredPath.Location = new System.Drawing.Point(122, 42);
			this.textCredPath.Name = "textCredPath";
			this.textCredPath.Size = new System.Drawing.Size(488, 19);
			this.textCredPath.TabIndex = 2;
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.button2.Location = new System.Drawing.Point(616, 40);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(31, 25);
			this.button2.TabIndex = 1;
			this.button2.Text = "...";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// buttonAuth
			// 
			this.buttonAuth.Location = new System.Drawing.Point(653, 40);
			this.buttonAuth.Name = "buttonAuth";
			this.buttonAuth.Size = new System.Drawing.Size(75, 23);
			this.buttonAuth.TabIndex = 0;
			this.buttonAuth.Text = "認証";
			this.buttonAuth.UseVisualStyleBackColor = true;
			this.buttonAuth.Click += new System.EventHandler(this.buttonAuth_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(17, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(95, 12);
			this.label2.TabIndex = 4;
			this.label2.Text = "credentialsファイル";
			// 
			// linkLabel1
			// 
			this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(17, 16);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(153, 12);
			this.linkLabel1.TabIndex = 5;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "自動バックアップセットアップ手順";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(612, 266);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(116, 23);
			this.button4.TabIndex = 6;
			this.button4.Text = "手動バックアップ";
			this.button4.UseVisualStyleBackColor = true;
			// 
			// listView1
			// 
			this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnPath,
            this.columnDate});
			this.listView1.FullRowSelect = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(19, 111);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(709, 140);
			this.listView1.TabIndex = 63;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnPath
			// 
			this.columnPath.Text = "パス";
			this.columnPath.Width = 300;
			// 
			// columnDate
			// 
			this.columnDate.Text = "最終バックアップ日時";
			this.columnDate.Width = 140;
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Checked = true;
			this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox2.Location = new System.Drawing.Point(19, 78);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(138, 16);
			this.checkBox2.TabIndex = 64;
			this.checkBox2.Text = "起動時にバックアップする";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// JuscoBotPlugin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.logList);
			this.Name = "JuscoBotPlugin";
			this.Size = new System.Drawing.Size(784, 533);
			this.tabControl.ResumeLayout(false);
			this.TabPageDiscord.ResumeLayout(false);
			this.TabPageDiscord.PerformLayout();
			this.TabPageBackup.ResumeLayout(false);
			this.TabPageBackup.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ListView logList;
		private System.Windows.Forms.ColumnHeader listColTim;
		private System.Windows.Forms.ColumnHeader listColMsg;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage TabPageDiscord;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox chkAutoConnect;
		private System.Windows.Forms.ComboBox cmbTextChannel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbVoiceChannel;
		private System.Windows.Forms.Label lblChan;
		private System.Windows.Forms.ComboBox cmbServer;
		private System.Windows.Forms.Label lblServer;
		private System.Windows.Forms.Button btnLeave;
		private System.Windows.Forms.Button btnJoin;
		private System.Windows.Forms.Label labelToken;
		private System.Windows.Forms.TextBox textDiscordBotToken;
		private System.Windows.Forms.Button BtnConnect;
		private System.Windows.Forms.TabPage TabPageBackup;
		private System.Windows.Forms.Button buttonAuth;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox textCredPath;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnPath;
		private System.Windows.Forms.ColumnHeader columnDate;
		private System.Windows.Forms.CheckBox checkBox2;
	}
}
