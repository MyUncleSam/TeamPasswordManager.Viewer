using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeamPassword.Library.Controls;

namespace TeamPassword.Library.Functions
{
	public sealed class ClipboardManager
	{
        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr point);

        [DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
        static extern bool ShowWindow(IntPtr hWnd, ShowWindowCommands nCmdShow);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsIconic(IntPtr hWnd);

        private static ClipboardManager Instance = null;
		private IKeyboardMouseEvents GlobalHooks = null;
		//public bool UseSendkeys { get; set; }
		public ClipboardEntries ToPaste = null;

		private Timer PasteDelayTimer = new Timer();

		private ClipboardManager()
		{
			PasteDelayTimer.Interval = 100;
			PasteDelayTimer.Tick += PasteDelayTimer_Tick;
            InitializeHotkey();
		}

		public static ClipboardManager GetInstance()
		{
			if (Instance == null)
			{
				Instance = new ClipboardManager();
			}

			return Instance;
		}

        public void InitializeHotkey()
        {
            if (GlobalHooks != null)
                GlobalHooks.Dispose();

            GlobalHooks = Hook.GlobalEvents();

            //var hotkey = Combination.FromString(hotKey);
            var hotkeyPaste = Combination.FromString("Control+V");

            Action skActionPaste = skSendPaste;

            GlobalHooks.OnCombination(new Dictionary<Combination, Action>
            {
                { hotkeyPaste, skActionPaste }
            });
        }

        public void SendInputText()
        {
            string initialText = Clipboard.GetText();
            TeamPassword.Library.Forms.InputText it = new Forms.InputText();

            if (!string.IsNullOrWhiteSpace(initialText))
                it.tbMain.Text = initialText;

            it.Text = "Text to send";

            if(it.ShowDialog() == DialogResult.OK)
            {
                string textToSend = it.tbMain.Text.Trim();
                Forms.WindowChooser wc = new Forms.WindowChooser();
                if (wc.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Process proc = wc.Result.Process;

                        // check if proc is still existing
                        if (proc.HasExited)
                            throw new Exception("Process is no longer available (maybe closed).");

                        IntPtr handle = proc.MainWindowHandle;

                        // check if window is minimized
                        if (IsIconic(handle))
                            ShowWindow(handle, ShowWindowCommands.ShowNoActivate);

                        SetForegroundWindow(handle);

                        if (!string.IsNullOrWhiteSpace(textToSend))
                            textToSend.SendKeysExDelay(Properties.Settings.Default.SendDelay, Properties.Settings.Default.SendWait, wc.SendReturn);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("Unable to send keys to application:{0}{1}", Environment.NewLine, ex.Message), "Unable to send", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
            }
        }

        public void SetText(ClipboardEntries entries)
		{
			ToPaste = entries;
			
			if(ToPaste.Entries.Count > 0)
				CopyToClipboard(ToPaste.Entries.OrderBy(o => o.Sort).First().Text);
		}

		public void SetText(string pasteText)
		{
			ToPaste = new ClipboardEntries();
			ToPaste.AddEntry(pasteText);

			CopyToClipboard(pasteText);
		}

		private void CopyToClipboard(string text)
		{
			Clipboard.SetText(text);
			System.Diagnostics.Debug.WriteLine(string.Format("New clipboard text: {0}", text));
		}


		private void skSendPaste()
		{
			PasteDelayTimer.Start();
		}

		private void PasteDelayTimer_Tick(object sender, EventArgs e)
		{
			PasteDelayTimer.Stop();
			TextPasted();
		}

		// check if the pasted text is the first entry in the known paste textes and copy next one if it matches
		private void TextPasted()
		{
			if (ToPaste == null || ToPaste.Entries.Count <= 0)
				return;

			string curText = Clipboard.GetText();

			if (string.IsNullOrWhiteSpace(curText))
				return;

			ClipboardEntry firstEntry = ToPaste.Entries.OrderBy(o => o.Sort).First();

			if (firstEntry.Text.Equals(curText))
			{
				// remove first paste entry
				ToPaste.Entries = ToPaste.Entries.Where(w => w.Sort != firstEntry.Sort).ToList();

				if (ToPaste.Entries.Count > 0)
				{
					Clipboard.SetText(ToPaste.Entries.OrderBy(o => o.Sort).First().Text);
					System.Diagnostics.Debug.WriteLine(string.Format("Set Clipboard Text: {0}", ToPaste.Entries.OrderBy(o => o.Sort).First().Text));
				}
			}
			else
			{
				// reset pastings because current text in clipboard is unknown
				ToPaste = null;
				return;
			}
		}
		
		public class ClipboardEntry
		{
			public ClipboardEntry() { }

			public int Sort { get; set; }
			public string Text { get; set; }
		}

		public class ClipboardEntries
		{
			public List<ClipboardEntry> Entries { get; set; }

			public ClipboardEntries()
			{
				Entries = new List<ClipboardEntry>();
			}

			public void AddEntry(string text)
			{
				Entries.Add(new ClipboardEntry()
				{
					Text = text,
					Sort = Entries.Count
				});
			}
		}
	}
}
