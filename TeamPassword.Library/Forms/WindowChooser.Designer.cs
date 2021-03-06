﻿namespace TeamPassword.Library.Forms
{
	partial class WindowChooser
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.olvMain = new BrightIdeasSoftware.ObjectListView();
            this.colName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colTitle = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvRecentlyUsed = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvSortString = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbSendReturn = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.olvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // olvMain
            // 
            this.olvMain.AllColumns.Add(this.colName);
            this.olvMain.AllColumns.Add(this.colTitle);
            this.olvMain.AllColumns.Add(this.olvRecentlyUsed);
            this.olvMain.AllColumns.Add(this.olvSortString);
            this.olvMain.AlternateRowBackColor = System.Drawing.Color.AliceBlue;
            this.olvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvMain.CellEditUseWholeCell = false;
            this.olvMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colTitle,
            this.olvRecentlyUsed});
            this.olvMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvMain.EmptyListMsg = "no entries";
            this.olvMain.FullRowSelect = true;
            this.olvMain.HideSelection = false;
            this.olvMain.Location = new System.Drawing.Point(-1, -1);
            this.olvMain.MultiSelect = false;
            this.olvMain.Name = "olvMain";
            this.olvMain.SelectAllOnControlA = false;
            this.olvMain.ShowCommandMenuOnRightClick = true;
            this.olvMain.ShowHeaderInAllViews = false;
            this.olvMain.ShowImagesOnSubItems = true;
            this.olvMain.ShowItemToolTips = true;
            this.olvMain.Size = new System.Drawing.Size(546, 324);
            this.olvMain.TabIndex = 0;
            this.olvMain.UnfocusedSelectedBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.olvMain.UseAlternatingBackColors = true;
            this.olvMain.UseCompatibleStateImageBehavior = false;
            this.olvMain.UseFilterIndicator = true;
            this.olvMain.UseFiltering = true;
            this.olvMain.UseHotItem = true;
            this.olvMain.View = System.Windows.Forms.View.Tile;
            this.olvMain.BeforeCreatingGroups += new System.EventHandler<BrightIdeasSoftware.CreateGroupsEventArgs>(this.OlvMain_BeforeCreatingGroups);
            this.olvMain.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.olvMain_CellClick);
            // 
            // colName
            // 
            this.colName.AspectName = "Name";
            this.colName.IsEditable = false;
            this.colName.IsTileViewColumn = true;
            this.colName.Text = "Name";
            this.colName.Width = 293;
            // 
            // colTitle
            // 
            this.colTitle.AspectName = "Title";
            this.colTitle.IsEditable = false;
            this.colTitle.IsTileViewColumn = true;
            this.colTitle.Text = "Title";
            this.colTitle.Width = 460;
            // 
            // olvRecentlyUsed
            // 
            this.olvRecentlyUsed.AspectName = "LastUsed";
            this.olvRecentlyUsed.IsEditable = false;
            this.olvRecentlyUsed.IsTileViewColumn = true;
            this.olvRecentlyUsed.Text = "Recently used";
            // 
            // olvSortString
            // 
            this.olvSortString.AspectName = "SortString";
            this.olvSortString.IsEditable = false;
            this.olvSortString.IsVisible = false;
            this.olvSortString.Text = "SortString";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(457, 337);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(376, 337);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbSendReturn
            // 
            this.cbSendReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSendReturn.AutoSize = true;
            this.cbSendReturn.Location = new System.Drawing.Point(263, 341);
            this.cbSendReturn.Name = "cbSendReturn";
            this.cbSendReturn.Size = new System.Drawing.Size(101, 17);
            this.cbSendReturn.TabIndex = 3;
            this.cbSendReturn.Text = "also send return";
            this.cbSendReturn.UseVisualStyleBackColor = true;
            // 
            // WindowChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(544, 372);
            this.Controls.Add(this.cbSendReturn);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.olvMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "WindowChooser";
            this.ShowInTaskbar = false;
            this.Text = "Choose a window";
            ((System.ComponentModel.ISupportInitialize)(this.olvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private BrightIdeasSoftware.ObjectListView olvMain;
		private BrightIdeasSoftware.OLVColumn colName;
		private BrightIdeasSoftware.OLVColumn colTitle;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox cbSendReturn;
        private BrightIdeasSoftware.OLVColumn olvRecentlyUsed;
        private BrightIdeasSoftware.OLVColumn olvSortString;
    }
}