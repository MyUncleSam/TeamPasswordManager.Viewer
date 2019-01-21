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
				tbNotes.Text = null;
				olvOther.ClearObjects();
				this.Enabled = false;
				return;
			}
			
			PasswordEntry = inst.PasswordInfo.GetPassword(passwordId).GetPasswordEntryEx();
			tbAccess.Text = PasswordEntry.access_info;
			tbUsername.Text = PasswordEntry.username;
			tbEmail.Text = PasswordEntry.email;
			tbPassword.Text = PasswordEntry.password;
			tbExpiryDate.Text = PasswordEntry.expiry_date;
			tbNotes.Text = PasswordEntry.notes.Replace("\n", Environment.NewLine);

			List<PasswordOtherEntry> otherEntries = new List<PasswordOtherEntry>();
			IEnumerable<System.Reflection.PropertyInfo> props = PasswordEntry.GetType().GetProperties().Where(w => w.Name.StartsWith("custom_field"));

			foreach (System.Reflection.PropertyInfo prop in props)
			{
				Library.Objects.PasswordInfo.Custom_Field cusFiels = (Library.Objects.PasswordInfo.Custom_Field)prop.GetValue(PasswordEntry, null);
				if (cusFiels == null)
					continue;

				otherEntries.Add(new PasswordOtherEntry()
				{
					Name = cusFiels.label,
					Value = cusFiels.data
				});
			}

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
	}
}
