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
	public partial class TextBoxFilterEx : UserControl
	{
		public new event TbFilterChanged FilterChanged;
		public new event TbFilterChanged FilterChangedDelayed;

        public bool RecursiveCheckbox { get; set; }

        private DateTime lastInput = DateTime.Now;
		private const int delay = 250; // delay in ms
		private Timer delayTimer = new Timer();

		public new string Text
		{
			get
			{
				return tbMain.Text;
			}
			set
			{
				tbMain.Text = value;
			}
		}

		public TextBoxFilterEx()
		{
			InitializeComponent();
			pbClear.Image = ilMain.Images["delete"];

			delayTimer.Interval = delay;
			delayTimer.Tick += DelayTimer_Tick;
		}

		private void DelayTimer_Tick(object sender, EventArgs e)
		{
			delayTimer.Stop();

			FilterChangedDelayed(this, new TbFilterChangedArgs()
			{
				Text = tbMain.Text
			});
		}

		public delegate void TbFilterChanged(object source, TbFilterChangedArgs e);
		public class TbFilterChangedArgs : EventArgs
		{
			public string Text { get; set; }
		}

		private void tbMain_TextChanged(object sender, EventArgs e)
		{
			if (FilterChanged != null)
			{
				FilterChanged(this, new TbFilterChangedArgs()
				{
					Text = this.Text
				});
			}

			if(FilterChangedDelayed != null)
			{
				delayTimer.Stop();
				delayTimer.Start();
			}
		}

		private void pbClear_Click(object sender, EventArgs e)
		{
			tbMain.Text = string.Empty;
		}
	}
}
