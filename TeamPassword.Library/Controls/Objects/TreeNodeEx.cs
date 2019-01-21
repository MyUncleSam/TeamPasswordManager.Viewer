using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamPassword.Library.Controls.Objects
{
	public class TreeNodeEx : TreeNode
	{
		public TreeNodeExType NodeType { get; private set; }
		public int ProjectID { get; private set; }
		public bool Archived { get; set; }
        public bool CanExpand { get; set; } = true;
        public Library.Objects.SubProject.RootObject SubProjectObject { get; private set; }

        public TreeNodeEx(int? prjId, TreeNodeExType nt = TreeNodeExType.Project, Library.Objects.SubProject.RootObject subProject = null)
		{
			if (prjId == null)
                ProjectID = 0;
			else
                ProjectID = (int)prjId;

            SubProjectObject = subProject;
			NodeType = nt;
		}

		public List<TreeNodeEx> GetSubProjects(Instance inst)
		{
			switch (NodeType)
			{
				case TreeNodeExType.Passwords_All:
					return inst.SubProjects.GetRootProjects().GetNodesEx().OrderBy(o => o.Name).ToList();
				case TreeNodeExType.Project:
					return inst.SubProjects.GetSubProjects(ProjectID).GetNodesEx().OrderBy(o => o.Name).ToList();
                case TreeNodeExType.Root:
                    return new List<TreeNodeEx>()
                    {
                        new TreeNodeEx(null, TreeNodeExType.Root_Passwords) { Name = "Passwords" },
                        new TreeNodeEx(null, TreeNodeExType.Root_Projects) { Name = "Projects" },
                    };
				case TreeNodeExType.Root_Passwords:
					return new List<TreeNodeEx>()
					{
						new TreeNodeEx(null, TreeNodeExType.Passwords_All) { Name = "All" },
						//new TreeNodeEx(null, TreeNodeExType.Passwords_Recent) { Name = "Recent", CanExpand = false },
						new TreeNodeEx(null, TreeNodeExType.Passwords_Favorite) { Name = "Favorite", CanExpand = false },
						//new TreeNodeEx(null, TreeNodeExType.Passwords_Active) { Name = "Active", CanExpand = false },
						new TreeNodeEx(null, TreeNodeExType.Passwords_Archived) { Name = "Archived", CanExpand = false }
					};
				case TreeNodeExType.Root_Projects:
					return new List<TreeNodeEx>()
					{
						//new TreeNodeEx(null, TreeNodeExType.Projects_Recent) { Name = "Recent" },
						new TreeNodeEx(null, TreeNodeExType.Projects_Favorite) { Name = "Favorite" },
						//new TreeNodeEx(null, TreeNodeExType.Projects_Active) { Name = "Active" },
						new TreeNodeEx(null, TreeNodeExType.Projects_Archived) { Name = "Archived" },
					};
                case TreeNodeExType.Projects_Archived:
                    return inst.Projects.GetArchivedProjects().GetNodexEx().OrderBy(o => o.Name).ToList();
                case TreeNodeExType.Projects_Favorite:
                    return inst.Projects.GetFavoriteProjects().GetNodexEx().OrderBy(o => o.Name).ToList();
                case TreeNodeExType.Projects_Active:
                    return inst.Projects.GetProjects().GetNodexEx().OrderBy(o => o.Name).ToList();
				default:
					return null;
			}
		}
	}

	public enum TreeNodeExType
	{
		Project = 0,
        Root,
		Root_Passwords,
		Root_Projects,
		Passwords_Recent,
		Passwords_Favorite,
		Passwords_Active,
		Passwords_All,
		Passwords_Archived,
		Projects_Recent,
		Projects_Favorite,
		Projects_Active,
		Projects_Archived
	}
}
