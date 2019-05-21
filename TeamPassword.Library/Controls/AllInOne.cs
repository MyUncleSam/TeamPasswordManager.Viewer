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
	public partial class AllInOne : UserControl
	{
		public Instance inst { get; private set; }
		private int _HidePasswordsAfterSeconds = 0;
        private Uri _ExternalLinkAddress = null;

		public View ViewStyle
		{
			get
			{
				return passwordList.ViewStyle;
			}
			set
			{
				passwordList.ViewStyle = value;
			}
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
				passwordDetails.HidePasswordsAfterSeconds = value;
			}
		}

		public AllInOne()
		{
			InitializeComponent();
		}

		public void Fill(Instance _inst)
		{
			inst = _inst;
			treeList.FillTree(inst);
		}

		private void treeList_SelectionChanged(object source, TreeListSelectionChangedEventArgs e)
		{
            // reset current view (this just removes all entries)
            passwordDetails.FillPassword(inst, 0);
            _ExternalLinkAddress = null;

            if (e.TreeNode.ProjectID > 0)
            {
                passwordList.FillList(inst, e.TreeNode.ProjectID);
                Uri.TryCreate(inst.LoginInfo.URL, string.Format("index.php/prj/view/{0}", e.TreeNode.ProjectID), out _ExternalLinkAddress);
            }
            else
            {
                passwordList.FillList(inst, e.TreeNode.NodeType);
            }

            pbOpenLink.Enabled = _ExternalLinkAddress != null;
        }

		private void passwordList_ListSelectionChanged(object source, ListSelectionChangedEventArgs e)
		{
			passwordDetails.FillPassword(inst, e.ListEntry.id);
		}

        private void cbViewStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string enumText = Convert.ToString(((ComboBox)sender).SelectedItem);
                enumText = new string(enumText.Where(w => !char.IsWhiteSpace(w)).ToArray()); // removes all whitespaces

                if(string.IsNullOrWhiteSpace(enumText))
                {
                    passwordList.ViewStyle = View.Details;
                    return;
                }

                passwordList.ViewStyle = (View)Enum.Parse(typeof(View), enumText);
            }
            catch
            {
                passwordList.ViewStyle = View.Details;
            }
        }

        private void pbOpenLink_MouseEnter(object sender, EventArgs e)
        {
            if (_ExternalLinkAddress == null)
                pbOpenLink.Cursor = Cursors.No;
            else
                pbOpenLink.Cursor = Cursors.Hand;
        }

        private void pbOpenLink_Click(object sender, EventArgs e)
        {
            if (_ExternalLinkAddress == null)
                return;

            System.Diagnostics.Process.Start(_ExternalLinkAddress.AbsoluteUri);
        }
    }
}
