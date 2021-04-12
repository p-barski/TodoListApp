using ReactiveUI;
using Backend;

namespace Frontend.ViewModels
{
	public class TodoItemViewModel : ViewModelBase
	{
		public string Date => todoItem.Date.ToString();
		public string Task => todoItem.Task;
		public bool IsFinished
		{
			get => isFinished;
			set
			{
				this.RaiseAndSetIfChanged(ref isFinished, value);
				todoItem.IsFinished = isFinished;
				databaseAccess.Update(todoItem);
			}
		}
		public delegate void Deleted(TodoItemViewModel sender);
		public event Deleted? ItemDeletedEvent;
		private readonly IDatabaseAccess databaseAccess;
		private readonly TodoItem todoItem;
		private bool isFinished;
		public TodoItemViewModel(IDatabaseAccess databaseAccess, TodoItem todoItem)
		{
			this.databaseAccess = databaseAccess;
			this.todoItem = todoItem;
			isFinished = todoItem.IsFinished;
		}
		private void OnDeleteClick()
		{
			databaseAccess.Remove(todoItem);
			ItemDeletedEvent?.Invoke(this);
		}
	}
}