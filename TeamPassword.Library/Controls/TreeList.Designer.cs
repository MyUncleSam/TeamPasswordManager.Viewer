namespace TeamPassword.Library.Controls
{
    partial class TreeList
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
			this.tlvMain = new BrightIdeasSoftware.TreeListView();
			this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.lblFilter = new System.Windows.Forms.Label();
			this.tbFilter = new TeamPassword.Library.Controls.TextBoxFilterEx();
			((System.ComponentModel.ISupportInitialize)(this.tlvMain)).BeginInit();
			this.SuspendLayout();
			// 
			// tlvMain
			// 
			this.tlvMain.AllColumns.Add(this.olvColumn1);
			this.tlvMain.AlternateRowBackColor = System.Drawing.Color.AliceBlue;
			this.tlvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tlvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tlvMain.CellEditUseWholeCell = false;
			this.tlvMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1});
			this.tlvMain.Cursor = System.Windows.Forms.Cursors.Default;
			this.tlvMain.EmptyListMsg = "no entries";
			this.tlvMain.FullRowSelect = true;
			this.tlvMain.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.tlvMain.HideSelection = false;
			this.tlvMain.Location = new System.Drawing.Point(0, 26);
			this.tlvMain.MultiSelect = false;
			this.tlvMain.Name = "tlvMain";
			this.tlvMain.ShowGroups = false;
			this.tlvMain.ShowHeaderInAllViews = false;
			this.tlvMain.ShowImagesOnSubItems = true;
			this.tlvMain.Size = new System.Drawing.Size(371, 218);
			this.tlvMain.TabIndex = 2;
			this.tlvMain.UnfocusedSelectedBackColor = System.Drawing.SystemColors.ActiveCaption;
			this.tlvMain.UseCompatibleStateImageBehavior = false;
			this.tlvMain.UseFilterIndicator = true;
			this.tlvMain.UseFiltering = true;
			this.tlvMain.UseHotItem = true;
			this.tlvMain.View = System.Windows.Forms.View.Details;
			this.tlvMain.VirtualMode = true;
			this.tlvMain.SelectionChanged += new System.EventHandler(this.tlvMain_SelectionChanged);
			this.tlvMain.Resize += new System.EventHandler(this.tlvMain_Resize);
			// 
			// olvColumn1
			// 
			this.olvColumn1.AspectName = "Name";
			this.olvColumn1.Groupable = false;
			this.olvColumn1.IsEditable = false;
			this.olvColumn1.Text = "Name";
			this.olvColumn1.Width = 200;
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
			this.tbFilter.Size = new System.Drawing.Size(330, 20);
			this.tbFilter.TabIndex = 1;
			this.tbFilter.FilterChangedDelayed += new TeamPassword.Library.Controls.TextBoxFilterEx.TbFilterChanged(this.tbFilter_FilterChanged);
			// 
			// TreeList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.Controls.Add(this.tbFilter);
			this.Controls.Add(this.lblFilter);
			this.Controls.Add(this.tlvMain);
			this.Name = "TreeList";
			this.Size = new System.Drawing.Size(371, 244);
			((System.ComponentModel.ISupportInitialize)(this.tlvMain)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.TreeListView tlvMain;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
		private System.Windows.Forms.Label lblFilter;
		private TextBoxFilterEx tbFilter;
	}
}
