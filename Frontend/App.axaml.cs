using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Frontend.ViewModels;
using Frontend.Views;
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
				var factory = new TodoItemViewFactory(databaseAccess);
				var listViewModel = new TodoListViewModel(databaseAccess, factory);
				var creationViewModel = new TodoItemCreationViewModel(databaseAccess);
				var windowControlsViewModel = new WindowControlsViewModel();
				var mainViewModel = new MainViewModel(listViewModel,
					creationViewModel, windowControlsViewModel);
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