namespace TeamPassword.Library.Controls
{
	partial class TextBoxEx
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextBoxEx));
            this.ilMain = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pbSendApplication = new System.Windows.Forms.PictureBox();
            this.pbPassShowHide = new System.Windows.Forms.PictureBox();
            this.pbClipboard = new System.Windows.Forms.PictureBox();
            this.tbMain = new TeamPassword.Library.Controls.RichTextBoxEx();
            ((System.ComponentModel.ISupportInitialize)(this.pbSendApplication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPassShowHide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClipboard)).BeginInit();
            this.SuspendLayout();
            // 
            // ilMain
            // 
            this.ilMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilMain.ImageStream")));
            this.ilMain.TransparentColor = System.Drawing.Color.Transparent;
            this.ilMain.Images.SetKeyName(0, "clipboard");
            this.ilMain.Images.SetKeyName(1, "success");
            this.ilMain.Images.SetKeyName(2, "showhide");
            this.ilMain.Images.SetKeyName(3, "appsend");
            // 
            // pbSendApplication
            // 
            this.pbSendApplication.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSendApplication.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSendApplication.Location = new System.Drawing.Point(184, 4);
            this.pbSendApplication.Name = "pbSendApplication";
            this.pbSendApplication.Size = new System.Drawing.Size(16, 16);
            this.pbSendApplication.TabIndex = 3;
            this.pbSendApplication.TabStop = false;
            this.toolTip1.SetToolTip(this.pbSendApplication, "send text using sendkeys to a selected application");
            this.pbSendApplication.Click += new System.EventHandler(this.pbSendApplication_Click);
            this.pbSendApplication.MouseEnter += new System.EventHandler(this.picturebox_MouseEnter);
            // 
            // pbPassShowHide
            // 
            this.pbPassShowHide.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPassShowHide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPassShowHide.Location = new System.Drawing.Point(140, 2);
            this.pbPassShowHide.Name = "pbPassShowHide";
            this.pbPassShowHide.Size = new System.Drawing.Size(16, 16);
            this.pbPassShowHide.TabIndex = 2;
            this.pbPassShowHide.TabStop = false;
            this.toolTip1.SetToolTip(this.pbPassShowHide, "show/hide password");
            this.pbPassShowHide.Click += new System.EventHandler(this.pbPassShowHide_Click);
            this.pbPassShowHide.DoubleClick += new System.EventHandler(this.pbPassShowHide_Click);
            // 
            // pbClipboard
            // 
            this.pbClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbClipboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbClipboard.Location = new System.Drawing.Point(162, 2);
            this.pbClipboard.Name = "pbClipboard";
            this.pbClipboard.Size = new System.Drawing.Size(16, 16);
            this.pbClipboard.TabIndex = 1;
            this.pbClipboard.TabStop = false;
            this.toolTip1.SetToolTip(this.pbClipboard, "copy text to clipboard");
            this.pbClipboard.Click += new System.EventHandler(this.pbClipboard_Click);
            this.pbClipboard.MouseEnter += new System.EventHandler(this.picturebox_MouseEnter);
            // 
            // tbMain
            // 
            this.tbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMain.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tbMain.Location = new System.Drawing.Point(0, 0);
            this.tbMain.Name = "tbMain";
            this.tbMain.ReadOnly = false;
            this.tbMain.Size = new System.Drawing.Size(156, 20);
            this.tbMain.TabIndex = 0;
            this.tbMain.UseSystemPasswordChar = false;
            this.tbMain.TextChanged += new System.EventHandler(this.tbMain_TextChanged);
            // 
            // TextBoxEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pbSendApplication);
            this.Controls.Add(this.pbPassShowHide);
            this.Controls.Add(this.pbClipboard);
            this.Controls.Add(this.tbMain);
            this.MaximumSize = new System.Drawing.Size(1000000000, 20);
            this.MinimumSize = new System.Drawing.Size(50, 20);
            this.Name = "TextBoxEx";
            this.Size = new System.Drawing.Size(203, 20);
            ((System.ComponentModel.ISupportInitialize)(this.pbSendApplication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPassShowHide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClipboard)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private RichTextBoxEx tbMain;
		private System.Windows.Forms.PictureBox pbClipboard;
		private System.Windows.Forms.ImageList ilMain;
		private System.Windows.Forms.PictureBox pbPassShowHide;
		private System.Windows.Forms.PictureBox pbSendApplication;
		private System.Windows.Forms.ToolTip toolTip1;
	}
}
