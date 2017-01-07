using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Drawing;

namespace MapEditor.Entities
{
	public class Map : INotifyPropertyChanged
	{
		/// <summary>
		/// Constructs a map with a basic structure.
		/// </summary>
		public Map()
		{
			TileSize = 50;
			GridSize = new Size(5, 5);
			FilePath = string.Empty;
			Background = "Unnamed";
			Tileset = "Unnamed";
			ResetAllTiles();
		}

		/// <summary>
		/// Re-initializes all the tiles and sets them to the first tile of the tileset.
		/// </summary>
		public void ResetAllTiles()
		{
			Tiles = new Tile[GridSize.Height, GridSize.Width];

			for (int row = 0; row < GridSize.Height; ++row)
			{
				for (int column = 0; column < GridSize.Width; ++column)
				{
					Tiles[row, column] = new Tile();
				}
			}
		}

		/// <summary>
		/// Gets the map's absolute file path (so the file name and extension is included).
		/// </summary>
		public string FilePath
		{
			get { return path; }
			set
			{
				path = value;
				OnPropertyChanged();
			}
		}

		/// <summary>
		/// Gets the size of a tile in pixels. All the tiles of the map will always have the same size.
		/// </summary>
		/// <returns>Returns the size in pixels.</returns>
		public short TileSize
		{
			get { return tileSize; }
			set
			{
				if (value <= 0)
					throw new ArgumentException("Invalid tile size.");

				tileSize = value;
				OnPropertyChanged();
			}
		}

		/// <summary>
		/// Gets the size of the map in terms of columns and rows.
		/// </summary>
		/// <returns>Returns a Size struct that contains the number of rows (height) and the number of columns (width) of the map.</returns>
		public Size GridSize
		{
			get { return gridSize; }
			set
			{
				if (value.Width <= 0 || value.Height <= 0)
					throw new ArgumentException("Invalid map size.");

				gridSize = value;
				OnPropertyChanged();
			}
		}

		/// <summary>
		/// Gets the name of the background (NOT the path of it).
		/// </summary>
		/// <returns>Returns a string with the background's name.</returns>
		public string Background
		{
			get { return background; }
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("Background's string is null.");

				background = value;
				OnPropertyChanged();
			}
		}

		/// <summary>
		/// Gets the name of the tileset (NOT the path of it).
		/// </summary>
		/// <returns>Returns a string with the tileset's name.</returns>
		public string Tileset
		{
			get { return tileset; }
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("Tileset's string is null.");

				tileset = value;
				OnPropertyChanged();
			}
		}

		/// <summary>
		/// Gets the size of the map in terms of pixels.
		/// </summary>
		/// <example> 
		/// A map with a GridSize of 30x40 (30 rows, 40 columns) and a TileSize of 10 (pixels) will return a Size struct of 300x400 (pixels).
		/// </example>
		/// <returns>Returns a Size struct that contains the number of rows (height) and the number of columns (width) of the map.</returns>
		public Size Size
		{
			get { return new Size(GridSize.Height * TileSize, GridSize.Width * TileSize); }
		}

		/// <summary>
		/// Gets the title (name) of the map.
		/// </summary>
		/// <returns>Returns a string that contains the map's title (name).</returns>
		public string Title
		{
			get { return Path.GetFileNameWithoutExtension(path); }
		}

		public Tile[,] Tiles { get; set; }

		/// <summary>
		/// Loads the map by using the absolute path of the map file.
		/// </summary>
		/// <param name="absolutePath">The absolute path of the map file.</param>
		public void Load(string absolutePath)
		{
			string filePath = absolutePath;

			string[] fileLines = File.ReadAllLines(filePath);
			int totalLines = fileLines.Length;

			Size gridSize = new Size(
				Convert.ToInt32(fileLines[FileLineWithProperty.GridSize].Split(' ')[1]), 
				Convert.ToInt32(fileLines[FileLineWithProperty.GridSize].Split(' ')[0])
			);

			if (totalLines != gridSize.Height + FileLineWithProperty.Total)
				throw new ArgumentOutOfRangeException("The map has more or less rows of tiles (" + (totalLines - FileLineWithProperty.Total) +
													  ") than it's initially specified height (" + gridSize.Height + ").");

			Tile[,] tiles = new Tile[gridSize.Height, gridSize.Width];

			string tileset = fileLines[FileLineWithProperty.Tileset];
			string background = fileLines[FileLineWithProperty.Background];
			short tileSize = Convert.ToInt16(fileLines[FileLineWithProperty.TileSize]);

			int totalProperties = 3;
			for (int row = 0; row < gridSize.Height; ++row)
			{
				int currentLine = row + FileLineWithProperty.Total;
				string[] tilesToBeParsed = fileLines[currentLine].Split(new[] { ' ', ',', ';', '(', ')', '[', ']', '{', '}' }, StringSplitOptions.RemoveEmptyEntries);

				if (gridSize.Width * totalProperties != tilesToBeParsed.Length)
					throw new ArgumentOutOfRangeException("The map has more or less tiles per row (" + (tilesToBeParsed.Length / totalProperties) +
														  ") than it's initially specified row's width (" + gridSize.Width + "), " +
														  "either it has invalid separators used in delimiting the tiles.");

				for (int column = 0; column < gridSize.Width; ++column)
				{
					int firstPropertyColumn = column * totalProperties;

					tiles[row, column] = new Tile();
					tiles[row, column].PropertiesID = Convert.ToByte(tilesToBeParsed[firstPropertyColumn]);
					tiles[row, column].Damage = Convert.ToInt16(tilesToBeParsed[firstPropertyColumn + 1]);
					tiles[row, column].Solidity = (Solidity)Convert.ToInt32(tilesToBeParsed[firstPropertyColumn + 2]);
				}
			}

			FilePath = filePath;
			GridSize = gridSize;
			Tiles = tiles;
			Tileset = tileset;
			Background = background;
			TileSize = tileSize;
		}

		public void Save(string absolutePath)
		{
			using (StreamWriter writer = new StreamWriter(absolutePath))
			{
				writer.WriteLine(string.Join(" ", GridSize.Height, GridSize.Width));
				writer.WriteLine(Tileset);
				writer.WriteLine(Background);
				writer.WriteLine(TileSize);

				for (int row = 0; row < GridSize.Height; ++row)
				{
					for (int column = 0; column < GridSize.Width; ++column)
					{
						writer.Write(Tiles[row, column]);
					}
					writer.Write(Environment.NewLine);
				}
			}

			FilePath = absolutePath;
		}

		struct FileLineWithProperty
		{
			public const int GridSize = 0;
			public const int Tileset = 1;
			public const int Background = 2;
			public const int TileSize = 3;
			public const int Total = 4;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged([CallerMemberName]string property = "")
		{
			PropertyChangedEventHandler handler = PropertyChanged;

			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(property));
			}
		}

		private short tileSize;
		private string path;
		private string background;
		private string tileset;
		private Size gridSize;
	}
}
