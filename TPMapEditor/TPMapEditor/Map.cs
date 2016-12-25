using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TPMapEditor
{
	class Map
	{
		short tileSize;
		string path;
		string background;
		string tileset;
		Size gridSize;
		public Tile[,] Tiles { get; set; }

		/// <summary>
		/// Constructs a map with a basic structure.
		/// </summary>
		public Map()
		{
			TileSize = 50;
			GridSize = new Size(1, 1);
			FilePath = string.Empty;
			Background = "Unnamed";
			Tileset = "Unnamed";
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
		/// Loads the map by using the absolute path of the map file.
		/// </summary>
		/// <param name="absolutePath">The absolute path of the map file.</param>
		public void Load(string absolutePath)
		{
			string FilePath = absolutePath;

			string[] fileLines = File.ReadAllLines(FilePath);
			int totalLines = fileLines.Length;

			Size GridSize = new Size(Convert.ToInt32(fileLines[FileLineWithProperty.GridSize].Split(' ')[1]), 
								Convert.ToInt32(fileLines[FileLineWithProperty.GridSize].Split(' ')[0]));

			if (totalLines != GridSize.Height + FileLineWithProperty.Total)
				throw new ArgumentOutOfRangeException("The map has more or less rows of tiles (" + (totalLines - FileLineWithProperty.Total) +
													  ") than it's initially specified height (" + GridSize.Height + ").");

			Tile[,] Tiles = new Tile[GridSize.Height, GridSize.Width];

			string Tileset = fileLines[FileLineWithProperty.Tileset];
			string Background = fileLines[FileLineWithProperty.Background];
			short TileSize = Convert.ToInt16(fileLines[FileLineWithProperty.TileSize]);

			for (int row = 0; row < GridSize.Height; ++row)
			{
				int currentLine = row + FileLineWithProperty.Total;
				string[] tilesToBeParsed = fileLines[currentLine].Split(new []{ ' ', ',', ';', '(', ')', '[', ']', '{', '}' }, StringSplitOptions.RemoveEmptyEntries);

				if (GridSize.Width * Tile.TotalProperties != tilesToBeParsed.Length)
					throw new ArgumentOutOfRangeException("The map has more or less tiles per row (" + (tilesToBeParsed.Length / Tile.TotalProperties) +
														  ") than it's initially specified row's width (" + GridSize.Width + "), " +
														  "either it has invalid separators used in delimiting the tiles.");

				for (int column = 0; column < GridSize.Width; ++column)
				{
					int firstPropertyColumn = column * Tile.TotalProperties;

					Tiles[row, column] = new Tile();
					Tiles[row, column].PropertiesID = Convert.ToByte(tilesToBeParsed[firstPropertyColumn]);
					Tiles[row, column].Damage = Convert.ToInt16(tilesToBeParsed[firstPropertyColumn + 1]);
					Tiles[row, column].Solidity = (Solidity)Convert.ToInt32(tilesToBeParsed[firstPropertyColumn + 2]);
				}
			}

			this.FilePath = FilePath;
			this.GridSize = GridSize;
			this.Tiles = Tiles;
			this.Tileset = Tileset;
			this.Background = Background;
			this.TileSize = TileSize;
		}

		public void Save()
		{
			using (StreamWriter writer = new StreamWriter(FilePath))
			{
				writer.WriteLine(string.Join(" ", GridSize.Height, GridSize.Width));
				writer.WriteLine(Tileset);
				writer.WriteLine(Background);
				writer.WriteLine(TileSize);

				for(int row = 0; row < GridSize.Height; ++row)
				{
					for(int column = 0; column < GridSize.Width; ++column)
					{
						writer.Write(Tiles[row, column]);
					}
					writer.Write(Environment.NewLine);
				}
			}
		}

		struct FileLineWithProperty
		{
			public const int GridSize = 0;
			public const int Tileset = 1;
			public const int Background = 2;
			public const int TileSize = 3;
			public const int Total = 4;
		};

		/// <summary>
		/// Gets the title (name) of the map.
		/// </summary>
		/// <returns>Returns a string that contains the map's title (name).</returns>
		public string Title
		{
			get { return Path.GetFileNameWithoutExtension(path); }
		}

		public string FilePath
		{
			get { return path; }
			set
			{
				path = value;
				OnTitleChanged(EventArgs.Empty);
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
				OnTileSizeChanged(EventArgs.Empty);
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
				OnGridSizeChanged(EventArgs.Empty);
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
				OnBackgroundChanged(EventArgs.Empty);
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
				OnTilesetChanged(EventArgs.Empty);
			}
		}

		protected virtual void OnTileSizeChanged(EventArgs e)
		{
			EventHandler handler = TileSizeChanged;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		protected virtual void OnGridSizeChanged(EventArgs e)
		{
			EventHandler handler = GridSizeChanged;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		protected virtual void OnBackgroundChanged(EventArgs e)
		{
			EventHandler handler = BackgroundChanged;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		protected virtual void OnTilesetChanged(EventArgs e)
		{
			EventHandler handler = TilesetChanged;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		protected virtual void OnTitleChanged(EventArgs e)
		{
			EventHandler handler = TitleChanged;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		public event EventHandler TileSizeChanged;
		public event EventHandler GridSizeChanged;
		public event EventHandler BackgroundChanged;
		public event EventHandler TilesetChanged;
		public event EventHandler TitleChanged;
	}
}
