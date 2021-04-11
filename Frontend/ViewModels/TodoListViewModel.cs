using System;
using System.Linq;
using System.Collections.ObjectModel;
using Backend;

namespace Frontend.ViewModels
{
	public class TodoListViewModel : ViewModelBase
	{
		public ObservableCollection<TodoItemViewModel> ItemViewModels { get; } = new();
		private readonly IDatabaseAccess databaseAccess;
		private readonly ITodoItemViewFactory factory;
		public TodoListViewModel(IDatabaseAccess databaseAccess, ITodoItemViewFactory factory)
		{
			this.databaseAccess = databaseAccess;
			this.factory = factory;
			FillItems(DateTime.Now);
		}
		public void FillItems(DateTime date)
		{
			ItemViewModels.Clear();
			databaseAccess
				.Filter(date)
				.OrderBy(i => i.Date)
				.Select(i => factory.Create(i))
				.ToList()
				.ForEach(i =>
				{
					i.ItemDeletedEvent += ItemDeletedHandler;
					ItemViewModels.Add(i);
				});
		}
		private void ItemDeletedHandler(TodoItemViewModel sender)
		{
			ItemViewModels.Remove(sender);
		}
	}
}