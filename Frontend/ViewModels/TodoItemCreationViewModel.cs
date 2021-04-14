using System;
using Backend;

namespace Frontend.ViewModels
{
	public class TodoItemCreationViewModel : ViewModelBase
	{
		public DateTimeOffset Date { get; set; } = DateTime.Now;
		public TimeSpan Time { get; set; } = DateTime.Now.TimeOfDay;
		public string Task { get; set; } = "";
		public delegate void Created(TodoItem todoItem);
		public event Created? ItemCreatedEvent;
		private readonly IDatabaseAccess databaseAccess;
		public TodoItemCreationViewModel(IDatabaseAccess databaseAccess)
		{
			this.databaseAccess = databaseAccess;
		}
		private void OnCreateCommand()
		{
			var todoItem = new TodoItem()
			{
				Date = Date.Date + Time,
				Task = Task,
				IsFinished = false
			};
			databaseAccess.Add(todoItem);
			ItemCreatedEvent?.Invoke(todoItem);
		}
	}
}