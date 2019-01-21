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
            passwordDetails.FillPassword(inst, 0);

            if (e.TreeNode.ProjectID > 0)
            {
                passwordList.FillList(inst, e.TreeNode.ProjectID);
                return;
            }

            if (e.TreeNode.ProjectID <= 0)
            {
                passwordList.FillList(inst, e.TreeNode.NodeType);
            }
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
    }
}
