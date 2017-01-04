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
	}
}
