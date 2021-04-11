using System;
using System.Linq;
using System.Collections.Generic;

namespace Backend.Implementations
{
	public class DatabaseAccess : IDatabaseAccess
	{
		private readonly string connectionString;
		public DatabaseAccess(string connectionString)
		{
			this.connectionString = connectionString;
		}
		public void Add(TodoItem todoItem)
		{
			using var context = new TodoDbContext(connectionString);
			context.TodoItems.Add(todoItem);
			context.SaveChanges();
		}
		public void Update(TodoItem todoItem)
		{
			using var context = new TodoDbContext(connectionString);
			context.TodoItems.Update(todoItem);
			context.SaveChanges();
		}
		public void Remove(TodoItem todoItem)
		{
			using var context = new TodoDbContext(connectionString);
			context.TodoItems.Remove(todoItem);
			context.SaveChanges();
		}
		public List<TodoItem> Filter(DateTime date)
		{
			using var context = new TodoDbContext(connectionString);
			return context.TodoItems
				.Where(i => i.Date.Date == date.Date)
				.ToList();
		}
	}
}