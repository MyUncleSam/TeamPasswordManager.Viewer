﻿namespace TeamPassword.Library.Controls
{
    partial class Password
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Password));
			this.lblAccess = new System.Windows.Forms.Label();
			this.lblUsername = new System.Windows.Forms.Label();
			this.lblEmail = new System.Windows.Forms.Label();
			this.lblExpiryDate = new System.Windows.Forms.Label();
			this.lblPassword = new System.Windows.Forms.Label();
			this.olvOther = new BrightIdeasSoftware.ObjectListView();
			this.olvColumnName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvColumnValue = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.lblNotes = new System.Windows.Forms.Label();
			this.tbNotes = new System.Windows.Forms.TextBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.pbCopyUsernamePassword = new System.Windows.Forms.PictureBox();
			this.tbExpiryDate = new TeamPassword.Library.Controls.TextBoxEx();
			this.tbPassword = new TeamPassword.Library.Controls.TextBoxEx();
			this.tbEmail = new TeamPassword.Library.Controls.TextBoxEx();
			this.tbUsername = new TeamPassword.Library.Controls.TextBoxEx();
			this.tbAccess = new TeamPassword.Library.Controls.TextBoxEx();
			((System.ComponentModel.ISupportInitialize)(this.olvOther)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbCopyUsernamePassword)).BeginInit();
			this.SuspendLayout();
			// 
			// lblAccess
			// 
			this.lblAccess.AutoSize = true;
			this.lblAccess.Location = new System.Drawing.Point(3, 6);
			this.lblAccess.Name = "lblAccess";
			this.lblAccess.Size = new System.Drawing.Size(42, 13);
			this.lblAccess.TabIndex = 0;
			this.lblAccess.Text = "Access";
			// 
			// lblUsername
			// 
			this.lblUsername.AutoSize = true;
			this.lblUsername.Location = new System.Drawing.Point(3, 32);
			this.lblUsername.Name = "lblUsername";
			this.lblUsername.Size = new System.Drawing.Size(55, 13);
			this.lblUsername.TabIndex = 2;
			this.lblUsername.Text = "Username";
			// 
			// lblEmail
			// 
			this.lblEmail.AutoSize = true;
			this.lblEmail.Location = new System.Drawing.Point(3, 84);
			this.lblEmail.Name = "lblEmail";
			this.lblEmail.Size = new System.Drawing.Size(35, 13);
			this.lblEmail.TabIndex = 6;
			this.lblEmail.Text = "E-mail";
			// 
			// lblExpiryDate
			// 
			this.lblExpiryDate.AutoSize = true;
			this.lblExpiryDate.Location = new System.Drawing.Point(3, 110);
			this.lblExpiryDate.Name = "lblExpiryDate";
			this.lblExpiryDate.Size = new System.Drawing.Size(59, 13);
			this.lblExpiryDate.TabIndex = 8;
			this.lblExpiryDate.Text = "Expiry date";
			// 
			// lblPassword
			// 
			this.lblPassword.AutoSize = true;
			this.lblPassword.Location = new System.Drawing.Point(3, 58);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(53, 13);
			this.lblPassword.TabIndex = 4;
			this.lblPassword.Text = "Password";
			// 
			// olvOther
			// 
			this.olvOther.AllColumns.Add(this.olvColumnName);
			this.olvOther.AllColumns.Add(this.olvColumnValue);
			this.olvOther.AllowColumnReorder = true;
			this.olvOther.AlternateRowBackColor = System.Drawing.Color.AliceBlue;
			this.olvOther.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.olvOther.CellEditUseWholeCell = false;
			this.olvOther.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnName,
            this.olvColumnValue});
			this.olvOther.Cursor = System.Windows.Forms.Cursors.Default;
			this.olvOther.EmptyListMsg = "no entries";
			this.olvOther.FullRowSelect = true;
			this.olvOther.Location = new System.Drawing.Point(3, 342);
			this.olvOther.Name = "olvOther";
			this.olvOther.ShowCommandMenuOnRightClick = true;
			this.olvOther.ShowGroups = false;
			this.olvOther.ShowHeaderInAllViews = false;
			this.olvOther.ShowImagesOnSubItems = true;
			this.olvOther.ShowItemToolTips = true;
			this.olvOther.Size = new System.Drawing.Size(383, 238);
			this.olvOther.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.olvOther.TabIndex = 12;
			this.olvOther.UseAlternatingBackColors = true;
			this.olvOther.UseCompatibleStateImageBehavior = false;
			this.olvOther.UseHotItem = true;
			this.olvOther.View = System.Windows.Forms.View.Details;
			// 
			// olvColumnName
			// 
			this.olvColumnName.AspectName = "Name";
			this.olvColumnName.IsTileViewColumn = true;
			this.olvColumnName.Text = "Name";
			this.olvColumnName.Width = 165;
			// 
			// olvColumnValue
			// 
			this.olvColumnValue.AspectName = "Value";
			this.olvColumnValue.IsTileViewColumn = true;
			this.olvColumnValue.Text = "Value";
			this.olvColumnValue.Width = 199;
			// 
			// lblNotes
			// 
			this.lblNotes.AutoSize = true;
			this.lblNotes.Location = new System.Drawing.Point(3, 153);
			this.lblNotes.Name = "lblNotes";
			this.lblNotes.Size = new System.Drawing.Size(35, 13);
			this.lblNotes.TabIndex = 10;
			this.lblNotes.Text = "Notes";
			// 
			// tbNotes
			// 
			this.tbNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbNotes.BackColor = System.Drawing.SystemColors.Window;
			this.tbNotes.Location = new System.Drawing.Point(3, 169);
			this.tbNotes.Multiline = true;
			this.tbNotes.Name = "tbNotes";
			this.tbNotes.ReadOnly = true;
			this.tbNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbNotes.Size = new System.Drawing.Size(383, 167);
			this.tbNotes.TabIndex = 11;
			// 
			// pbCopyUsernamePassword
			// 
			this.pbCopyUsernamePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pbCopyUsernamePassword.Image = global::TeamPassword.Library.Properties.Resources.userpass;
			this.pbCopyUsernamePassword.Location = new System.Drawing.Point(362, 139);
			this.pbCopyUsernamePassword.Name = "pbCopyUsernamePassword";
			this.pbCopyUsernamePassword.Size = new System.Drawing.Size(24, 24);
			this.pbCopyUsernamePassword.TabIndex = 13;
			this.pbCopyUsernamePassword.TabStop = false;
			this.toolTip1.SetToolTip(this.pbCopyUsernamePassword, resources.GetString("pbCopyUsernamePassword.ToolTip"));
			this.pbCopyUsernamePassword.Click += new System.EventHandler(this.pbCopyUsernamePassword_Click);
			this.pbCopyUsernamePassword.MouseEnter += new System.EventHandler(this.pbCopyUsernamePassword_MouseEnter);
			// 
			// tbExpiryDate
			// 
			this.tbExpiryDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbExpiryDate.BackColor = System.Drawing.Color.Transparent;
			this.tbExpiryDate.HidePasswordAfterSeconds = 0;
			this.tbExpiryDate.Location = new System.Drawing.Point(92, 107);
			this.tbExpiryDate.MaximumSize = new System.Drawing.Size(1000000000, 20);
			this.tbExpiryDate.MinimumSize = new System.Drawing.Size(50, 20);
			this.tbExpiryDate.Name = "tbExpiryDate";
			this.tbExpiryDate.ReadOnly = true;
			this.tbExpiryDate.Size = new System.Drawing.Size(294, 20);
			this.tbExpiryDate.TabIndex = 9;
			this.tbExpiryDate.UseSystemPasswordChar = false;
			// 
			// tbPassword
			// 
			this.tbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbPassword.BackColor = System.Drawing.Color.Transparent;
			this.tbPassword.HidePasswordAfterSeconds = 0;
			this.tbPassword.Location = new System.Drawing.Point(92, 55);
			this.tbPassword.MaximumSize = new System.Drawing.Size(1000000000, 20);
			this.tbPassword.MinimumSize = new System.Drawing.Size(50, 20);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.ReadOnly = true;
			this.tbPassword.Size = new System.Drawing.Size(294, 20);
			this.tbPassword.TabIndex = 5;
			this.tbPassword.UseSystemPasswordChar = false;
			// 
			// tbEmail
			// 
			this.tbEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbEmail.BackColor = System.Drawing.Color.Transparent;
			this.tbEmail.HidePasswordAfterSeconds = 0;
			this.tbEmail.Location = new System.Drawing.Point(92, 81);
			this.tbEmail.MaximumSize = new System.Drawing.Size(1000000000, 20);
			this.tbEmail.MinimumSize = new System.Drawing.Size(50, 20);
			this.tbEmail.Name = "tbEmail";
			this.tbEmail.ReadOnly = true;
			this.tbEmail.Size = new System.Drawing.Size(294, 20);
			this.tbEmail.TabIndex = 7;
			this.tbEmail.UseSystemPasswordChar = false;
			// 
			// tbUsername
			// 
			this.tbUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbUsername.BackColor = System.Drawing.Color.Transparent;
			this.tbUsername.HidePasswordAfterSeconds = 0;
			this.tbUsername.Location = new System.Drawing.Point(92, 29);
			this.tbUsername.MaximumSize = new System.Drawing.Size(1000000000, 20);
			this.tbUsername.MinimumSize = new System.Drawing.Size(50, 20);
			this.tbUsername.Name = "tbUsername";
			this.tbUsername.ReadOnly = true;
			this.tbUsername.Size = new System.Drawing.Size(294, 20);
			this.tbUsername.TabIndex = 3;
			this.tbUsername.UseSystemPasswordChar = false;
			// 
			// tbAccess
			// 
			this.tbAccess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbAccess.BackColor = System.Drawing.Color.Transparent;
			this.tbAccess.HidePasswordAfterSeconds = 0;
			this.tbAccess.Location = new System.Drawing.Point(92, 3);
			this.tbAccess.MaximumSize = new System.Drawing.Size(1000000000, 20);
			this.tbAccess.MinimumSize = new System.Drawing.Size(50, 20);
			this.tbAccess.Name = "tbAccess";
			this.tbAccess.ReadOnly = true;
			this.tbAccess.Size = new System.Drawing.Size(294, 20);
			this.tbAccess.TabIndex = 1;
			this.tbAccess.UseSystemPasswordChar = false;
			// 
			// Password
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.Controls.Add(this.pbCopyUsernamePassword);
			this.Controls.Add(this.tbExpiryDate);
			this.Controls.Add(this.tbPassword);
			this.Controls.Add(this.tbEmail);
			this.Controls.Add(this.tbUsername);
			this.Controls.Add(this.tbAccess);
			this.Controls.Add(this.tbNotes);
			this.Controls.Add(this.lblNotes);
			this.Controls.Add(this.olvOther);
			this.Controls.Add(this.lblPassword);
			this.Controls.Add(this.lblExpiryDate);
			this.Controls.Add(this.lblEmail);
			this.Controls.Add(this.lblUsername);
			this.Controls.Add(this.lblAccess);
			this.Name = "Password";
			this.Size = new System.Drawing.Size(389, 583);
			((System.ComponentModel.ISupportInitialize)(this.olvOther)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbCopyUsernamePassword)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.Label lblAccess;
		private System.Windows.Forms.Label lblUsername;
		private System.Windows.Forms.Label lblEmail;
		private System.Windows.Forms.Label lblExpiryDate;
		private System.Windows.Forms.Label lblPassword;
		private BrightIdeasSoftware.ObjectListView olvOther;
		private BrightIdeasSoftware.OLVColumn olvColumnName;
		private BrightIdeasSoftware.OLVColumn olvColumnValue;
		private System.Windows.Forms.Label lblNotes;
		private System.Windows.Forms.TextBox tbNotes;
		private TextBoxEx tbAccess;
		private TextBoxEx tbUsername;
		private TextBoxEx tbEmail;
		private TextBoxEx tbPassword;
		private TextBoxEx tbExpiryDate;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.PictureBox pbCopyUsernamePassword;
	}
}
