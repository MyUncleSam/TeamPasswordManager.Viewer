namespace TeamPassword.Viewer
{
	partial class TeamPasswordManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeamPasswordManager));
            this.aioMain = new TeamPassword.Library.Controls.AllInOne();
            this.SuspendLayout();
            // 
            // aioMain
            // 
            this.aioMain.BackColor = System.Drawing.SystemColors.Window;
            this.aioMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aioMain.HidePasswordsAfterSeconds = 0;
            this.aioMain.Location = new System.Drawing.Point(0, 0);
            this.aioMain.Name = "aioMain";
            this.aioMain.Size = new System.Drawing.Size(1325, 639);
            this.aioMain.TabIndex = 0;
            this.aioMain.ViewStyle = System.Windows.Forms.View.Details;
            // 
            // TeamPasswordManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1325, 639);
            this.Controls.Add(this.aioMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "TeamPasswordManager";
            this.Text = "TeamPasswordManager Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TeamPasswordManager_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TeamPasswordManager_KeyDown);
            this.ResumeLayout(false);

		}

		#endregion

		private Library.Controls.AllInOne aioMain;
	}
}