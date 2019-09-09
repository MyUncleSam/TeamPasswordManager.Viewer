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
        private Library.Instance inst = null;
        private bool IsDoubleClicked = false;
        private ContextMenuStrip cms = new ContextMenuStrip();

        public Main()
        {
            InitializeComponent();

			// initialize clipboard manager
			//Library.Functions.ClipboardManager.GetInstance().UseSendkeys = Properties.Settings.Default.ActivateSendKeys;
			//try
			//{
			//	Library.Functions.ClipboardManager.GetInstance().ChangeHotkey(Properties.Settings.Default.SendKeysKey);
			//}
			//catch { }
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
            ToolStripMenuItem cmExit = new ToolStripMenuItem("Exit");
            cmExit.Image = Properties.Resources.exit;
            cmExit.Click += CmExit_Click;

            ToolStripMenuItem cmLogin = new ToolStripMenuItem("Login");
            cmLogin.Image = Properties.Resources.account;
            cmLogin.Click += CmLogin_Click;

            ToolStripMenuItem cmOpen = new ToolStripMenuItem("Open");
            cmOpen.Font = new Font(cmOpen.Font, FontStyle.Bold);
            cmOpen.Image = Properties.Resources.key.ToBitmap();
			cmOpen.Click += CmOpen_Click;

            //MenuItem cmKeyHooks = new MenuItem("Enable SendKeys");
            //cmKeyHooks.Checked = Properties.Settings.Default.ActivateSendKeys;
            //cmKeyHooks.Click += CmKeyHooks_Click;

            ToolStripMenuItem cmNewPassword = new ToolStripMenuItem("Copy new password");
            cmNewPassword.Image = Properties.Resources.copy_password;
            cmNewPassword.Click += CmNewPassword_Click;

            ToolStripMenuItem cmTypeText = new ToolStripMenuItem("Send text to application");
            cmTypeText.Image = Properties.Resources.appsend;
            cmTypeText.Click += CmTypeText_Click;

            ToolStripMenuItem cmAutostart = new ToolStripMenuItem("AutoStart");
            cmAutostart.Image = Properties.Resources.launch;
#if DEBUG
			cmAutostart.Enabled = false;
			cmAutostart.Text = string.Format("{0} (disabled in debug mode)", cmAutostart.Text);
#else
			cmAutostart.Click += CmAutostart_Click;
            cmAutostart.Checked = ManageAutostart.Instance.Enabled;
#endif

            ToolStripMenuItem cmAbout = new ToolStripMenuItem("About");
            cmAbout.Image = Properties.Resources.info;
			cmAbout.Click += CmAbout_Click;

			//MenuItem cmHotkey = new MenuItem("Set hotkey");
			//cmHotkey.Click += CmHotkey_Click;

			// add menu items
			cms.Items.Add(cmOpen);
			cms.Items.Add("-");
            cms.Items.Add(cmNewPassword);
            cms.Items.Add(cmTypeText);
            cms.Items.Add("-");
            cms.Items.Add(cmLogin);
			//cm.MenuItems.Add(cmKeyHooks);
			//cm.MenuItems.Add(cmHotkey);
            cms.Items.Add(cmAutostart);
            cms.Items.Add("-");
			cms.Items.Add(cmAbout);
            cms.Items.Add(cmExit);

            mainNotify.ContextMenuStrip = cms;

#if DEBUG
            ShowPasswordViewer();
#endif
        }

        private void CmTypeText_Click(object sender, EventArgs e)
        {
            Library.Functions.ClipboardManager.GetInstance().SendInputText();
        }

        //private void CmHotkey_Click(object sender, EventArgs e)
        //{
        //	Hotkey hk = new Hotkey();
        //	hk.SetHotkey(Properties.Settings.Default.SendKeysKey);

        //	bool successfullKey = false;
        //	while(!successfullKey && hk.ShowDialog() == DialogResult.OK)
        //	{
        //		try
        //		{
        //			Library.Functions.ClipboardManager.GetInstance().ChangeHotkey(hk.NewHotkey);

        //			Properties.Settings.Default.SendKeysKey = hk.NewHotkey;
        //			Properties.Settings.Default.Save();
        //			successfullKey = true;
        //		}
        //		catch
        //		{
        //			MessageBox.Show("This key combination is invalid.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        //		}
        //	}
        //}

        private void CmAbout_Click(object sender, EventArgs e)
		{
			(new About()).ShowDialog();
		}

		private void CmAutostart_Click(object sender, EventArgs e)
        {
            try
            {
                ManageAutostart.Instance.Enabled = !((ToolStripMenuItem)sender).Checked;
                ((ToolStripMenuItem)sender).Checked = ManageAutostart.Instance.Enabled;
            }
            catch (Exception ex)
            {
                ((ToolStripMenuItem)sender).Checked = false;
            }
        }

        private void CmNewPassword_Click(object sender, EventArgs e)
        {
            if (inst != null)
                Clipboard.SetText(inst.PasswordGenerator.GetNewPasswordString(), TextDataFormat.Text);
        }
		
		//private void CmKeyHooks_Click(object sender, EventArgs e)
		//{
		//	((MenuItem)sender).Checked = !((MenuItem)sender).Checked;
		//	Properties.Settings.Default.ActivateSendKeys = ((MenuItem)sender).Checked;
		//	Properties.Settings.Default.Save();
		//	Library.Functions.ClipboardManager.GetInstance().UseSendkeys = Properties.Settings.Default.ActivateSendKeys;
		//}

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

            TPM.TopMost = true;
            TPM.Show();
            TPM.BringToFront();
            TPM.Focus();
            TPM.TopMost = false;
        }

        private void ShowPasswordViewer()
        {
            mainNotify
                .ContextMenuStrip
                .Items
                .Cast<Object>()
                .Where(w => w.GetType() == typeof(ToolStripMenuItem))
                ?.Cast<ToolStripMenuItem>()
                ?.FirstOrDefault(f => f.Font.Bold)
                ?.PerformClick();
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
