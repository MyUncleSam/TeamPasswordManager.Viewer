using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeamPassword.Library;

namespace TeamPassword.Viewer
{
	public partial class TeamPasswordManager : Form
	{
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MINIMIZE = 0xF020;

        Instance inst = null;
		public View ViewStyle
		{
			get
			{
				return aioMain.ViewStyle;
			}
			set
			{
				aioMain.ViewStyle = value;
			}
		}

		public TeamPasswordManager(Instance _inst)
		{
			InitializeComponent();
			this.Text = string.Format("{0} - v{1} (library {2})", this.Text, Assembly.GetExecutingAssembly().GetName().Version.ToString(), Assembly.GetAssembly(typeof(Library.Instance)).GetName().Version.ToString());
			
			inst = _inst;
			aioMain.HidePasswordsAfterSeconds = Properties.Settings.Default.HidePasswordsAfterSeconds;
			aioMain.Fill(inst);
		}

		private void TeamPasswordManager_FormClosing(object sender, FormClosingEventArgs e)
		{
			if(e.CloseReason == CloseReason.UserClosing)
			{
				this.Hide();
				e.Cancel = true;
			}
		}

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = m.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MINIMIZE)
                    {
                        // we do hide the ui instead of minimizing it
                        // this prevents that we need to save the size and restore it
                        this.Hide();
                        return;
                    }
                    // If you don't want to do the default action then break
                    break;
            }
            base.WndProc(ref m);
        }

		private void TeamPasswordManager_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData != Keys.F1)
				return;

			(new About()).ShowDialog();
		}
	}
}
