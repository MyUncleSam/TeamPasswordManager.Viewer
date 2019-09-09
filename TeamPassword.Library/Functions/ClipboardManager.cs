using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamPassword.Library.Functions
{
	public sealed class ClipboardManager
	{
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
