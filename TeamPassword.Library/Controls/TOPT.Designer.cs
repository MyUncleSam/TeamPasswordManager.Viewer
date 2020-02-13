namespace TeamPassword.Library.Controls
{
    partial class TOPT
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
            this.pbMain = new System.Windows.Forms.ProgressBar();
            this.tMain = new System.Windows.Forms.Timer(this.components);
            this.lblTotp = new System.Windows.Forms.Label();
            this.lblTimeRemaining = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pbMain
            // 
            this.pbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMain.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.pbMain.Location = new System.Drawing.Point(0, 0);
            this.pbMain.Maximum = 30;
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(88, 8);
            this.pbMain.TabIndex = 0;
            // 
            // tMain
            // 
            this.tMain.Interval = 1000;
            this.tMain.Tick += new System.EventHandler(this.TMain_Tick);
            // 
            // lblTotp
            // 
            this.lblTotp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotp.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTotp.Location = new System.Drawing.Point(0, 8);
            this.lblTotp.Name = "lblTotp";
            this.lblTotp.Size = new System.Drawing.Size(70, 21);
            this.lblTotp.TabIndex = 1;
            this.lblTotp.Text = "123 456";
            this.lblTotp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTotp.Click += new System.EventHandler(this.LblTotp_Click);
            // 
            // lblTimeRemaining
            // 
            this.lblTimeRemaining.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimeRemaining.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblTimeRemaining.Location = new System.Drawing.Point(67, 8);
            this.lblTimeRemaining.Name = "lblTimeRemaining";
            this.lblTimeRemaining.Size = new System.Drawing.Size(21, 21);
            this.lblTimeRemaining.TabIndex = 2;
            this.lblTimeRemaining.Text = "99";
            this.lblTimeRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TOPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblTimeRemaining);
            this.Controls.Add(this.lblTotp);
            this.Controls.Add(this.pbMain);
            this.MaximumSize = new System.Drawing.Size(500, 500);
            this.MinimumSize = new System.Drawing.Size(64, 18);
            this.Name = "TOPT";
            this.Size = new System.Drawing.Size(88, 28);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbMain;
        private System.Windows.Forms.Timer tMain;
        private System.Windows.Forms.Label lblTotp;
        private System.Windows.Forms.Label lblTimeRemaining;
    }
}
