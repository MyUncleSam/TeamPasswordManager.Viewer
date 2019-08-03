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

		private List<string> IgnoreProgramNames = new List<string>()
		{
            "TeamPassword.Viewer",
			"explorer",
			"ShellExperienceHost",
            "ApplicationFrameHost",
            "WinStore.App",
            "SystemSettings"
		};

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
                    && !IgnoreProgramNames.Any(a => a.Equals(w.ProcessName, StringComparison.OrdinalIgnoreCase)))
				.OrderBy(o => o.ProcessName)
                )
			{
				toShow.Add(
					new ListEntry()
					{
						ProcessId = proc.Id,
						Name = proc.ProcessName,
						Title = proc.MainWindowTitle,
						Process = proc
					}
				);

                if (incompCache.Contains(proc.ProcessName))
                    continue;

                string procName = null;
                try
				{
                    //il.Images.Add(proc.Id.ToString(), proc.GetIcon().ToBitmap());
                    //il.Images.Add(proc.Id.ToString(), Icon.ExtractAssociatedIcon(proc.MainModule.FileName).ToBitmap());
                    procName = proc.GetMainModuleFileName();

                    Icon ic = null;
                    if (icoCache.ContainsKey(procName))
                        ic = icoCache[procName];
                    else
                    {
                        ic = Icon.ExtractAssociatedIcon(procName);
                        icoCache.Add(procName, ic);
                    }

                    if(ic != null)
                        il.Images.Add(proc.Id.ToString(), ic.ToBitmap());
				}
				catch
                {
                    if (!incompCache.Contains(proc.ProcessName))
                        incompCache.Add(proc.ProcessName);
                }
			}

			olvMain.LargeImageList = il;
			olvMain.SmallImageList = il;
			olvMain.SetObjects(toShow);

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
		}

		private void olvMain_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
		{
			// only react on double click
			if (e.ClickCount != 2 || e.Item == null || e.Item.RowObject == null)
				return;

            Properties.Settings.Default.SendKeysSendReturn = SendReturn;
            Properties.Settings.Default.Save();

            Result = (ListEntry)e.Item.RowObject;
			this.DialogResult = DialogResult.OK;
			this.Close();
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

            Properties.Settings.Default.SendKeysSendReturn = SendReturn;
            Properties.Settings.Default.Save();

			Result = (ListEntry)olvMain.SelectedObject;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
    }
}
