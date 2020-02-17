using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Dynamic;
using BrightIdeasSoftware;

namespace TeamPassword.Library.Forms
{
	public partial class WindowChooser : Form
	{
        private const string IconCacheName = "ProgIcons";
        private const string NotCompatiblePrograms = "ProgNotCompatible";
		public ListEntry Result { get; private set; }

        public bool SendReturn
        {
            get
            {
                return cbSendReturn.Checked;
            }
        }

		public WindowChooser()
		{
			InitializeComponent();

            Functions.SettingsUpdater.UpdateSettings();
            cbSendReturn.Checked = Properties.Settings.Default.SendKeysSendReturn;

            // register cache (all in all t takes 650ms - too slow
            Functions.Cache.Instance.Register<Dictionary<string, Icon>>(IconCacheName); // about 200ms faster after first usage (with same program list)
            Functions.Cache.Instance.Register<List<string>>(NotCompatiblePrograms); // about 150ms faster after first usage (with same program list)

            Dictionary<string, Icon> icoCache = Functions.Cache.Instance.GetCache<Dictionary<string, Icon>>(IconCacheName);
            List<string> incompCache = Functions.Cache.Instance.GetCache<List<string>>(NotCompatiblePrograms);

			colName.ImageGetter = delegate(object row)
			{
				ListEntry curEntry = (ListEntry)row;
				return curEntry.ProcessId.ToString();
			};

			ImageList il = new ImageList();
			List<ListEntry> toShow = new List<ListEntry>();

            int curSessionId = Process.GetCurrentProcess().SessionId;

			foreach (Process proc in Process.GetProcesses()
				.Where(w => 
                    !string.IsNullOrWhiteSpace(w.MainWindowTitle) 
                    && (w.MainWindowHandle != IntPtr.Zero && w.MainWindowHandle != null)
                    && w.SessionId.Equals(curSessionId)
                    && !Properties.Settings.Default.WindowChooserIgnoreProgramNames.Cast<string>().Any(a => a.Equals(w.ProcessName, StringComparison.OrdinalIgnoreCase)))
				.OrderBy(o => o.ProcessName)
                )
			{
                string procName = null;
                bool iconError = false;
                try { procName = proc.GetMainModuleFileName(); } catch { iconError = true; }

                ListEntry toAdd = new ListEntry()
                {
                    ProcessId = proc.Id,
                    Name = proc.ProcessName,
                    Title = proc.MainWindowTitle,
                    Process = proc,
                    ProcessName = procName
                };

                // search for process path in the usage list
                toAdd.InLastUsed = (!string.IsNullOrWhiteSpace(procName) 
                    && Properties.Settings.Default.WindowChooserUsage != null 
                    && Properties.Settings.Default.WindowChooserUsage.Contains(procName));

                if(toAdd.InLastUsed)
                    toAdd.SortString = Properties.Settings.Default.WindowChooserUsage.IndexOf(procName).ToString();
                else
                    toAdd.SortString = toAdd.Name;


				toShow.Add(
					toAdd
                );

                if (incompCache.Contains(proc.ProcessName))
                    continue;

                if(!iconError)
                {
                    try
                    {
                        //il.Images.Add(proc.Id.ToString(), proc.GetIcon().ToBitmap());
                        //il.Images.Add(proc.Id.ToString(), Icon.ExtractAssociatedIcon(proc.MainModule.FileName).ToBitmap());
                        //procName = proc.GetMainModuleFileName();

                        Icon ic = null;
                        if (icoCache.ContainsKey(procName))
                            ic = icoCache[procName];
                        else
                        {
                            ic = Icon.ExtractAssociatedIcon(procName);
                            icoCache.Add(procName, ic);
                        }

                        if (ic != null)
                            il.Images.Add(proc.Id.ToString(), ic.ToBitmap());
                    }
                    catch
                    {
                        iconError = true;
                    }
                }

                if(iconError)
                    if (!incompCache.Contains(proc.ProcessName))
                        incompCache.Add(proc.ProcessName);
            }

			olvMain.LargeImageList = il;
			olvMain.SmallImageList = il;
			olvMain.SetObjects(toShow);

            //olvMain.PrimarySortOrder = SortOrder.Ascending;
            olvMain.BuildGroups(olvMain.GetColumn("Recently used"), SortOrder.Descending);

            // writeback cache
            Functions.Cache.Instance.Update(IconCacheName, icoCache);
            Functions.Cache.Instance.Update(NotCompatiblePrograms, incompCache);
		}

		public class ListEntry
		{
			public int ProcessId { get; set; }
			public string Name { get; set; }
			public string Title { get; set; }
			public Process Process { get; set; }
            public string ProcessName { get; set; }
            public bool InLastUsed { get; set; }
            public string SortString { get; set; }
            public string LastUsed
            {
                get
                {
                    return InLastUsed ? "Recently used" : "Programs";
                }
            }
        }

		private void olvMain_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
		{
			// only react on double click
			if (e.ClickCount != 2 || e.Item == null || e.Item.RowObject == null)
				return;

            startSend((ListEntry)e.Item.RowObject);
        }

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			if (olvMain.SelectedObject == null)
				return;

            startSend((ListEntry)olvMain.SelectedObject);
		}

        private void startSend(ListEntry entry)
        {
            Properties.Settings.Default.SendKeysSendReturn = SendReturn;
            Properties.Settings.Default.Save();

            Result = entry;
            addToUsage(entry.ProcessName);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void addToUsage(string procName)
        {
            // no procname - nothing to do
            if (string.IsNullOrWhiteSpace(procName))
                return;

            if (Properties.Settings.Default.WindowChooserUsage == null)
                Properties.Settings.Default.WindowChooserUsage = new System.Collections.Specialized.StringCollection();

            int foundPos = Properties.Settings.Default.WindowChooserUsage.IndexOf(procName); // -1 not found

            if (foundPos >= 0)
            {
                // there is already an entry - we need to bring it to front of the list
                Properties.Settings.Default.WindowChooserUsage.RemoveAt(foundPos);
                Properties.Settings.Default.WindowChooserUsage.Insert(0, procName);
            }
            else
            {
                // insert new entry at first position
                Properties.Settings.Default.WindowChooserUsage.Insert(0, procName);
            }

            // remove last used from the list (if list would be too big)
            if (Properties.Settings.Default.WindowChooserUsage.Count >= Properties.Settings.Default.WindowChooserLastUsedEntries)
                Properties.Settings.Default.WindowChooserUsage.RemoveAt(Properties.Settings.Default.WindowChooserUsage.Count - 1);

            Properties.Settings.Default.Save();
        }

        private void OlvMain_BeforeCreatingGroups(object sender, CreateGroupsEventArgs e)
        {
            e.Parameters.ItemComparer = new MyItemComparer();
        }

        public class MyItemComparer : IComparer<OLVListItem>
        {
            public int Compare(OLVListItem x, OLVListItem y)
            {
                return ((ListEntry)x.RowObject).SortString.CompareTo(((ListEntry)y.RowObject).SortString);
            }
        }
    }
}
