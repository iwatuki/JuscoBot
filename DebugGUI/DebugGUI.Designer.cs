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
			this.juscoBotPlugin1 = new ACT_JuscoBot.JuscoBotPlugin();
			this.SuspendLayout();
			// 
			// juscoBotPlugin1
			// 
			this.juscoBotPlugin1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.juscoBotPlugin1.Location = new System.Drawing.Point(4, 7);
			this.juscoBotPlugin1.Name = "juscoBotPlugin1";
			this.juscoBotPlugin1.Size = new System.Drawing.Size(820, 533);
			this.juscoBotPlugin1.TabIndex = 0;
			this.juscoBotPlugin1.Load += new System.EventHandler(this.juscoBotPlugin1_Load);
			// 
			// DebugGUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(836, 552);
			this.Controls.Add(this.juscoBotPlugin1);
			this.Name = "DebugGUI";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private ACT_JuscoBot.JuscoBotPlugin juscoBotPlugin1;
	}
}

