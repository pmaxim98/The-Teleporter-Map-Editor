using System.IO;

namespace MapEditor.Utilities
{
    public static class Utils
    {
		public static string GetDefaultMapsFolderPath()
		{
			string mapsFolderPath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory.ToString(), "Maps");
			Directory.CreateDirectory(mapsFolderPath);
			return mapsFolderPath;
		}

		public static string GetDefaultTilesetsFolderPath()
		{
			string tilesetsFolderPath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory.ToString(), "Graphics\\Tilesets");
			Directory.CreateDirectory(tilesetsFolderPath);
			return tilesetsFolderPath;
		}

		public static string GetDefaultBackgroundsFolderPath()
		{
			string backgroundsFolderPath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory.ToString(), "Graphics\\Backgrounds");
			Directory.CreateDirectory(backgroundsFolderPath);
			return backgroundsFolderPath;
		}

		public static string FormatToNumericString(string normalString)
		{
			string formattedText = string.Empty;

			foreach (char ch in normalString)
			{
				if (char.IsDigit(ch))
					formattedText += ch;
			}

			return (formattedText == string.Empty) || formattedText == "0" ? string.Empty : short.Parse(formattedText).ToString();
		}
	}
}
