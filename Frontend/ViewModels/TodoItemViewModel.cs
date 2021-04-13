using System;
using ReactiveUI;
using Backend;

namespace Frontend.ViewModels
{
	public class TodoItemViewModel : ViewModelBase
	{
		public TimeSpan Date
		{
			get => time;
			set
			{
				this.RaiseAndSetIfChanged(ref time, value);
				todoItem.Date = todoItem.Date.Date + time;
				databaseAccess.Update(todoItem);
			}
		}
		public string Task
		{
			get => task;
			set => this.RaiseAndSetIfChanged(ref task, value);
		}
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
		private TimeSpan time;
		private string task;
		private bool isFinished;
		public TodoItemViewModel(IDatabaseAccess databaseAccess, TodoItem todoItem)
		{
			this.databaseAccess = databaseAccess;
			this.todoItem = todoItem;
			isFinished = todoItem.IsFinished;
			task = todoItem.Task;
			time = todoItem.Date.TimeOfDay;
		}
		private void OnDeleteClick()
		{
			databaseAccess.Remove(todoItem);
			ItemDeletedEvent?.Invoke(this);
		}
		private void OnEditSaveCommand()
		{
			if (todoItem.Task == task)
			{
				return;
			}
			todoItem.Task = task;
			databaseAccess.Update(todoItem);
		}
	}
}