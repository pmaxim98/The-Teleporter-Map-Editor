using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using Newtonsoft.Json.Linq;

namespace MapEditor.Entities
{
	public class Tileset
	{
		public bool Load(string folderPath)
		{
			var tilesetFilesPath = QueryTilesetFiles(folderPath);

			if (!tilesetFilesPath.Item1)
				return false;

			tilesetImage = new Bitmap(tilesetFilesPath.Item2);
			
			// to be implemented...
		}

		public short TileSize
		{
			get
			{
				return (short)(tilesetImage.Width / TotalTilesPerRow);
			}
		}

		private Tuple<bool, string, string> QueryTilesetFiles(string folderPath)
		{
			string tilesetName = Path.GetDirectoryName(folderPath);

			string tilesetImagePath = Directory.EnumerateFiles(folderPath)
				.Where(file => (Path.GetFileNameWithoutExtension(file) == tilesetName) &&
					(new[] { "png", "jpg", "bmp" })
						.Any(x => file.EndsWith(x, StringComparison.OrdinalIgnoreCase)))
				.FirstOrDefault();

			string tilesetDataPath = Directory.EnumerateFiles(folderPath)
				.Where(file => (Path.GetFileNameWithoutExtension(file) == tilesetName) &&
					(new[] { "json" })
						.Any(x => file.EndsWith(x, StringComparison.OrdinalIgnoreCase)))
				.FirstOrDefault();

			if (string.IsNullOrWhiteSpace(tilesetImagePath) || string.IsNullOrWhiteSpace(tilesetDataPath))
				return Tuple.Create(false, string.Empty, string.Empty);

			return Tuple.Create(true, tilesetImagePath, tilesetDataPath);
		}

		private Bitmap tilesetImage;
		private const short TotalTilesPerRow = 4;
	}
}
