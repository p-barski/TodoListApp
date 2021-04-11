namespace Frontend.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		public MainViewModel MainView { get; }
		public MainWindowViewModel(MainViewModel mainViewModel)
		{
			MainView = mainViewModel;
		}
	}
}