using Backend;

namespace Frontend.ViewModels
{
	public class TodoItemViewModel : ViewModelBase
	{
		public string Date => todoItem.Date.ToString();
		public string Task => todoItem.Task;
		public string IsFinished => todoItem.IsFinished.ToString();
		public delegate void Deleted(TodoItemViewModel sender);
		public event Deleted? ItemDeletedEvent;
		private readonly IDatabaseAccess databaseAccess;
		private readonly TodoItem todoItem;
		public TodoItemViewModel(IDatabaseAccess databaseAccess, TodoItem todoItem)
		{
			this.databaseAccess = databaseAccess;
			this.todoItem = todoItem;
		}
		private void OnDeleteClick()
		{
			databaseAccess.Remove(todoItem);
			ItemDeletedEvent?.Invoke(this);
		}
	}
}