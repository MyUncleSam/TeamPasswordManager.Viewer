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
	public partial class TextBoxEx : UserControl
	{
		public new event TbTextChanged TextChanged;
		public new event TbTextChanged TextChangedDelayed;

		private DateTime lastInput = DateTime.Now;
		private const int delay = 250; // delay in ms
		private Timer delayTimer = new Timer();
		private bool isPwVisible = false;
		private bool isPassword = false;
		private Timer HideTimer = new Timer();

		public bool UseSystemPasswordChar
		{
			get
			{
				return isPwVisible;
			}
			set
			{
				tbMain.UseSystemPasswordChar = value;
				isPwVisible = false;
				HideTimer.Stop();

				if (value)
				{
					// we need to change to password mode
					pbPassShowHide.Show();
					tbMain.UseSystemPasswordChar = true;

					if(value != isPassword)
						tbMain.Size = new Size(tbMain.Size.Width - (pbPassShowHide.Size.Width + 5), tbMain.Size.Height);
				}
				else
				{
					// change to normal mode
					pbPassShowHide.Hide();
					tbMain.UseSystemPasswordChar = false;

					if (value != isPassword)
						tbMain.Size = new Size(tbMain.Size.Width + (pbPassShowHide.Size.Width + 5), tbMain.Size.Height);
				}

				isPassword = value;
			}
		}

		public int HidePasswordAfterSeconds { get; set; }

		public new string Text
		{
			get
			{
				return tbMain.Text;
			}
			set
			{
				tbMain.Text = value;
                HideTimer.Stop();
                HidePassword();
			}
		}
		public bool ReadOnly
		{
			get
			{
				return tbMain.ReadOnly;
			}
			set
			{
				tbMain.ReadOnly = value;
				tbMain.BackColor = SystemColors.Window;
			}
		}

		private Timer tImage = null;

		public TextBoxEx()
		{
			InitializeComponent();
			pbClipboard.Image = ilMain.Images["clipboard"];
			pbPassShowHide.Image = ilMain.Images["showhide"];

			delayTimer.Interval = delay;
			delayTimer.Tick += DelayTimer_Tick;

			pbPassShowHide.Hide();
			HideTimer.Tick += HideTimer_Tick;
		}

		public void HidePassword()
		{
			if(isPwVisible)
			{
				tbMain.UseSystemPasswordChar = true;
				isPwVisible = false;
			}
		}

		private void HideTimer_Tick(object sender, EventArgs e)
		{
			HideTimer.Stop();
			HidePassword();
		}

		private void DelayTimer_Tick(object sender, EventArgs e)
		{
			delayTimer.Stop();

			TextChangedDelayed(this, new TbTextChangedArgs()
			{
				Text = tbMain.Text
			});
		}

		private void pbClipboard_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(tbMain.Text))
				return;

			//Clipboard.SetText(tbMain.Text, TextDataFormat.Text);
			Functions.ClipboardManager.GetInstance().SetText(tbMain.Text);

			pbClipboard.Image = ilMain.Images["success"];

			if(tImage != null)
			{
				tImage.Stop();
				tImage.Dispose();
				tImage = null;
			}

			tImage = new Timer();
			tImage.Tick += TImage_Tick;
			tImage.Interval = 1000;
			tImage.Start();
		}

		private void TImage_Tick(object sender, EventArgs e)
		{
			pbClipboard.Image = ilMain.Images["clipboard"];
		}

		public delegate void TbTextChanged(object source, TbTextChangedArgs e);
		public class TbTextChangedArgs : EventArgs
		{
			public string Text { get; set; }
		}

		private void tbMain_TextChanged(object sender, EventArgs e)
		{
			if (TextChanged != null)
			{
				TextChanged(this, new TbTextChangedArgs()
				{
					Text = this.Text
				});
			}

			if(TextChangedDelayed != null)
			{
				delayTimer.Stop();
				delayTimer.Start();
			}
		}

		private void pbClipboard_MouseEnter(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(tbMain.Text))
				pbClipboard.Cursor = Cursors.No;
			else
				pbClipboard.Cursor = Cursors.Hand;
		}

		private void pbPassShowHide_Click(object sender, EventArgs e)
		{
			tbMain.UseSystemPasswordChar = isPwVisible;
			isPwVisible = !isPwVisible;

			if (isPwVisible && HidePasswordAfterSeconds > 0)
			{
				HideTimer.Interval = HidePasswordAfterSeconds * 1000;
				HideTimer.Start();
			}
			else
			{
				HideTimer.Stop();
			}
		}

		private void tbMain_Click(object sender, EventArgs e)
		{
			tbMain.SelectAll();
		}
	}
}
