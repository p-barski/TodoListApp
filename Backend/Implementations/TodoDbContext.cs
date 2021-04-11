using Microsoft.EntityFrameworkCore;

namespace Backend.Implementations
{
	public class TodoDbContext : DbContext
	{
		public DbSet<TodoItem> TodoItems { get; set; }
		private string connectionString;
		public TodoDbContext(string connectionString)
		{
			this.connectionString = connectionString;
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite(connectionString);
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<TodoItem>().ToTable("TodoItem");
		}
	}
}