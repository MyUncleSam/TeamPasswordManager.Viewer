using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using BrightIdeasSoftware;

namespace TeamPassword.Library.Controls
{
    public partial class TreeList : UserControl
    {
        public event TreeSelectionChanged TreeSelectionChanged;
		//public event CellDoubleClicked CellDoubleClicked;
        public Instance inst { get; private set; }
		//private DateTime LastClicked = DateTime.Now;
		//private int DoubleClickDurationMs = 200;

        public TreeList()
        {
            InitializeComponent();
			tlvMain_Resize(null, null);

            //this.KeyUp += TreeList_KeyUp;
            tlvMain.KeyDown += TlvMain_KeyDown;
        }

        private void TlvMain_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F5)
            {
                Objects.TreeNodeEx node = (Objects.TreeNodeEx)((BrightIdeasSoftware.TreeListView)sender).FocusedObject;
                if(node != null)
                {
                    try
                    {
                        tlvMain.RefreshObject(node);
                    }
                    catch { }
                }
            }
        }

        public void FillTree(Instance _inst)
        {
            inst = _inst;
            tlvMain.ClearObjects();
			
            // when to allow to expand
            this.tlvMain.CanExpandGetter = delegate (object x)
            {
                return (x is Objects.TreeNodeEx) && ((Objects.TreeNodeEx)x).CanExpand;
            };

            // results if expanding an entry
            this.tlvMain.ChildrenGetter = delegate (object x)
            {
                Objects.TreeNodeEx node = (Objects.TreeNodeEx)x;

                if (!node.CanExpand)
                    return null;

				try
				{
					return new ArrayList(node.GetSubProjects(inst));
				}
                catch
				{
					this.tlvMain.CollapseAll();
					this.tlvMain.ClearObjects();
					return null;
				}
            };

            // set root elements to start from
            this.tlvMain.Roots = new ArrayList(new Objects.TreeNodeEx(null, Objects.TreeNodeExType.Root).GetSubProjects(inst));
        }

        private void tlvMain_Resize(object sender, EventArgs e)
        {
            tlvMain.Columns[0].Width = tlvMain.Width - 5;
        }

        private void tlvMain_SelectionChanged(object sender, EventArgs e)
        {
            if (TreeSelectionChanged == null)
                return;
			
            Objects.TreeNodeEx node = (Objects.TreeNodeEx)((BrightIdeasSoftware.TreeListView)sender).FocusedObject;

			if (node == null)
				return;

            TreeSelectionChanged(sender, new TreeListSelectionChangedEventArgs()
            {
                TreeNode = node,
                SubProject = node.SubProjectObject
            });
        }

		private void tbFilter_FilterChanged(object sender, TextBoxFilterEx.TbFilterChangedArgs e)
		{
			if (string.IsNullOrWhiteSpace(tbFilter.Text))
			{
				tlvMain.AdditionalFilter = null;
				return;
			}

			// we need to expand all to do a real filtering ...
			tlvMain.ExpandAll();

			TextMatchFilter filter = TextMatchFilter.Contains(tlvMain, tbFilter.Text);

			if (tlvMain.DefaultRenderer == null)
				tlvMain.DefaultRenderer = new HighlightTextRenderer(filter);

			tlvMain.AdditionalFilter = filter;
		}
	}

	public delegate void TreeSelectionChanged(object source, TreeListSelectionChangedEventArgs e);
	//public delegate void CellDoubleClicked(object source, TreeListSelectionChangedEventArgs e);
    public class TreeListSelectionChangedEventArgs : EventArgs
    {
        public Library.Objects.SubProject.RootObject SubProject { get; set; }
        public Objects.TreeNodeEx TreeNode { get; set; }
    }
}
