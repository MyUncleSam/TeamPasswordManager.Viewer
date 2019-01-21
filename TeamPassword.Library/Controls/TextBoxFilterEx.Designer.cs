namespace TeamPassword.Library.Controls
{
	partial class TextBoxFilterEx
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextBoxFilterEx));
			this.ilMain = new System.Windows.Forms.ImageList(this.components);
			this.tbMain = new System.Windows.Forms.TextBox();
			this.pbClear = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pbClear)).BeginInit();
			this.SuspendLayout();
			// 
			// ilMain
			// 
			this.ilMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilMain.ImageStream")));
			this.ilMain.TransparentColor = System.Drawing.Color.Transparent;
			this.ilMain.Images.SetKeyName(0, "delete");
			// 
			// tbMain
			// 
			this.tbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbMain.Location = new System.Drawing.Point(0, 0);
			this.tbMain.Name = "tbMain";
			this.tbMain.Size = new System.Drawing.Size(150, 20);
			this.tbMain.TabIndex = 0;
			this.tbMain.TextChanged += new System.EventHandler(this.tbMain_TextChanged);
			// 
			// pbClear
			// 
			this.pbClear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pbClear.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pbClear.Location = new System.Drawing.Point(156, 2);
			this.pbClear.Name = "pbClear";
			this.pbClear.Size = new System.Drawing.Size(16, 16);
			this.pbClear.TabIndex = 3;
			this.pbClear.TabStop = false;
			this.pbClear.Click += new System.EventHandler(this.pbClear_Click);
			// 
			// TextBoxFilterEx
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.pbClear);
			this.Controls.Add(this.tbMain);
			this.MaximumSize = new System.Drawing.Size(1000000000, 20);
			this.MinimumSize = new System.Drawing.Size(50, 20);
			this.Name = "TextBoxFilterEx";
			this.Size = new System.Drawing.Size(172, 20);
			((System.ComponentModel.ISupportInitialize)(this.pbClear)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ImageList ilMain;
		private System.Windows.Forms.PictureBox pbClear;
		private System.Windows.Forms.TextBox tbMain;
	}
}
