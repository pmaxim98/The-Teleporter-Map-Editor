using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPMapEditor
{
    public partial class MainForm : Form
    {
        Map map;
        public MainForm()
        {
            InitializeComponent();

            InitializeMap();

            InitializeWindowSize();
            InitializeMenuStrip();
            InitializeOpenDialog();
        }

        private void InitializeMap()
        {
            map = new Map();

            map.BackgroundChanged += Map_BackgroundChanged;
            map.TilesetChanged += Map_TilesetChanged;
            map.TitleChanged += Map_TitleChanged;
            map.TileSizeChanged += Map_TileSizeChanged;
            map.GridSizeChanged += Map_GridSizeChanged;

            Map_BackgroundChanged(map, EventArgs.Empty);
            Map_TilesetChanged(map, EventArgs.Empty);
            Map_TitleChanged(map, EventArgs.Empty);
            Map_TileSizeChanged(map, EventArgs.Empty);
            Map_GridSizeChanged(map, EventArgs.Empty);
        }

        private void Map_BackgroundChanged(object sender, EventArgs e)
        {
            BackgroundStripStatusLabel.Text = string.Format("Background: {0}", map.Background);
            PrimaryMapStatusStrip.Refresh();
        }

        private void Map_TilesetChanged(object sender, EventArgs e)
        {
            TilesetStripStatusLabel.Text = string.Format("Tileset: {0}", map.Tileset);
            PrimaryMapStatusStrip.Refresh();
        }

        private void Map_TitleChanged(object sender, EventArgs e)
        {
            TitleStripStatusLabel.Text = string.Format("Title: {0}", map.Title);
            PrimaryMapStatusStrip.Refresh();
        }

        private void Map_TileSizeChanged(object sender, EventArgs e)
        {
            TileSizeStripStatusLabel.Text = string.Format("Tile size: {0}", map.TileSize);
            PrimaryMapStatusStrip.Refresh();
        }

        private void Map_GridSizeChanged(object sender, EventArgs e)
        {
            SizeStripStatusLabel.Text = string.Format("Size: ({0} rows, {1} columns)", map.GridSize.Height, map.GridSize.Width);
            PrimaryMapStatusStrip.Refresh();
        }

        private void InitializeOpenDialog()
        {
            OpenMapDialog.AddExtension = true;
            OpenMapDialog.CheckFileExists = true;
            OpenMapDialog.CheckPathExists = true;
            OpenMapDialog.Filter = "The Teleporter Map (*.tpm)|*.tpm";
            OpenMapDialog.DefaultExt = "tpm";
            OpenMapDialog.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
            OpenMapDialog.Multiselect = false;
            OpenMapDialog.ReadOnlyChecked = false;
            OpenMapDialog.RestoreDirectory = true;
            OpenMapDialog.Title = "Load";
            OpenMapDialog.ValidateNames = true;
        }

        private void InitializeMenuStrip()
        {
            foreach (ToolStripMenuItem menuItem in PrimaryContextMenuStrip.Items)
                ((ToolStripDropDownMenu)menuItem.DropDown).ShowImageMargin = false;
            
            
            PrimaryContextMenuStrip.Renderer = new GreenStripRenderer();
            PrimaryMapStatusStrip.Renderer = new GreenStripRenderer();
        }

        private void InitializeWindowSize()
        {
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            int newWidth = Width >= screen.Width ? screen.Width : (screen.Width + Width) / 2;
            int newHeight = Height >= screen.Height ? screen.Height : (screen.Height + Height) / 2;
            Location = new Point((screen.Width - newWidth) / 2, (screen.Height - newHeight) / 2);
            Size = new Size(newWidth, newHeight);
        }

        private void QuitFileMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadFileMenuItem_Click(object sender, EventArgs e)
        {
            OpenMapDialog.ShowDialog();
        }

        private void OpenMapDialog_FileOk(object sender, CancelEventArgs e)
        {
            string[] fileLines = File.ReadAllLines(OpenMapDialog.FileName);

            map.Title = Path.GetFileNameWithoutExtension(OpenMapDialog.FileName);
            map.Tileset = fileLines[0];
            map.Background = fileLines[1];
            map.GridSize = new Size(Convert.ToInt32(fileLines[2].Split(' ')[0]), Convert.ToInt32(fileLines[2].Split(' ')[1]));
            map.TileSize = Convert.ToInt16(fileLines[3]);
        }
    }
}
