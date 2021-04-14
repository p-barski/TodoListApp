using System;
using ReactiveUI;
using Avalonia.Controls;
using Backend;

namespace Frontend.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		public TodoListViewModel TodoListView { get; }
		public TodoItemCreationViewModel TodoItemCreationView { get; }
		public DateTimeOffset CurrentDate
		{
			get => currentDate;
			set
			{
				this.RaiseAndSetIfChanged(ref currentDate, value.Date);
				TodoListView.FillItems(currentDate);
			}
		}
		public GridLength RowHeight
		{
			get => rowHeight;
			set => this.RaiseAndSetIfChanged(ref rowHeight, value);
		}
		public double RowMinHeight
		{
			get => rowMinHeight;
			set => this.RaiseAndSetIfChanged(ref rowMinHeight, value);
		}
		private DateTime currentDate = DateTime.Now.Date;
		private GridLength rowHeight;
		private double rowMinHeight;
		private readonly double normalMinHeight = 50.0;
		private readonly GridLength hiddenHeight = new(0.0);
		private readonly GridLength normalHeight = new(1, GridUnitType.Star);
		public MainViewModel(
			TodoListViewModel todoListViewModel,
			TodoItemCreationViewModel todoItemCreationViewModel)
		{
			TodoListView = todoListViewModel;
			TodoItemCreationView = todoItemCreationViewModel;
			TodoItemCreationView.ItemCreatedEvent += ItemCreatedEventHandler;

			RowHeight = hiddenHeight;
			RowMinHeight = hiddenHeight.Value;
		}
		private void ItemCreatedEventHandler(TodoItem todoItem)
		{
			TodoListView.FillItems(currentDate);
			HideCreationView();
		}
		private void OnCreateNewCommand()
		{
			if (RowMinHeight == normalMinHeight)
			{
				HideCreationView();
				return;
			}
			ShowCreationView();
		}
		private void OnNextClick()
		{
			CurrentDate = CurrentDate.AddDays(1);
		}
		private void OnPreviousClick()
		{
			CurrentDate = CurrentDate.AddDays(-1);
		}
		private void HideCreationView()
		{
			RowHeight = hiddenHeight;
			RowMinHeight = hiddenHeight.Value;
		}
		private void ShowCreationView()
		{
			RowHeight = normalHeight;
			RowMinHeight = normalMinHeight;
		}
	}
}