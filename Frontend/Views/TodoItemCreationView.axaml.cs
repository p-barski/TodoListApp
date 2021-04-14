using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Frontend.Views
{
	public class TodoItemCreationView : UserControl
	{
		public TodoItemCreationView()
		{
			InitializeComponent();
		}
		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}
	}
}