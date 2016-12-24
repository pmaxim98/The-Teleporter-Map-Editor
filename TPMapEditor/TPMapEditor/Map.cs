using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPMapEditor
{
    class Map
    {
        short tileSize;
        Size gridSize;
        string title;
        string background;
        string tileset;

        /// <summary>
        /// Constructs a map with a basic structure.
        /// </summary>
        public Map()
        {
            TileSize = 50;
            GridSize = new Size(10, 10);
            Title = "Unnamed";
            Background = "Unnamed";
            Tileset = "Unnamed";
        }

        /// <summary>
        /// Constructs a map with a basic tilesize and gridsize but with specific title, background and tileset.
        /// </summary>
        public Map(string Title, string Background, string Tileset)
        {
            TileSize = 50;
            GridSize = new Size(10, 10);
            this.Title = Title;
            this.Background = Background;
            this.Tileset = Tileset;
        }

        /// <summary>
        /// Gets the title (name) of the map.
        /// </summary>
        /// <returns>Returns a string that contains the map's title (name).</returns>
        public string Title
        {
            get { return title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException();

                title = value;
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
                if (value > 0)
                {
                    tileSize = value;
                    OnTileSizeChanged(EventArgs.Empty);
                }
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
                if (value.Width > 0 && value.Height > 0)
                {
                    gridSize = value;
                    OnGridSizeChanged(EventArgs.Empty);
                }
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
                    throw new ArgumentNullException();

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
                    throw new ArgumentNullException();

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
