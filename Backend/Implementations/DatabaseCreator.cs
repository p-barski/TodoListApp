namespace Backend.Implementations
{
	public class DatabaseCreator
	{
		public static IDatabaseAccess CreateDatabaseAccess()
		{
			var creator = new DatabasePathCreator("TodoApp", "data.db");
			var connectionString = creator.CreatePathAndConnectionString();
			var context = new TodoDbContext(connectionString);
			context.Database.EnsureCreated();
			return new DatabaseAccess(connectionString);
		}
	}
}