using Frontend.ViewModels;
using Backend;

namespace Frontend
{
	class TodoItemViewFactory : ITodoItemViewFactory
	{
		private readonly IDatabaseAccess databaseAccess;
		public TodoItemViewFactory(IDatabaseAccess databaseAccess)
		{
			this.databaseAccess = databaseAccess;
		}
		public TodoItemViewModel Create(TodoItem todoItem)
		{
			return new TodoItemViewModel(databaseAccess, todoItem);
		}
	}
}