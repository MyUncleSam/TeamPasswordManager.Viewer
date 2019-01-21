using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeamPassword.Library;

namespace TeamPassword.Viewer
{
    public partial class Test : Form
    {
        LoginInformation login = null;

        public Test(LoginInformation li)
        {
            login = li;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
			Instance inst = new Instance(login.URL, login.Username, login.Password);
			//var test1 = inst.Projects.GetProjects().OrderBy(o => o.name).ToList();
			//var test2 = inst.SubProjects.GetSubProjects(49).OrderBy(oa => oa.archived).ThenBy(tn => tn.name).ToList();
			//var test3 = inst.Projects.SearchProjects("GmbH & Co.");
			//var test4 = inst.Version.GetVersion();
			//var test5 = inst.ProjectInfo.GetProjectInfo(76);
			//var test6 = inst.Passwords.GetProjectPasswords(76);
			//var test7 = inst.Passwords.GetCount(76);
			//var test8 = inst.PasswordInfo.GetPassword(1063);
			//var test9 = inst.Passwords.GetPasswords();
			//var test10 = inst.PasswordGenerator.GetNewPassword();
			//var test11 = inst.Passwords.GetCount(139);
			//var test12 = inst.Passwords.GetFavoritePasswordsCount();
			//var test13 = inst.Projects.GetProjects();
			//var test14 = inst.SubProjects.GetRootProjects();
			//var test15 = inst.Projects.GetProjects("Büchele");
			//var test16 = inst.SubProjects.GetSubProjects(50);
			//var test17 = inst.Passwords.GetProjectPasswords(139);

			//var test = inst.SubProjects.GetRootProjects();
			var test = inst.PasswordInfo.GetPassword(1106);


			TeamPasswordManager nv = new TeamPasswordManager(inst);
			nv.Show();
        }
    }
}
