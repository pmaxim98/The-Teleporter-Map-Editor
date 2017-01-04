using System.Windows;
using System.Windows.Controls;

namespace MapEditor.WPF
{
	public class MapData
	{
		public MapData(Size GridSize, string Tileset, string Background, short TileSize)
		{
			this.GridSize = GridSize;
			this.Tileset = Tileset;
			this.Background = Background;
			this.TileSize = TileSize;
		}

		public Size GridSize { get; set; }
		public string Tileset { get; set; }
		public string Background { get; set; }
		public short TileSize { get; set; }
	}

	public partial class NewMapControl : UserControl
	{
		private MapData mapData;

		public MapData Mapdata { get { return mapData; } }

		public NewMapControl()
		{
			InitializeComponent();

			//foreach (var dir in System.IO.Directory.EnumerateFiles())
			//TilesetComboBox.Items.Add();
		}

		private void CreateButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			//mapData = new MapData(new Size(int.Parse(WidthBox.Text), int.Parse(HeightBox.Text)), TilesetComboBox.Text, BackgroundComboBox.Text, short.Parse(TileSizeBox.Text));
		}

		private static string FormatToNumericString(string normalString)
		{
			string formattedText = string.Empty;

			foreach (char ch in normalString)
			{
				if (char.IsDigit(ch))
					formattedText += ch;
			}

			return formattedText;
		}

		private void WidthBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			WidthBox.Text = FormatToNumericString(WidthBox.Text);
			WidthBox.CaretIndex = WidthBox.Text.Length;
		}

		private void HeightBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			HeightBox.Text = FormatToNumericString(HeightBox.Text);
			HeightBox.CaretIndex = HeightBox.Text.Length;
		}

		private void TileSizeBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			TileSizeBox.Text = FormatToNumericString(TileSizeBox.Text);
			TileSizeBox.CaretIndex = TileSizeBox.Text.Length;
		}
	}
}