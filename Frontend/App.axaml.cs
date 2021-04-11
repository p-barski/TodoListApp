using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Frontend.ViewModels;
using Frontend.Views;
using Backend;
using Backend.Implementations;

namespace Frontend
{
	public class App : Application
	{
		public override void Initialize()
		{
			AvaloniaXamlLoader.Load(this);
		}

		public override void OnFrameworkInitializationCompleted()
		{
			if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
			{
				var databaseAccess = DatabaseCreator.CreateDatabaseAccess();
				databaseAccess.Add(new TodoItem() { Date = System.DateTime.Now, Task = "Test" });
				var factory = new TodoItemViewFactory(databaseAccess);
				var view = new TodoListViewModel(databaseAccess, factory);
				var mainViewModel = new MainViewModel(databaseAccess, view);
				var mainWindow = new MainWindowViewModel(mainViewModel);
				desktop.MainWindow = new MainWindow
				{
					DataContext = mainWindow,
				};
			}
			base.OnFrameworkInitializationCompleted();
		}
	}
}