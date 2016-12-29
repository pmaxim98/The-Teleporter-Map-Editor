using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
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
			InitializeSaveDialog();
		}

		private void InitializeMap()
		{
			map = new Map();

			map.PropertyChanged += (sender, e) =>
			{
				switch (e.PropertyName)
				{
					case "Background":
						BackgroundStripStatusLabel.Text = string.Format("Background: {0}", map.Background);
						break;
					case "GridSize":
						SizeStripStatusLabel.Text = string.Format("Size: ({0} rows, {1} columns)", map.GridSize.Height, map.GridSize.Width);
						break;
					case "Tileset":
						TilesetStripStatusLabel.Text = string.Format("Tileset: {0}", map.Tileset);
						break;
					case "TileSize":
						TileSizeStripStatusLabel.Text = string.Format("Tile size: {0}", map.TileSize);
						break;
					case "FilePath":
						TitleStripStatusLabel.Text = string.Format("Title: {0}", map.Title != string.Empty ? map.Title : "Temp");
						break;
					default:
						break;
				}

				PrimaryMapStatusStrip.Refresh();
			};
		}

		private void InitializeOpenDialog()
		{
			OpenMapDialog.InitialDirectory = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory.ToString(), "Maps");
		}

		private void InitializeSaveDialog()
		{
			SaveMapDialog.InitialDirectory = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory.ToString(), "Maps");
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

		private void NewFileMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void LoadFileMenuItem_Click(object sender, EventArgs e)
		{
			OpenMapDialog.ShowDialog();
		}

		private void SaveFileMenuItem_Click(object sender, EventArgs e)
		{
			if (map.FilePath == string.Empty || !File.Exists(map.FilePath))
			{
				SaveAsFileMenuItem_Click(sender, e);
			}
			else
			{
				try
				{
					map.Save(map.FilePath);
				}
				catch (Exception exc)
				{
					MessageBox.Show(exc.Message, "Can't save the map!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void SaveAsFileMenuItem_Click(object sender, EventArgs e)
		{
			SaveMapDialog.ShowDialog();
		}

		private void QuitFileMenuItem_Click(object sender, EventArgs e)
		{
			string message = "Are you sure you want to quit? Any unsaved changes will be lost.";
			DialogResult result = MessageBox.Show(message, "Quit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				Close();
			}
		}

		private void OpenMapDialog_FileOk(object sender, CancelEventArgs e)
		{
			try
			{
				map.Load(OpenMapDialog.FileName);
			}
			catch (Exception exc)
			{
				string[] exceptionMessage = exc.Message.Split(new string[] { "Parameter name: " }, StringSplitOptions.None);

				if (exceptionMessage.Length <= 1)
				{
					MessageBox.Show("Invalid map format used: " + exceptionMessage[0], "Can't load the map!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					MessageBox.Show(exceptionMessage[1], "Can't load the map!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void SaveMapDialog_FileOk(object sender, CancelEventArgs e)
		{
			try
			{
				map.Save(SaveMapDialog.FileName);
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message, "Can't save the map!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
