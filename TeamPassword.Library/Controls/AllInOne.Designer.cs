namespace TeamPassword.Library.Controls
{
	partial class AllInOne
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
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.scDetails = new System.Windows.Forms.SplitContainer();
            this.cbViewStyle = new System.Windows.Forms.ComboBox();
            this.treeList = new TeamPassword.Library.Controls.TreeList();
            this.passwordList = new TeamPassword.Library.Controls.List();
            this.passwordDetails = new TeamPassword.Library.Controls.Password();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scDetails)).BeginInit();
            this.scDetails.Panel1.SuspendLayout();
            this.scDetails.Panel2.SuspendLayout();
            this.scDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // scMain
            // 
            this.scMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.treeList);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.scDetails);
            this.scMain.Size = new System.Drawing.Size(1170, 577);
            this.scMain.SplitterDistance = 240;
            this.scMain.TabIndex = 0;
            // 
            // scDetails
            // 
            this.scDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scDetails.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scDetails.Location = new System.Drawing.Point(0, 0);
            this.scDetails.Name = "scDetails";
            // 
            // scDetails.Panel1
            // 
            this.scDetails.Panel1.Controls.Add(this.cbViewStyle);
            this.scDetails.Panel1.Controls.Add(this.passwordList);
            // 
            // scDetails.Panel2
            // 
            this.scDetails.Panel2.Controls.Add(this.passwordDetails);
            this.scDetails.Size = new System.Drawing.Size(926, 577);
            this.scDetails.SplitterDistance = 487;
            this.scDetails.TabIndex = 0;
            // 
            // cbViewStyle
            // 
            this.cbViewStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbViewStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbViewStyle.FormattingEnabled = true;
            this.cbViewStyle.Items.AddRange(new object[] {
            "Small Icon",
            "Large Icon",
            "List",
            "Tile",
            "Details"});
            this.cbViewStyle.Location = new System.Drawing.Point(343, 551);
            this.cbViewStyle.Name = "cbViewStyle";
            this.cbViewStyle.Size = new System.Drawing.Size(141, 21);
            this.cbViewStyle.TabIndex = 1;
            this.cbViewStyle.SelectedIndexChanged += new System.EventHandler(this.cbViewStyle_SelectedIndexChanged);
            // 
            // treeList
            // 
            this.treeList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeList.BackColor = System.Drawing.SystemColors.Window;
            this.treeList.Location = new System.Drawing.Point(-1, 3);
            this.treeList.Name = "treeList";
            this.treeList.Size = new System.Drawing.Size(240, 573);
            this.treeList.TabIndex = 0;
            this.treeList.TreeSelectionChanged += new TeamPassword.Library.Controls.TreeSelectionChanged(this.treeList_SelectionChanged);
            // 
            // passwordList
            // 
            this.passwordList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordList.BackColor = System.Drawing.SystemColors.Window;
            this.passwordList.Location = new System.Drawing.Point(-1, 3);
            this.passwordList.Name = "passwordList";
            this.passwordList.Size = new System.Drawing.Size(487, 543);
            this.passwordList.TabIndex = 0;
            this.passwordList.ViewStyle = System.Windows.Forms.View.Details;
            this.passwordList.ListSelectionChanged += new TeamPassword.Library.Controls.ListSelectionChanged(this.passwordList_ListSelectionChanged);
            // 
            // passwordDetails
            // 
            this.passwordDetails.BackColor = System.Drawing.SystemColors.Window;
            this.passwordDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.passwordDetails.Enabled = false;
            this.passwordDetails.HidePasswordsAfterSeconds = 1;
            this.passwordDetails.Location = new System.Drawing.Point(0, 0);
            this.passwordDetails.Name = "passwordDetails";
            this.passwordDetails.PasswordEntry = null;
            this.passwordDetails.Size = new System.Drawing.Size(433, 575);
            this.passwordDetails.TabIndex = 0;
            // 
            // AllInOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.scMain);
            this.Name = "AllInOne";
            this.Size = new System.Drawing.Size(1170, 577);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.scDetails.Panel1.ResumeLayout(false);
            this.scDetails.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scDetails)).EndInit();
            this.scDetails.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer scMain;
		private TreeList treeList;
		private System.Windows.Forms.SplitContainer scDetails;
		private List passwordList;
		private Password passwordDetails;
        private System.Windows.Forms.ComboBox cbViewStyle;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
