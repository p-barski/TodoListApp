using System;
using ReactiveUI;
using Backend;

namespace Frontend.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		public TodoListViewModel ListView { get; }
		public DateTimeOffset CurrentDate
		{
			get => currentDate;
			set
			{
				this.RaiseAndSetIfChanged(ref currentDate, value.Date);
				ListView.FillItems(currentDate);
			}
		}
		private readonly IDatabaseAccess databaseAccess;
		private DateTime currentDate = DateTime.Now.Date;
		public MainViewModel(IDatabaseAccess databaseAccess, TodoListViewModel todoListViewModel)
		{
			this.databaseAccess = databaseAccess;
			ListView = todoListViewModel;
			Console.WriteLine(CurrentDate.ToString());
		}
		private void OnNextClick()
		{
			CurrentDate = CurrentDate.AddDays(1);
		}
		private void OnNewClick()
		{
			//TODO
		}
		private void OnPreviousClick()
		{
			CurrentDate = CurrentDate.AddDays(-1);
		}
	}
}