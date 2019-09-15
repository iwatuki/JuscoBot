using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebugGUI {
	public partial class DebugGUI : Form {
		public DebugGUI() {
			InitializeComponent();
		}

		private void juscoBotPlugin1_Load(object sender, EventArgs e) {
			juscoBotPlugin1.InitForDebugUI();
		}
	}
}
