using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamPassword.Library.Controls
{
    public partial class Password : UserControl
    {
		public Instance inst { get; private set; }
		public Objects.PasswordEntry PasswordEntry { get; set; }
		private int _HidePasswordsAfterSeconds = 0;
        private Uri _ExternalLinkAddress = null;

		public Password()
        {
            InitializeComponent();
			this.Enabled = false;
			tbPassword.UseSystemPasswordChar = true;
		}

		public int HidePasswordsAfterSeconds
		{
			get
			{
				return _HidePasswordsAfterSeconds;
			}
			set
			{
				_HidePasswordsAfterSeconds = value;

				this.Controls.OfType<TextBoxEx>().ToList().ForEach(f =>
				{
					f.HidePasswordAfterSeconds = value;
				});
			}
		}

		public void FillPassword(Instance _inst, int passwordId)
		{
			inst = _inst;

			if (passwordId <= 0)
			{
				tbAccess.Text = null;
				tbUsername.Text = null;
				tbEmail.Text = null;
				tbPassword.Text = null;
				tbExpiryDate.Text = null;
                rtbNotes.Text = null;
				olvOther.ClearObjects();
				this.Enabled = false;
                _ExternalLinkAddress = null;
				return;
			}
			
			PasswordEntry = inst.PasswordInfo.GetPassword(passwordId).GetPasswordEntryEx();
			tbAccess.Text = PasswordEntry.access_info;
			tbUsername.Text = PasswordEntry.username;
			tbEmail.Text = PasswordEntry.email;
			tbPassword.Text = PasswordEntry.password;
			tbExpiryDate.Text = PasswordEntry.expiry_date;
            rtbNotes.Text = PasswordEntry.notes.Replace("\n", Environment.NewLine);

            // try to create password uri
            _ExternalLinkAddress = null;
            Uri.TryCreate(inst.LoginInfo.URL, string.Format("index.php/pwd/view/{0}", passwordId), out _ExternalLinkAddress);

            pbOpenLink.Enabled = _ExternalLinkAddress != null;

            if (_ExternalLinkAddress == null)
                pbOpenLink.Cursor = Cursors.No;
            else
                pbOpenLink.Cursor = Cursors.Hand;

			List<PasswordOtherEntry> otherEntries = new List<PasswordOtherEntry>();
			IEnumerable<System.Reflection.PropertyInfo> props = PasswordEntry.GetType().GetProperties().Where(w => w.Name.StartsWith("custom_field"));

            string google2FAsecret = null;
			foreach (System.Reflection.PropertyInfo prop in props)
			{
				Library.Objects.PasswordInfo.Custom_Field cusFiels = (Library.Objects.PasswordInfo.Custom_Field)prop.GetValue(PasswordEntry, null);
				if (cusFiels == null)
					continue;

				PasswordOtherEntry toAdd = new PasswordOtherEntry()
				{
					Name = cusFiels.label,
					Value = cusFiels.data
				};

                if (toAdd.Name.Equals("Google2FA"))
                {
                    google2FAsecret = toAdd.Value;
                    toAdd.Value = "<hidden>";
                }

                otherEntries.Add(toAdd);
			}

            if (google2FAsecret == null)
                googleTotp.SetGoogleAuthenticatorSecrete(null);
            else
                googleTotp.SetGoogleAuthenticatorSecrete(google2FAsecret);

			olvOther.SetObjects(otherEntries);
			olvOther.Sort("Name");

			tbPassword.HidePassword();
			this.Enabled = true;
		}

		public class PasswordOtherEntry
		{
			public string Name { get; set; }
			public string Value { get; set; }
		}

		private void pbCopyUsernamePassword_Click(object sender, EventArgs e)
		{
			string username = tbUsername.Text;
			string password = tbPassword.Text;

			if (string.IsNullOrWhiteSpace(username))
				username = tbEmail.Text;

			if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
				return;

			Functions.ClipboardManager.ClipboardEntries ce = new Functions.ClipboardManager.ClipboardEntries();
			ce.AddEntry(username);
			ce.AddEntry(password);
			Functions.ClipboardManager.GetInstance().SetText(ce);
		}

		private void pbCopyUsernamePassword_MouseEnter(object sender, EventArgs e)
		{
			string username = tbUsername.Text;
			string password = tbPassword.Text;

			if (string.IsNullOrWhiteSpace(username))
				username = tbEmail.Text;

			if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
				pbCopyUsernamePassword.Cursor = Cursors.No;
			else
				pbCopyUsernamePassword.Cursor = Cursors.Hand;
		}

        private void rtbNotes_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void pbOpenLink_Click(object sender, EventArgs e)
        {
            if (_ExternalLinkAddress == null)
                return;

            System.Diagnostics.Process.Start(_ExternalLinkAddress.AbsoluteUri);
        }
    }
}
