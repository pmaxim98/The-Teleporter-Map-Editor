using System;
using System.IO;
using System.Windows.Controls;
using System.Linq;
using MapEditor.Utilities;

namespace MapEditor.WPF
{
	public partial class NewMapControl : UserControl
	{
		public event EventHandler CreateButtonClick;
		public event EventHandler CancelButtonClick;

		public NewMapControl()
		{
			InitializeComponent();

			SearchTilesets();
			SearchBackgrounds();
		}

		private void CancelButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			EventHandler handler = CancelButtonClick;

			if (handler != null)
			{
				handler(this, e);
			}
		}

		private void CreateButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			var handler = CreateButtonClick;

			if (handler != null)
			{
				handler(this, e);
			}
		}

		private void WidthBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			int oldLength = WidthBox.Text.Length;
			WidthBox.Text = Utils.FormatToNumericString(WidthBox.Text);

			if (oldLength > WidthBox.Text.Length)
			{
				WidthBox.CaretIndex++;
			}
			else if (oldLength < WidthBox.Text.Length)
			{
				WidthBox.CaretIndex--;
			}

			CheckButtonEnabling();
		}

		private void HeightBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			int oldLength = HeightBox.Text.Length;
			HeightBox.Text = Utils.FormatToNumericString(HeightBox.Text);

			if (oldLength > HeightBox.Text.Length)
			{
				HeightBox.CaretIndex++;
			}
			else if (oldLength < HeightBox.Text.Length)
			{
				HeightBox.CaretIndex--;
			}

			CheckButtonEnabling();
		}

		private void TileSizeBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			int oldLength = TileSizeBox.Text.Length;
			TileSizeBox.Text = Utils.FormatToNumericString(TileSizeBox.Text);

			if (oldLength > TileSizeBox.Text.Length)
			{
				TileSizeBox.CaretIndex++;
			}
			else if (oldLength < TileSizeBox.Text.Length)
			{
				TileSizeBox.CaretIndex--;
			}

			CheckButtonEnabling();
		}

		private void TilesetComboBox_DropDownOpened(object sender, EventArgs e)
		{
			SearchTilesets();
		}

		private void BackgroundComboBox_DropDownOpened(object sender, EventArgs e)
		{
			SearchBackgrounds();
		}

		private void SearchTilesets()
		{
			var currentDirectory = new DirectoryInfo(Utils.GetDefaultTilesetsFolderPath());
			var tilesetsDirsInCurrentDir = currentDirectory.GetDirectories();

			var queryTilesets = from dir in tilesetsDirsInCurrentDir
								from file in dir.GetFiles()
								where (file.Extension == ".xml" || file.Extension == ".png") && (file.Name == (dir.Name + file.Extension))
								select dir.Name;

			if (queryTilesets.Any())
			{
				foreach (var tilesetName in queryTilesets)
				{
					if (!TilesetComboBox.Items.Contains(tilesetName))
						TilesetComboBox.Items.Add(tilesetName);
				}
			}
			else
			{
				DisableComboBox(TilesetComboBox, "No tilesets found.");
			}

			CheckButtonEnabling();
		}

		private void SearchBackgrounds()
		{
			var currentDirectory = new DirectoryInfo(Utils.GetDefaultBackgroundsFolderPath());
			var backgroundsInCurrentDir = currentDirectory.GetFiles();
			var queryBackgrounds =	from backgroundFile in backgroundsInCurrentDir
									where (new[] { ".jpg", ".png", ".bmp" }).Contains(backgroundFile.Extension)
									select Path.GetFileNameWithoutExtension(backgroundFile.Name);

			if (queryBackgrounds.Any())
			{
				foreach (var backgroundName in queryBackgrounds)
				{
					if (!BackgroundComboBox.Items.Contains(backgroundName))
						BackgroundComboBox.Items.Add(backgroundName);
				}
			}
			else
			{
				DisableComboBox(BackgroundComboBox, "No backgrounds found.");
			}

			CheckButtonEnabling();
		}

		private void DisableComboBox(ComboBox comboBox, string message)
		{
			comboBox.IsEnabled = false;
			comboBox.Items.Clear();
			comboBox.Items.Add(message);
			comboBox.SelectedIndex = 0;
		}

		private void CheckButtonEnabling()
		{
			if (TileSizeBox.Text != string.Empty && 
				HeightBox.Text != string.Empty && 
				WidthBox.Text != string.Empty && 
				TilesetComboBox.IsEnabled &&
				BackgroundComboBox.IsEnabled)
			{
				CreateButton.IsEnabled = true;
			}
			else
			{
				CreateButton.IsEnabled = false;
			}
		}
	}
}