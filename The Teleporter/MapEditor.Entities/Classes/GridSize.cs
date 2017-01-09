using System;

namespace MapEditor.Entities
{
	public class GridSize
	{
		public GridSize()
		{
			Rows = 0;
			Columns = 0;
		}

		public GridSize(int rows, int columns)
		{
			Rows = rows;
			Columns = columns;
		}

		public int Rows
		{
			get { return rows; }
			set
			{
				if (value < 0)
					throw new ArgumentException("Invalid rows count supplied.");

				rows = value;
			}
		}

		public int Columns
		{
			get { return columns; }
			set
			{
				if (value < 0)
					throw new ArgumentException("Invalid columns count supplied.");

				columns = value;
			}
		}

		public int Area { get { return Rows * Columns; } }

		private int rows;
		private int columns;
	}
}
