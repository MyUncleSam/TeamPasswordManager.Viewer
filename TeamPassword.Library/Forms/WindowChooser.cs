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
		public ListEntry Result { get; private set; }

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
				.OrderBy(o => o.ProcessName))
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

				try
				{
                    //il.Images.Add(proc.Id.ToString(), proc.GetIcon().ToBitmap());
                    //il.Images.Add(proc.Id.ToString(), Icon.ExtractAssociatedIcon(proc.MainModule.FileName).ToBitmap());
                    il.Images.Add(proc.Id.ToString(), Icon.ExtractAssociatedIcon(proc.GetMainModuleFileName()).ToBitmap());
				}
				catch { }
			}

			olvMain.LargeImageList = il;
			olvMain.SmallImageList = il;
			olvMain.SetObjects(toShow);
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

			Result = (ListEntry)olvMain.SelectedObject;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
