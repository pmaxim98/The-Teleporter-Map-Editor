namespace MapEditor.Forms
{
	partial class NewMapForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewMapForm));
			this.NewMapElementHost = new System.Windows.Forms.Integration.ElementHost();
			this.newMapControl = new MapEditor.WPF.NewMapControl();
			this.SuspendLayout();
			// 
			// NewMapElementHost
			// 
			this.NewMapElementHost.Dock = System.Windows.Forms.DockStyle.Fill;
			this.NewMapElementHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.NewMapElementHost.Location = new System.Drawing.Point(0, 0);
			this.NewMapElementHost.Name = "NewMapElementHost";
			this.NewMapElementHost.Size = new System.Drawing.Size(320, 200);
			this.NewMapElementHost.TabIndex = 0;
			this.NewMapElementHost.Text = "NewMapElementHost";
			this.NewMapElementHost.Child = this.newMapControl;
			// 
			// NewMapForm
			// 
			this.ClientSize = new System.Drawing.Size(320, 200);
			this.Controls.Add(this.NewMapElementHost);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NewMapForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Create a new map";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Integration.ElementHost NewMapElementHost;
		private WPF.NewMapControl newMapControl;
	}
}