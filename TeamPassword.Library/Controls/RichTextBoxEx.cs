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
    public partial class RichTextBoxEx : UserControl
    {
        private bool _UseSystemPasswordChar = false;
        private bool _ReadOnly = false;
        TextBox tbPassword = new TextBox();

        public RichTextBoxEx()
        {
            InitializeComponent();

            this.Controls.Add(tbPassword);
            tbPassword.ReadOnly = true;
            tbPassword.Visible = false;
            tbPassword.Multiline = false; // multiline disables password char!
            tbPassword.UseSystemPasswordChar = true;
            tbPassword.Dock = DockStyle.Fill;
            //tbPassword.Anchor = rtbMain.Anchor;
            tbPassword.BorderStyle = BorderStyle.FixedSingle;
        }

        private void rtbMain_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        public bool UseSystemPasswordChar
        {
            get
            {
                return _UseSystemPasswordChar;
            }
            set
            {
                _UseSystemPasswordChar = value;

                tbPassword.Visible = value;
                rtbMain.Visible = !value;

                if (value)
                    tbPassword.BringToFront();
                else
                    rtbMain.BringToFront();
            }
        }

        public bool ReadOnly
        {
            get
            {
                return _ReadOnly;
            }
            set
            {
                rtbMain.ReadOnly = value;
            }
        }

        public void SelectAll()
        {
            if (UseSystemPasswordChar)
                tbPassword.SelectAll();
            else
                rtbMain.SelectAll();
        }

        public override string Text
        {
            get
            {
                return rtbMain.Text;
            }
            set
            {
                tbPassword.Text = value;
                rtbMain.Text = value;
            }
        }
    }
}
