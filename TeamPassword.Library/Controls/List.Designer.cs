namespace TeamPassword.Library.Controls
{
    partial class List
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(List));
            this.olvMain = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnUsername = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnAccess = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnEmail = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvArchived = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ilList = new System.Windows.Forms.ImageList(this.components);
            this.columnButtonRenderer1 = new BrightIdeasSoftware.ColumnButtonRenderer();
            this.lblFilter = new System.Windows.Forms.Label();
            this.tbFilter = new TeamPassword.Library.Controls.TextBoxFilterEx();
            ((System.ComponentModel.ISupportInitialize)(this.olvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // olvMain
            // 
            this.olvMain.AllColumns.Add(this.olvColumnName);
            this.olvMain.AllColumns.Add(this.olvColumnUsername);
            this.olvMain.AllColumns.Add(this.olvColumnAccess);
            this.olvMain.AllColumns.Add(this.olvColumnEmail);
            this.olvMain.AllColumns.Add(this.olvArchived);
            this.olvMain.AllowColumnReorder = true;
            this.olvMain.AlternateRowBackColor = System.Drawing.Color.AliceBlue;
            this.olvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvMain.CellEditUseWholeCell = false;
            this.olvMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnName,
            this.olvColumnUsername,
            this.olvColumnAccess,
            this.olvColumnEmail,
            this.olvArchived});
            this.olvMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvMain.EmptyListMsg = "no entries";
            this.olvMain.FullRowSelect = true;
            this.olvMain.HideSelection = false;
            this.olvMain.LargeImageList = this.ilList;
            this.olvMain.Location = new System.Drawing.Point(0, 26);
            this.olvMain.MultiSelect = false;
            this.olvMain.Name = "olvMain";
            this.olvMain.RowHeight = 20;
            this.olvMain.ShowCommandMenuOnRightClick = true;
            this.olvMain.ShowGroups = false;
            this.olvMain.ShowHeaderInAllViews = false;
            this.olvMain.ShowImagesOnSubItems = true;
            this.olvMain.ShowItemToolTips = true;
            this.olvMain.Size = new System.Drawing.Size(663, 247);
            this.olvMain.SmallImageList = this.ilList;
            this.olvMain.TabIndex = 2;
            this.olvMain.TileSize = new System.Drawing.Size(168, 56);
            this.olvMain.UnfocusedSelectedBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.olvMain.UseAlternatingBackColors = true;
            this.olvMain.UseCompatibleStateImageBehavior = false;
            this.olvMain.UseFilterIndicator = true;
            this.olvMain.UseFiltering = true;
            this.olvMain.UseHotItem = true;
            this.olvMain.View = System.Windows.Forms.View.Details;
            this.olvMain.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.olvMain_CellRightClick);
            this.olvMain.SelectedIndexChanged += new System.EventHandler(this.olvMain_SelectedIndexChanged);
            // 
            // olvColumnName
            // 
            this.olvColumnName.AspectName = "name";
            this.olvColumnName.IsEditable = false;
            this.olvColumnName.IsTileViewColumn = true;
            this.olvColumnName.Text = "Name";
            this.olvColumnName.Width = 150;
            // 
            // olvColumnUsername
            // 
            this.olvColumnUsername.AspectName = "username";
            this.olvColumnUsername.IsEditable = false;
            this.olvColumnUsername.IsTileViewColumn = true;
            this.olvColumnUsername.Text = "Username";
            this.olvColumnUsername.Width = 150;
            // 
            // olvColumnAccess
            // 
            this.olvColumnAccess.AspectName = "access_info";
            this.olvColumnAccess.IsEditable = false;
            this.olvColumnAccess.IsTileViewColumn = true;
            this.olvColumnAccess.Text = "Access";
            this.olvColumnAccess.Width = 150;
            // 
            // olvColumnEmail
            // 
            this.olvColumnEmail.AspectName = "email";
            this.olvColumnEmail.IsEditable = false;
            this.olvColumnEmail.IsTileViewColumn = true;
            this.olvColumnEmail.Text = "E-Mail";
            this.olvColumnEmail.Width = 150;
            // 
            // olvArchived
            // 
            this.olvArchived.AspectName = "archived";
            this.olvArchived.IsEditable = false;
            this.olvArchived.IsTileViewColumn = true;
            this.olvArchived.Text = "";
            this.olvArchived.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvArchived.Width = 30;
            // 
            // ilList
            // 
            this.ilList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilList.ImageStream")));
            this.ilList.TransparentColor = System.Drawing.Color.Transparent;
            this.ilList.Images.SetKeyName(0, "archived");
            // 
            // columnButtonRenderer1
            // 
            this.columnButtonRenderer1.ButtonPadding = new System.Drawing.Size(10, 10);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(3, 3);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(29, 13);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Filter";
            // 
            // tbFilter
            // 
            this.tbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFilter.BackColor = System.Drawing.Color.Transparent;
            this.tbFilter.Location = new System.Drawing.Point(38, 0);
            this.tbFilter.MaximumSize = new System.Drawing.Size(1000000000, 20);
            this.tbFilter.MinimumSize = new System.Drawing.Size(50, 20);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.RecursiveCheckbox = false;
            this.tbFilter.Size = new System.Drawing.Size(622, 20);
            this.tbFilter.TabIndex = 1;
            this.tbFilter.FilterChangedDelayed += new TeamPassword.Library.Controls.TextBoxFilterEx.TbFilterChanged(this.tbFilter_FilterChanged);
            // 
            // List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.tbFilter);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.olvMain);
            this.Name = "List";
            this.Size = new System.Drawing.Size(663, 273);
            ((System.ComponentModel.ISupportInitialize)(this.olvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView olvMain;
		private BrightIdeasSoftware.OLVColumn olvColumnName;
		private BrightIdeasSoftware.OLVColumn olvColumnUsername;
		private BrightIdeasSoftware.OLVColumn olvColumnEmail;
		private BrightIdeasSoftware.OLVColumn olvColumnAccess;
		private BrightIdeasSoftware.ColumnButtonRenderer columnButtonRenderer1;
		private System.Windows.Forms.Label lblFilter;
		private TextBoxFilterEx tbFilter;
        private BrightIdeasSoftware.OLVColumn olvArchived;
        private System.Windows.Forms.ImageList ilList;
    }
}
