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
    public partial class Main : Form
    {
        private Library.LoginInformation login = null;
        public Library.Forms.Login loginForm = null;
		private TeamPasswordManager TPM = null;
		private ContextMenu cm = new ContextMenu();
        private Library.Instance inst = null;
        private bool IsDoubleClicked = false;

        public Main()
        {
            InitializeComponent();

			// initialize clipboard manager
			Library.Functions.ClipboardManager.GetInstance().UseSendkeys = Properties.Settings.Default.ActivateSendKeys;
			try
			{
				Library.Functions.ClipboardManager.GetInstance().ChangeHotkey(Properties.Settings.Default.SendKeysKey);
			}
			catch { }
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            this.Hide();

            if(Properties.Settings.Default.NeedsUpgrade)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.NeedsUpgrade = false;
                Properties.Settings.Default.Save();
            }

            login = new Library.LoginInformation();

            if (Properties.Settings.Default.Url != null)
            {
                login.URL = Properties.Settings.Default.Url;
                login.Password = Properties.Settings.Default.Password;
                login.Username = Properties.Settings.Default.Username;
            }

            // create menu items
            MenuItem cmExit = new MenuItem("Exit");
            cmExit.Click += CmExit_Click;

            MenuItem cmLogin = new MenuItem("Login");
            cmLogin.Click += CmLogin_Click;

			MenuItem cmOpen = new MenuItem("Open");
			cmOpen.DefaultItem = true;
			cmOpen.Click += CmOpen_Click;

			MenuItem cmKeyHooks = new MenuItem("Enable SendKeys");
			cmKeyHooks.Checked = Properties.Settings.Default.ActivateSendKeys;
			cmKeyHooks.Click += CmKeyHooks_Click;

            MenuItem cmNewPassword = new MenuItem("Copy new password");
            cmNewPassword.Click += CmNewPassword_Click;

            MenuItem cmAutostart = new MenuItem("AutoStart");
#if DEBUG
			cmAutostart.Enabled = false;
			cmAutostart.Text = string.Format("{0} (disabled in debug mode)", cmAutostart.Text);
#else
			cmAutostart.Click += CmAutostart_Click;
            cmAutostart.Checked = ManageAutostart.Instance.Enabled;
#endif

			MenuItem cmAbout = new MenuItem("About");
			cmAbout.Click += CmAbout_Click;

			MenuItem cmHotkey = new MenuItem("Set hotkey");
			cmHotkey.Click += CmHotkey_Click;

			// add menu items
			cm.MenuItems.Add(cmOpen);
			cm.MenuItems.Add("-");
            cm.MenuItems.Add(cmNewPassword);
            cm.MenuItems.Add("-");
            cm.MenuItems.Add(cmLogin);
			cm.MenuItems.Add(cmKeyHooks);
			cm.MenuItems.Add(cmHotkey);
            cm.MenuItems.Add(cmAutostart);
            cm.MenuItems.Add("-");
			cm.MenuItems.Add(cmAbout);
            cm.MenuItems.Add(cmExit);

            mainNotify.ContextMenu = cm;

#if DEBUG
            ShowPasswordViewer();
#endif
        }

		private void CmHotkey_Click(object sender, EventArgs e)
		{
			Hotkey hk = new Hotkey();
			hk.SetHotkey(Properties.Settings.Default.SendKeysKey);

			bool successfullKey = false;
			while(!successfullKey && hk.ShowDialog() == DialogResult.OK)
			{
				try
				{
					Library.Functions.ClipboardManager.GetInstance().ChangeHotkey(hk.NewHotkey);

					Properties.Settings.Default.SendKeysKey = hk.NewHotkey;
					Properties.Settings.Default.Save();
					successfullKey = true;
				}
				catch
				{
					MessageBox.Show("This key combination is invalid.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				}
			}
		}

		private void CmAbout_Click(object sender, EventArgs e)
		{
			(new About()).ShowDialog();
		}

		private void CmAutostart_Click(object sender, EventArgs e)
        {
            try
            {
                ManageAutostart.Instance.Enabled = !((MenuItem)sender).Checked;
                ((MenuItem)sender).Checked = ManageAutostart.Instance.Enabled;
            }
            catch
            {
                ((MenuItem)sender).Checked = false;
            }
        }

        private void CmNewPassword_Click(object sender, EventArgs e)
        {
            if (inst != null)
                Clipboard.SetText(inst.PasswordGenerator.GetNewPasswordString(), TextDataFormat.Text);
        }
		
		private void CmKeyHooks_Click(object sender, EventArgs e)
		{
			((MenuItem)sender).Checked = !((MenuItem)sender).Checked;
			Properties.Settings.Default.ActivateSendKeys = ((MenuItem)sender).Checked;
			Properties.Settings.Default.Save();
			Library.Functions.ClipboardManager.GetInstance().UseSendkeys = Properties.Settings.Default.ActivateSendKeys;
		}

		private void CmOpen_Click(object sender, EventArgs e)
		{
            if (TPM == null)
            {
                try
                {
                    inst = new Library.Instance(Properties.Settings.Default.Url, Properties.Settings.Default.Username, Properties.Settings.Default.Password);
                    inst.Version.GetVersion();
                    TPM = new TeamPasswordManager(inst);

					var test = Properties.Settings.Default.ViewStyle;
					TPM.ViewStyle = (View)Enum.Parse(typeof(View), Properties.Settings.Default.ViewStyle);
                }
                catch
                {
                    CmLogin_Click(null, null);
                    return;
                }
            }

            TPM.Show();
            TPM.BringToFront();
        }

        private void ShowPasswordViewer()
        {
            foreach (MenuItem me in mainNotify.ContextMenu.MenuItems)
            {
                if (!me.DefaultItem)
                    continue;

                // use first found default menu item to call
                me.PerformClick();
                return;
            }
        }

		private void TPM_FormClosed(object sender, FormClosedEventArgs e)
		{
			TPM = null;
		}

		private void CmLogin_Click(object sender, EventArgs e)
        {
            if (this.loginForm != null)
            {
                this.loginForm.BringToFront();
                return;
            }

            Library.LoginInformation li = new Library.LoginInformation();
            
            if(Properties.Settings.Default.Url != null)
            {
                li.URL = Properties.Settings.Default.Url;
                li.Password = Properties.Settings.Default.Password;
                li.Username = Properties.Settings.Default.Username;
            }

            loginForm = new Library.Forms.Login(li);
            if(loginForm.ShowDialog() == DialogResult.OK)
            {
				if (TPM != null)
				{
					TPM.Close();
					TPM = null;
				}

				Properties.Settings.Default.Url = loginForm.GetLoginInformation.URL;
                Properties.Settings.Default.Username = loginForm.GetLoginInformation.Username;
                Properties.Settings.Default.Password = loginForm.GetLoginInformation.Password;
                Properties.Settings.Default.Save();

                ShowPasswordViewer();
			}

            loginForm = null;
		}

        private void CmExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

		private void mainNotify_DoubleClick(object sender, EventArgs e)
		{
            if(!IsDoubleClicked)
            {
                IsDoubleClicked = true;
                ShowPasswordViewer();
                IsDoubleClicked = false;
            }
		}

		private void Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			if(TPM != null)
			{
				Properties.Settings.Default.ViewStyle = TPM.ViewStyle.ToString();
				Properties.Settings.Default.Save();
			}
		}
	}
}
