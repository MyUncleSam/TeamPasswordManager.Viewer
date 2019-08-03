using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamPassword.Library.Forms
{
	public partial class Login : Form
	{
        public LoginInformation GetLoginInformation { get; private set; }
		private Label lblLoginCheck = new Label();

		public Login(LoginInformation li)
		{
			InitializeComponent();

            tbPubKey.Text = li.Username;
            tbPrivKey.Text = li.Password;
            tbUrl.Text = li.URL?.AbsoluteUri;

			lblLoginCheck.AutoSize = false;
			lblLoginCheck.TextAlign = ContentAlignment.MiddleCenter;
			lblLoginCheck.Text = "Checking login information...";
			lblLoginCheck.Cursor = Cursors.WaitCursor;
			lblLoginCheck.Dock = DockStyle.Fill;

			this.Controls.Add(lblLoginCheck);
			lblLoginCheck.SendToBack();
			lblLoginCheck.Hide();
		}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            LoginInformation cll = new LoginInformation();
            if(!string.IsNullOrWhiteSpace(tbUrl.Text))
            {
                try
                {
                    cll.URL = new Uri(tbUrl.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("The given url is not valid. Please provide a valid URL", "url missing/invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if(string.IsNullOrWhiteSpace(tbPrivKey.Text) || string.IsNullOrWhiteSpace(tbPubKey.Text))
            {
                MessageBox.Show("Please provide your access credentials.", "Missing credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cll.Username = tbPubKey.Text.Trim();
            cll.Password = tbPrivKey.Text.Trim();

			
			try
			{
				// test login information
				lblLoginCheck.Show();
				lblLoginCheck.BringToFront();
				Application.DoEvents();

				Instance inst = new Instance(cll.URL, cll.Username, cll.Password);
				inst.Version.GetVersion();

				GetLoginInformation = cll;

				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			catch
			{
				MessageBox.Show("Unable to validate login information.", "Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				GetLoginInformation = null;
			}
			finally
			{
				lblLoginCheck.SendToBack();
				lblLoginCheck.Hide();
			}
        }
    }
}
