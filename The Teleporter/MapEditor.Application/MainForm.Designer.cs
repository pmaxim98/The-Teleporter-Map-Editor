namespace TPMapEditor
{
	partial class MainForm
	{
		private System.ComponentModel.IContainer components = null;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.PrimaryContextMenuStrip = new System.Windows.Forms.MenuStrip();
			this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.NewFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.LoadFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FirstFileMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.SaveFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SaveAsFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SecondFileMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.QuitFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.noMapLoadedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.OpenMapDialog = new System.Windows.Forms.OpenFileDialog();
			this.PrimaryMapStatusStrip = new System.Windows.Forms.StatusStrip();
			this.TitleStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.TilesetStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.BackgroundStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.SizeStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.TileSizeStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.SaveMapDialog = new System.Windows.Forms.SaveFileDialog();
			this.PrimaryContextMenuStrip.SuspendLayout();
			this.PrimaryMapStatusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// PrimaryContextMenuStrip
			// 
			this.PrimaryContextMenuStrip.BackColor = System.Drawing.SystemColors.Control;
			this.PrimaryContextMenuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.PrimaryContextMenuStrip.Font = new System.Drawing.Font("Segoe UI Light", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.PrimaryContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem});
			this.PrimaryContextMenuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.PrimaryContextMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.PrimaryContextMenuStrip.Name = "PrimaryContextMenuStrip";
			this.PrimaryContextMenuStrip.Padding = new System.Windows.Forms.Padding(0);
			this.PrimaryContextMenuStrip.Size = new System.Drawing.Size(984, 23);
			this.PrimaryContextMenuStrip.TabIndex = 0;
			this.PrimaryContextMenuStrip.Text = "MainMenuStrip";
			// 
			// FileMenuItem
			// 
			this.FileMenuItem.BackColor = System.Drawing.SystemColors.Control;
			this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewFileMenuItem,
            this.LoadFileMenuItem,
            this.FirstFileMenuSeparator,
            this.SaveFileMenuItem,
            this.SaveAsFileMenuItem,
            this.SecondFileMenuSeparator,
            this.QuitFileMenuItem});
			this.FileMenuItem.Name = "FileMenuItem";
			this.FileMenuItem.Size = new System.Drawing.Size(41, 23);
			this.FileMenuItem.Text = "File";
			// 
			// NewFileMenuItem
			// 
			this.NewFileMenuItem.Name = "NewFileMenuItem";
			this.NewFileMenuItem.Padding = new System.Windows.Forms.Padding(0);
			this.NewFileMenuItem.ShortcutKeyDisplayString = "Ctrl+N";
			this.NewFileMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.NewFileMenuItem.Size = new System.Drawing.Size(203, 22);
			this.NewFileMenuItem.Text = "New...";
			this.NewFileMenuItem.ToolTipText = "Click to create a new map.";
			this.NewFileMenuItem.Click += new System.EventHandler(this.NewFileMenuItem_Click);
			// 
			// LoadFileMenuItem
			// 
			this.LoadFileMenuItem.Name = "LoadFileMenuItem";
			this.LoadFileMenuItem.Padding = new System.Windows.Forms.Padding(0);
			this.LoadFileMenuItem.ShortcutKeyDisplayString = "Ctrl+O";
			this.LoadFileMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.LoadFileMenuItem.Size = new System.Drawing.Size(203, 22);
			this.LoadFileMenuItem.Text = "Load...";
			this.LoadFileMenuItem.ToolTipText = "Click to load a map.";
			this.LoadFileMenuItem.Click += new System.EventHandler(this.LoadFileMenuItem_Click);
			// 
			// FirstFileMenuSeparator
			// 
			this.FirstFileMenuSeparator.BackColor = System.Drawing.SystemColors.Control;
			this.FirstFileMenuSeparator.ForeColor = System.Drawing.SystemColors.Control;
			this.FirstFileMenuSeparator.Name = "FirstFileMenuSeparator";
			this.FirstFileMenuSeparator.Size = new System.Drawing.Size(200, 6);
			// 
			// SaveFileMenuItem
			// 
			this.SaveFileMenuItem.Name = "SaveFileMenuItem";
			this.SaveFileMenuItem.Padding = new System.Windows.Forms.Padding(0);
			this.SaveFileMenuItem.ShortcutKeyDisplayString = "Ctrl+S";
			this.SaveFileMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.SaveFileMenuItem.Size = new System.Drawing.Size(203, 22);
			this.SaveFileMenuItem.Text = "Save";
			this.SaveFileMenuItem.ToolTipText = "Click to save the current map.";
			this.SaveFileMenuItem.Click += new System.EventHandler(this.SaveFileMenuItem_Click);
			// 
			// SaveAsFileMenuItem
			// 
			this.SaveAsFileMenuItem.Name = "SaveAsFileMenuItem";
			this.SaveAsFileMenuItem.Padding = new System.Windows.Forms.Padding(0);
			this.SaveAsFileMenuItem.ShortcutKeyDisplayString = "Ctrl+Alt+S";
			this.SaveAsFileMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
			this.SaveAsFileMenuItem.Size = new System.Drawing.Size(203, 22);
			this.SaveAsFileMenuItem.Text = "Save As...";
			this.SaveAsFileMenuItem.ToolTipText = "Click to save the current map as...";
			this.SaveAsFileMenuItem.Click += new System.EventHandler(this.SaveAsFileMenuItem_Click);
			// 
			// SecondFileMenuSeparator
			// 
			this.SecondFileMenuSeparator.Name = "SecondFileMenuSeparator";
			this.SecondFileMenuSeparator.Size = new System.Drawing.Size(200, 6);
			// 
			// QuitFileMenuItem
			// 
			this.QuitFileMenuItem.BackColor = System.Drawing.SystemColors.Control;
			this.QuitFileMenuItem.Font = new System.Drawing.Font("Segoe UI Light", 9.5F);
			this.QuitFileMenuItem.Name = "QuitFileMenuItem";
			this.QuitFileMenuItem.Padding = new System.Windows.Forms.Padding(0);
			this.QuitFileMenuItem.ShortcutKeyDisplayString = "Ctrl+W";
			this.QuitFileMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
			this.QuitFileMenuItem.Size = new System.Drawing.Size(203, 22);
			this.QuitFileMenuItem.Text = "Quit";
			this.QuitFileMenuItem.ToolTipText = "Click to exit the map editor.";
			this.QuitFileMenuItem.Click += new System.EventHandler(this.QuitFileMenuItem_Click);
			// 
			// noMapLoadedToolStripMenuItem
			// 
			this.noMapLoadedToolStripMenuItem.Name = "noMapLoadedToolStripMenuItem";
			this.noMapLoadedToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
			this.noMapLoadedToolStripMenuItem.Text = "No map loaded.";
			// 
			// OpenMapDialog
			// 
			this.OpenMapDialog.DefaultExt = "tpm";
			this.OpenMapDialog.Filter = "The Teleporter Map (*.tpm)|*.tpm";
			this.OpenMapDialog.Title = "Load Map";
			this.OpenMapDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenMapDialog_FileOk);
			// 
			// PrimaryMapStatusStrip
			// 
			this.PrimaryMapStatusStrip.BackColor = System.Drawing.SystemColors.Control;
			this.PrimaryMapStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TitleStripStatusLabel,
            this.TilesetStripStatusLabel,
            this.BackgroundStripStatusLabel,
            this.SizeStripStatusLabel,
            this.TileSizeStripStatusLabel});
			this.PrimaryMapStatusStrip.Location = new System.Drawing.Point(0, 532);
			this.PrimaryMapStatusStrip.Name = "PrimaryMapStatusStrip";
			this.PrimaryMapStatusStrip.Size = new System.Drawing.Size(984, 29);
			this.PrimaryMapStatusStrip.SizingGrip = false;
			this.PrimaryMapStatusStrip.TabIndex = 1;
			this.PrimaryMapStatusStrip.Text = "statusStrip1";
			// 
			// TitleStripStatusLabel
			// 
			this.TitleStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
			this.TitleStripStatusLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.TitleStripStatusLabel.Margin = new System.Windows.Forms.Padding(1, 3, 0, 3);
			this.TitleStripStatusLabel.Name = "TitleStripStatusLabel";
			this.TitleStripStatusLabel.Size = new System.Drawing.Size(192, 23);
			this.TitleStripStatusLabel.Spring = true;
			this.TitleStripStatusLabel.Text = "Title:";
			// 
			// TilesetStripStatusLabel
			// 
			this.TilesetStripStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
			this.TilesetStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
			this.TilesetStripStatusLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.TilesetStripStatusLabel.Margin = new System.Windows.Forms.Padding(1, 3, 0, 3);
			this.TilesetStripStatusLabel.Name = "TilesetStripStatusLabel";
			this.TilesetStripStatusLabel.Size = new System.Drawing.Size(192, 23);
			this.TilesetStripStatusLabel.Spring = true;
			this.TilesetStripStatusLabel.Text = "Tileset:";
			// 
			// BackgroundStripStatusLabel
			// 
			this.BackgroundStripStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
			this.BackgroundStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
			this.BackgroundStripStatusLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.BackgroundStripStatusLabel.Margin = new System.Windows.Forms.Padding(1, 3, 0, 3);
			this.BackgroundStripStatusLabel.Name = "BackgroundStripStatusLabel";
			this.BackgroundStripStatusLabel.Size = new System.Drawing.Size(192, 23);
			this.BackgroundStripStatusLabel.Spring = true;
			this.BackgroundStripStatusLabel.Text = "Background:";
			// 
			// SizeStripStatusLabel
			// 
			this.SizeStripStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
			this.SizeStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
			this.SizeStripStatusLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.SizeStripStatusLabel.Margin = new System.Windows.Forms.Padding(1, 3, 0, 3);
			this.SizeStripStatusLabel.Name = "SizeStripStatusLabel";
			this.SizeStripStatusLabel.Size = new System.Drawing.Size(192, 23);
			this.SizeStripStatusLabel.Spring = true;
			this.SizeStripStatusLabel.Text = "Size:";
			// 
			// TileSizeStripStatusLabel
			// 
			this.TileSizeStripStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
			this.TileSizeStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
			this.TileSizeStripStatusLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.TileSizeStripStatusLabel.Margin = new System.Windows.Forms.Padding(1, 3, 0, 3);
			this.TileSizeStripStatusLabel.Name = "TileSizeStripStatusLabel";
			this.TileSizeStripStatusLabel.Size = new System.Drawing.Size(192, 23);
			this.TileSizeStripStatusLabel.Spring = true;
			this.TileSizeStripStatusLabel.Text = "Tile size:";
			// 
			// SaveMapDialog
			// 
			this.SaveMapDialog.DefaultExt = "tpm";
			this.SaveMapDialog.Filter = "The Teleporter Map (*.tpm)|*.tpm";
			this.SaveMapDialog.Title = "Save Map";
			this.SaveMapDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveMapDialog_FileOk);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.PrimaryMapStatusStrip);
			this.Controls.Add(this.PrimaryContextMenuStrip);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.PrimaryContextMenuStrip;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "The Teleporter - Map Editor";
			this.PrimaryContextMenuStrip.ResumeLayout(false);
			this.PrimaryContextMenuStrip.PerformLayout();
			this.PrimaryMapStatusStrip.ResumeLayout(false);
			this.PrimaryMapStatusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
		private System.Windows.Forms.ToolStripMenuItem QuitFileMenuItem;
		private System.Windows.Forms.MenuStrip PrimaryContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem NewFileMenuItem;
		private System.Windows.Forms.ToolStripMenuItem LoadFileMenuItem;
		private System.Windows.Forms.ToolStripSeparator FirstFileMenuSeparator;
		private System.Windows.Forms.ToolStripMenuItem SaveFileMenuItem;
		private System.Windows.Forms.ToolStripMenuItem SaveAsFileMenuItem;
		private System.Windows.Forms.ToolStripSeparator SecondFileMenuSeparator;
		private System.Windows.Forms.ToolStripMenuItem noMapLoadedToolStripMenuItem;
		private System.Windows.Forms.OpenFileDialog OpenMapDialog;
		private System.Windows.Forms.StatusStrip PrimaryMapStatusStrip;
		private System.Windows.Forms.ToolStripStatusLabel TitleStripStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel TilesetStripStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel BackgroundStripStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel SizeStripStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel TileSizeStripStatusLabel;
		private System.Windows.Forms.SaveFileDialog SaveMapDialog;
	}
}

