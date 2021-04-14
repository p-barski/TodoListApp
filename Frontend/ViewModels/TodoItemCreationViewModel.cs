using System;
using ReactiveUI;
using Backend;

namespace Frontend.ViewModels
{
	public class TodoItemCreationViewModel : ViewModelBase
	{
		public DateTimeOffset Date
		{
			get => date;
			set => this.RaiseAndSetIfChanged(ref date, value.Date);
		}
		public TimeSpan Time
		{
			get => time;
			set => this.RaiseAndSetIfChanged(ref time, value);
		}
		public string Task
		{
			get => task;
			set => this.RaiseAndSetIfChanged(ref task, value);
		}
		public delegate void Created(TodoItem todoItem);
		public event Created? ItemCreatedEvent;
		private DateTime date = DateTime.Now;
		private TimeSpan time = DateTime.Now.TimeOfDay;
		private string task = "";
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
			Task = "";
			Time = DateTime.Now.TimeOfDay;
			databaseAccess.Add(todoItem);
			ItemCreatedEvent?.Invoke(todoItem);
		}
	}
}