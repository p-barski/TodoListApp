using System;
using System.IO;

namespace Backend.Implementations
{
	public class DatabasePathCreator
	{
		private readonly string appName;
		private readonly string databaseFileName;
		public DatabasePathCreator(string appName, string databaseFileName)
		{
			this.appName = appName;
			this.databaseFileName = databaseFileName;
		}
		public string CreatePathAndConnectionString()
		{
			var appDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			var todoAppDir = $"{appDir}/{appName}";
			var dbFilePath = $"{todoAppDir}/{databaseFileName}";
			var connectionString = $"Data Source={dbFilePath};";
			Directory.CreateDirectory(todoAppDir);
			return connectionString;
		}
	}
}