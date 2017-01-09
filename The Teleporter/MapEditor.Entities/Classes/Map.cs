using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Drawing;

namespace MapEditor.Entities
{
	public class Map : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Re-initializes all the tiles and sets them to the first tile of the tileset.
		/// </summary>
		public void ResetAllTiles()
		{
			for (int row = 0; row < GridSize.Rows; ++row)
				for (int column = 0; column < GridSize.Columns; ++column)
					tiles[row, column] = new Tile();
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
		/// Gets the name of the background (NOT the path of it).
		/// </summary>
		/// <returns>Returns a string with the background's name.</returns>
		public string Background
		{
			get { return background; }
			set
			{
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
				tileset = value;
				OnPropertyChanged();
			} 
		}

		/// <summary>
		/// Gets the size of the map in terms of columns and rows or it resizes the map.
		/// </summary>
		public GridSize GridSize
		{
			get { return new GridSize(tiles.GetLength(0), tiles.GetLength(1)); }
			set
			{
				if (value.Rows == 0 || value.Columns == 0 || value.Rows >= MaxGridLength || value.Columns >= MaxGridLength)
					throw new ArgumentException("Invalid grid size.");

				Tile[,] tempTiles = new Tile[value.Rows, value.Columns];

				int minRows = Math.Min(tiles.GetLength(0), value.Rows);
				int minCols = Math.Min(tiles.GetLength(1), value.Columns);

				for (int row = 0; row < minRows; ++row)
					Array.Copy(tiles, tiles.GetLength(0) * row, tempTiles, value.Columns * row, minCols);

				tiles = tempTiles;
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
			get { return new Size(GridSize.Columns * TileSize, GridSize.Rows * TileSize); }
		}

		/// <summary>
		/// Gets the title (name) of the map.
		/// </summary>
		/// <returns>Returns a string that contains the map's title (name).</returns>
		public string Title
		{
			get { return Path.GetFileNameWithoutExtension(path); }
		}

		/// <summary>
		/// Loads the map by using the absolute path of the map file.
		/// </summary>
		/// <param name="absolutePath">The absolute path of the map file.</param>
		public void Load(string absolutePath)
		{
			string filePath = absolutePath;

			string[] fileLines = File.ReadAllLines(filePath);
			string[] gridSizeString = fileLines[FileLineWithProperty.GridSize].Split(' ');
			GridSize gridSize = new GridSize(int.Parse(gridSizeString[0]), int.Parse(gridSizeString[1]));

			if (fileLines.Length != gridSize.Rows + FileLineWithProperty.Total)
				throw new ArgumentOutOfRangeException("The map has more or less rows of tiles (" + (fileLines.Length - FileLineWithProperty.Total) +
													  ") than it's initially specified height (" + gridSize.Rows + ").");

			Tile[,] tiles = new Tile[gridSize.Rows, gridSize.Columns];

			string tileset = fileLines[FileLineWithProperty.Tileset];
			string background = fileLines[FileLineWithProperty.Background];
			short tileSize = short.Parse(fileLines[FileLineWithProperty.TileSize]);

			for (int row = 0, totalProperties = 3; row < gridSize.Rows; ++row)
			{
				int currentLine = row + FileLineWithProperty.Total;
				string[] tilesToBeParsed = fileLines[currentLine].Split(new[] { ' ', ',', ';', '(', ')', '[', ']', '{', '}' }, StringSplitOptions.RemoveEmptyEntries);

				if (gridSize.Columns * totalProperties != tilesToBeParsed.Length)
					throw new ArgumentOutOfRangeException("The map has more or less tiles per row (" + (tilesToBeParsed.Length / totalProperties) +
														  ") than it's initially specified row's width (" + gridSize.Columns + "), " +
														  "either it has invalid separators used in delimiting the tiles.");
	
				for (int column = 0; column < gridSize.Columns; ++column)
				{
					int firstPropertyColumn = column * totalProperties;

					tiles[row, column] = new Tile(
						byte.Parse(tilesToBeParsed[firstPropertyColumn]),
						short.Parse(tilesToBeParsed[firstPropertyColumn + 1]),
						(Solidity)int.Parse(tilesToBeParsed[firstPropertyColumn + 2])
					);
				}
			}

			this.tiles = tiles;
			TileSize = tileSize;
			FilePath = filePath;
			Tileset = tileset;
			Background = background;
		}

		public void Save(string absolutePath)
		{
			using (StreamWriter writer = new StreamWriter(absolutePath))
			{
				writer.WriteLine(string.Join(" ", GridSize.Rows, GridSize.Columns));
				writer.WriteLine(Tileset != string.Empty ? Tileset : "Unnamed");
				writer.WriteLine(Background != string.Empty ? Background : "Unnamed");
				writer.WriteLine(TileSize);

				for (int row = 0; row < GridSize.Rows; ++row)
				{
					for (int column = 0; column < GridSize.Columns; ++column)
						writer.Write(tiles[row, column]);
					writer.Write(Environment.NewLine);
				}
			}

			FilePath = absolutePath;
		}

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
		private Tile[,] tiles = new Tile[1, 1];

		private const short MaxGridLength = 10000;

		struct FileLineWithProperty
		{
			public const int GridSize = 0;
			public const int Tileset = 1;
			public const int Background = 2;
			public const int TileSize = 3;
			public const int Total = 4;
		}
	}
}
