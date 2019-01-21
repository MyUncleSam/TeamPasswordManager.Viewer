using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamPassword.Viewer
{
	public partial class Hotkey : Form
	{
		public string NewHotkey { get; private set; }

		public Hotkey()
		{
			InitializeComponent();
		}

		public void SetHotkey(string hotKey)
		{
			tbMain.Text = hotKey;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			NewHotkey = new string(tbMain.Text.Trim().Where(w => !char.IsWhiteSpace(w)).ToArray());
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
