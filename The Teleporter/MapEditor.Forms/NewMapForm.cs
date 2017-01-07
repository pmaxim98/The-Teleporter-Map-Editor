using System.Windows.Forms;
using System.Drawing;

namespace MapEditor.Forms
{
	public partial class NewMapForm : Form
	{
		public DialogResult Response { get; private set; }
		public MapData MapData { get; private set; }

		public NewMapForm()
		{
			InitializeComponent();

			Response = DialogResult.Cancel;

			newMapControl.CancelButtonClick += (s, e) =>
			{
				Response = DialogResult.Cancel;
				Close();
			};

			newMapControl.CreateButtonClick += (s, e) =>
			{
				MapData = new MapData(
					((System.Windows.Controls.TextBox)newMapControl.FindName("WidthBox")).Text,
					((System.Windows.Controls.TextBox)newMapControl.FindName("HeightBox")).Text,
					((System.Windows.Controls.ComboBox)newMapControl.FindName("BackgroundComboBox")).Text,
					((System.Windows.Controls.ComboBox)newMapControl.FindName("TilesetComboBox")).Text,
					((System.Windows.Controls.TextBox)newMapControl.FindName("TileSizeBox")).Text
				);

				Response = DialogResult.OK;
				Close();
			};
		}
	}

	public class MapData
	{
		public string Background { get; private set; }
		public Size GridSize { get; private set; }
		public string Tileset { get; private set; }
		public short TileSize { get; private set; }

		public MapData(string width, string height, string background, string tileset, string tilesize)
		{
			Background = background;
			GridSize = new Size(int.Parse(width), int.Parse(height));
			Tileset = tileset;
			TileSize = short.Parse(tilesize);
		}
	}
}
