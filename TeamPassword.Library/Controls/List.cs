using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace TeamPassword.Library.Controls
{
    public partial class List : UserControl
    {
		public event ListSelectionChanged ListSelectionChanged;
		public Instance inst { get; private set; }
		public View ViewStyle
		{
			get
			{
				return olvMain.View;
			}
			set
			{
				olvMain.View = value;
			}
		}
		public List()
        {
            InitializeComponent();
        }

		public void FillList(Instance _inst, int projectId)
		{
			inst = _inst;

			if (projectId <= 0)
				return;

			olvMain.SetObjects(null);
			string oldName = olvMain.EmptyListMsg;
			olvMain.EmptyListMsg = "Loading entries ...";
			tbFilter.Text = string.Empty;
			Application.DoEvents();

			try
			{
				olvMain.SetObjects(inst.Passwords.GetProjectPasswords(projectId).GetListEntryEx());
				olvMain.Sort("Name");
            }
			catch(Exception ex)
			{
				olvMain.ClearObjects();
			}

			olvMain.EmptyListMsg = oldName;
		}

        public void FillList(Instance _inst, Objects.TreeNodeExType fillType)
        {
            inst = _inst;

            switch (fillType)
            {
                case Objects.TreeNodeExType.Passwords_Favorite:
                case Objects.TreeNodeExType.Passwords_Archived:
                    break;
                default:
                    return;
            }

            olvMain.SetObjects(null);
            string oldName = olvMain.EmptyListMsg;
            olvMain.EmptyListMsg = "Loading entries ...";
            tbFilter.Text = string.Empty;
            Application.DoEvents();

            try
            {
                List<Library.Objects.Passwords.RootObject> pws;
                switch (fillType)
                {
                    case Objects.TreeNodeExType.Passwords_Favorite:
                        pws = inst.Passwords.GetFavoritePasswords().OrderBy(o => o.name).ToList();
                        break;
                    case Objects.TreeNodeExType.Passwords_Archived:
                        pws = inst.Passwords.GetArchivedPasswords().OrderBy(o => o.name).ToList();
                        break;
                    default:
                        return;
                }

                olvMain.SetObjects(pws.GetListEntryEx());
                olvMain.Sort("Name");
            }
            catch (Exception ex)
            {
                olvMain.ClearObjects();
            }

            olvMain.EmptyListMsg = oldName;
        }

		private void olvMain_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ListSelectionChanged == null)
				return;

			Objects.ListEntryEx selEntry = (Objects.ListEntryEx)((BrightIdeasSoftware.ObjectListView)sender).SelectedObject;

			if (selEntry == null)
				return;

			ListSelectionChanged(sender, new ListSelectionChangedEventArgs()
			{
				ListEntry = selEntry
			});
		}
		
		private void tbFilter_FilterChanged(object source, TextBoxFilterEx.TbFilterChangedArgs e)
		{
			if (string.IsNullOrWhiteSpace(tbFilter.Text))
			{
				olvMain.AdditionalFilter = null;
				return;
			}

			TextMatchFilter filter = TextMatchFilter.Contains(olvMain, tbFilter.Text);

			if (olvMain.DefaultRenderer == null)
				olvMain.DefaultRenderer = new HighlightTextRenderer(filter);

			olvMain.AdditionalFilter = filter;
		}
	}

	public delegate void ListSelectionChanged(object source, ListSelectionChangedEventArgs e);
	public class ListSelectionChangedEventArgs : EventArgs
	{
		public Objects.ListEntryEx ListEntry { get; set; }
	}
}
