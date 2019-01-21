using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamPassword.Viewer
{
	public partial class About : Form
	{
		public About()
		{
			InitializeComponent();

			AssemblyCopyrightAttribute copyright = (AssemblyCopyrightAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false).FirstOrDefault();
			string copyrightText = null;

			if (copyright != null)
				copyrightText = string.Format("{0} {1}", copyright.Copyright, DateTime.Now.Year);

			lblVersion.Text = string.Format(lblVersion.Text, Assembly.GetExecutingAssembly().GetName().Version.ToString());
			lblLibrary.Text = string.Format(lblLibrary.Text, Assembly.GetAssembly(typeof(Library.Instance)).GetName().Version.ToString());
			lblCopyright.Text = string.Format(lblCopyright.Text, copyrightText);
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
