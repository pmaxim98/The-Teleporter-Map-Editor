using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MapEditor.Entities;
using MapEditor.Utilities;

namespace TPMapEditor
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

			InitializeWindowSize();
			InitializeMenuStrip();
		}

		private void InitializeWindowSize()
		{
			Rectangle screen = Screen.PrimaryScreen.WorkingArea;
			int newWidth = Width >= screen.Width ? screen.Width : (screen.Width + Width) / 2;
			int newHeight = Height >= screen.Height ? screen.Height : (screen.Height + Height) / 2;
			Location = new Point((screen.Width - newWidth) / 2, (screen.Height - newHeight) / 2);
			Size = new Size(newWidth, newHeight);
		}

		private void InitializeMenuStrip()
		{
			foreach (ToolStripMenuItem menuItem in PrimaryContextMenuStrip.Items)
				((ToolStripDropDownMenu)menuItem.DropDown).ShowImageMargin = false;
			
			PrimaryContextMenuStrip.Renderer = new MapEditor.Forms.Renderers.GreenStripRenderer();
			PrimaryMapStatusStrip.Renderer = new MapEditor.Forms.Renderers.GreenStripRenderer();

			InitializeOpenDialog();
			InitializeSaveDialog();
		}

		private void InitializeOpenDialog()
		{
			OpenMapDialog.InitialDirectory = Utils.GetDefaultMapsFolderPath();
		}

		private void InitializeSaveDialog()
		{
			SaveFileMenuItem.Enabled = false;
			SaveAsFileMenuItem.Enabled = false;
			SaveMapDialog.InitialDirectory = Utils.GetDefaultMapsFolderPath();
		}

		private void NewFileMenuItem_Click(object sender, EventArgs e)
		{
			MapEditor.Forms.NewMapForm newMapForm = new MapEditor.Forms.NewMapForm();
			newMapForm.ShowDialog(this);

			if (newMapForm.Response == DialogResult.OK)
			{
				map = new Map
				{
					Background = newMapForm.MapData.Background,
					Tileset = newMapForm.MapData.Tileset,
					TileSize = newMapForm.MapData.TileSize,
					GridSize = new GridSize(newMapForm.MapData.GridSize.Height, newMapForm.MapData.GridSize.Width),
					FilePath = Path.Combine(Utils.GetDefaultMapsFolderPath(), "Unnamed")
				};

				map.ResetAllTiles();

				SaveFileMenuItem.Enabled = false;
				SaveAsFileMenuItem.Enabled = true;
			}
		}

		private void LoadFileMenuItem_Click(object sender, EventArgs e)
		{
			if (OpenMapDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					map = new Map();
					map.Load(OpenMapDialog.FileName);

					SaveFileMenuItem.Enabled = true;
					SaveAsFileMenuItem.Enabled = true;
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
			if (SaveMapDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					map.Save(SaveMapDialog.FileName);
					SaveFileMenuItem.Enabled = true;
				}
				catch (Exception exc)
				{
					MessageBox.Show(exc.Message, "Can't save the map!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void QuitFileMenuItem_Click(object sender, EventArgs e)
		{
			string message = "Are you sure you want to quit? Any unsaved changes will be lost.";
			if (MessageBox.Show(message, "Quit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				Close();
		}

		private Map map;
	}
}
