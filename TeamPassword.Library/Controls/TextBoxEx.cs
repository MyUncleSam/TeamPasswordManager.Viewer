using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TeamPassword.Library.Controls
{
	public partial class TextBoxEx : UserControl
	{
		[DllImport("User32.dll")]
		static extern int SetForegroundWindow(IntPtr point);

		[DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
		static extern bool ShowWindow(IntPtr hWnd, ShowWindowCommands nCmdShow);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool IsIconic(IntPtr hWnd);

		public new event TbTextChanged TextChanged;
		public event TbTextChanged TextChangedDelayed;

		private DateTime lastInput = DateTime.Now;
		private const int delay = 250; // delay in ms
		private Timer delayTimer = new Timer();
		private bool isPwVisible = false;
		private bool isPassword = false;
		private Timer HideTimer = new Timer();
        private bool IsReadOnly = true;

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
				return IsReadOnly;
			}
			set
			{
                IsReadOnly = value;
				tbMain.ReadOnly = IsReadOnly;
				tbMain.BackColor = SystemColors.Window;
			}
		}

		private Timer tImage = null;

		public TextBoxEx()
		{
			InitializeComponent();
			pbClipboard.Image = ilMain.Images["clipboard"];
			pbPassShowHide.Image = ilMain.Images["showhide"];
			pbSendApplication.Image = ilMain.Images["appsend"];

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

		private void pbSendApplication_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(tbMain.Text))
				return;

			string textToSend = tbMain.Text;

			Forms.WindowChooser wc = new Forms.WindowChooser();
			if(wc.ShowDialog() == DialogResult.OK)
			{
				try
				{
					Process proc = wc.Result.Process;

					// check if proc is still existing
					if (proc.HasExited)
						throw new Exception("Process is no longer available (maybe closed).");

					IntPtr handle = proc.MainWindowHandle;

					// check if window is minimized
					if(IsIconic(handle))
						ShowWindow(handle, ShowWindowCommands.ShowNoActivate);

					SetForegroundWindow(handle);

                    if (!string.IsNullOrWhiteSpace(textToSend))
                        textToSend.SendKeysExDelay(Properties.Settings.Default.SendDelay, Properties.Settings.Default.SendWait, wc.SendReturn);
				}
				catch(Exception ex)
				{
					MessageBox.Show(string.Format("Unable to send keys to application:{0}{1}", Environment.NewLine, ex.Message), "Unable to send", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				}
			}
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

		private void picturebox_MouseEnter(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(tbMain.Text))
				((PictureBox)sender).Cursor = Cursors.No;
			else
				((PictureBox)sender).Cursor = Cursors.Hand;
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

        private void tbMain_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
    }

    enum ShowWindowCommands
	{
		/// <summary>
		/// Hides the window and activates another window.
		/// </summary>
		Hide = 0,
		/// <summary>
		/// Activates and displays a window. If the window is minimized or
		/// maximized, the system restores it to its original size and position.
		/// An application should specify this flag when displaying the window
		/// for the first time.
		/// </summary>
		Normal = 1,
		/// <summary>
		/// Activates the window and displays it as a minimized window.
		/// </summary>
		ShowMinimized = 2,
		/// <summary>
		/// Maximizes the specified window.
		/// </summary>
		Maximize = 3, // is this the right value?
					  /// <summary>
					  /// Activates the window and displays it as a maximized window.
					  /// </summary>      
		ShowMaximized = 3,
		/// <summary>
		/// Displays a window in its most recent size and position. This value
		/// is similar to <see cref="Win32.ShowWindowCommand.Normal"/>, except
		/// the window is not activated.
		/// </summary>
		ShowNoActivate = 4,
		/// <summary>
		/// Activates the window and displays it in its current size and position.
		/// </summary>
		Show = 5,
		/// <summary>
		/// Minimizes the specified window and activates the next top-level
		/// window in the Z order.
		/// </summary>
		Minimize = 6,
		/// <summary>
		/// Displays the window as a minimized window. This value is similar to
		/// <see cref="Win32.ShowWindowCommand.ShowMinimized"/>, except the
		/// window is not activated.
		/// </summary>
		ShowMinNoActive = 7,
		/// <summary>
		/// Displays the window in its current size and position. This value is
		/// similar to <see cref="Win32.ShowWindowCommand.Show"/>, except the
		/// window is not activated.
		/// </summary>
		ShowNA = 8,
		/// <summary>
		/// Activates and displays the window. If the window is minimized or
		/// maximized, the system restores it to its original size and position.
		/// An application should specify this flag when restoring a minimized window.
		/// </summary>
		Restore = 9,
		/// <summary>
		/// Sets the show state based on the SW_* value specified in the
		/// STARTUPINFO structure passed to the CreateProcess function by the
		/// program that started the application.
		/// </summary>
		ShowDefault = 10,
		/// <summary>
		///  <b>Windows 2000/XP:</b> Minimizes a window, even if the thread
		/// that owns the window is not responding. This flag should only be
		/// used when minimizing windows from a different thread.
		/// </summary>
		ForceMinimize = 11
	}
}
