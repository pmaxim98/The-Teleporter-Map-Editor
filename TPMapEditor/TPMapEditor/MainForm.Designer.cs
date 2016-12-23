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
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuitFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FirstFileMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.SecondFileMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.noMapLoadedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.Color.LimeGreen;
            this.MenuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MenuStrip.Font = new System.Drawing.Font("Segoe UI Light", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem});
            this.MenuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Padding = new System.Windows.Forms.Padding(0);
            this.MenuStrip.Size = new System.Drawing.Size(984, 23);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "MainMenuStrip";
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.BackColor = System.Drawing.Color.LimeGreen;
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
            // QuitFileMenuItem
            // 
            this.QuitFileMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.QuitFileMenuItem.Font = new System.Drawing.Font("Segoe UI Light", 9.5F);
            this.QuitFileMenuItem.Name = "QuitFileMenuItem";
            this.QuitFileMenuItem.Size = new System.Drawing.Size(152, 24);
            this.QuitFileMenuItem.Text = "Quit";
            this.QuitFileMenuItem.ToolTipText = "Click to exit the map editor.";
            this.QuitFileMenuItem.Click += new System.EventHandler(this.QuitFileMenuItem_Click);
            // 
            // NewFileMenuItem
            // 
            this.NewFileMenuItem.Name = "NewFileMenuItem";
            this.NewFileMenuItem.Size = new System.Drawing.Size(152, 24);
            this.NewFileMenuItem.Text = "New...";
            // 
            // LoadFileMenuItem
            // 
            this.LoadFileMenuItem.Name = "LoadFileMenuItem";
            this.LoadFileMenuItem.Size = new System.Drawing.Size(152, 24);
            this.LoadFileMenuItem.Text = "Load...";
            // 
            // SaveFileMenuItem
            // 
            this.SaveFileMenuItem.Name = "SaveFileMenuItem";
            this.SaveFileMenuItem.Size = new System.Drawing.Size(152, 24);
            this.SaveFileMenuItem.Text = "Save";
            // 
            // SaveAsFileMenuItem
            // 
            this.SaveAsFileMenuItem.Name = "SaveAsFileMenuItem";
            this.SaveAsFileMenuItem.Size = new System.Drawing.Size(152, 24);
            this.SaveAsFileMenuItem.Text = "Save As...";
            // 
            // FirstFileMenuSeparator
            // 
            this.FirstFileMenuSeparator.BackColor = System.Drawing.SystemColors.Control;
            this.FirstFileMenuSeparator.ForeColor = System.Drawing.SystemColors.Control;
            this.FirstFileMenuSeparator.Name = "FirstFileMenuSeparator";
            this.FirstFileMenuSeparator.Size = new System.Drawing.Size(149, 6);
            // 
            // SecondFileMenuSeparator
            // 
            this.SecondFileMenuSeparator.Name = "SecondFileMenuSeparator";
            this.SecondFileMenuSeparator.Size = new System.Drawing.Size(149, 6);
            // 
            // noMapLoadedToolStripMenuItem
            // 
            this.noMapLoadedToolStripMenuItem.Name = "noMapLoadedToolStripMenuItem";
            this.noMapLoadedToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.noMapLoadedToolStripMenuItem.Text = "No map loaded.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.MenuStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The Teleporter - Map Editor";
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QuitFileMenuItem;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem NewFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadFileMenuItem;
        private System.Windows.Forms.ToolStripSeparator FirstFileMenuSeparator;
        private System.Windows.Forms.ToolStripMenuItem SaveFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsFileMenuItem;
        private System.Windows.Forms.ToolStripSeparator SecondFileMenuSeparator;
        private System.Windows.Forms.ToolStripMenuItem noMapLoadedToolStripMenuItem;
    }
}

