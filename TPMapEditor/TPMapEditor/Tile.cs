using System;

namespace TPMapEditor
{
    enum Solidity : byte { Floor, Obstacle, Wall };
    class Tile
    {
        byte propsID;
        short damage;
		public Solidity Solidity { get; set; }

		public static int TotalProperties = 3;

		/// <summary>
		/// Constructs a tile that has the ID of the first tile in the loaded tileset. The tile is also a floor and deals no damage.
		/// </summary>
		public Tile()
        {
            PropertiesID = 1;
            Damage = 0;
            Solidity = Solidity.Floor;
        }

		/// <summary>
		/// Constructs a tile with the following ID, damage and solidity.
		/// </summary>
		/// <param name="PropertiesID">The ID of a tile's properties from the tileset.</param>
		/// <param name="Damage">The damage the entities receive when they are standing on the tile.</param>
		/// <param name="Solidity">The solidity of the tile.</param>
		public Tile(byte PropertiesID, short Damage, Solidity Solidity)
		{
			this.PropertiesID = PropertiesID;
			this.Damage = Damage;
			this.Solidity = Solidity;
		}

        /// <summary>
        /// Gets or sets the ID of the properties of a corresponing tile.
        /// </summary>
        public byte PropertiesID
        {
            get { return propsID; }
            set
            {
                if(value == 0)
                    throw new ArgumentException("Invalid ID for tileset's tiles properties.");

                propsID = value;
            }
        }

        /// <summary>
        /// Gets or sets the damage the entities receive when they are standing on the tile.
        /// </summary>
        public short Damage
        {
            get { return damage; }
            set
			{
				if (value < 0)
					throw new ArgumentException();

				damage = value;
			}
        }

		public override string ToString()
		{
			return "[" + string.Join(",", PropertiesID, (byte)Solidity, Damage) + "]";
		}
	}
}
