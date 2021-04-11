using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Frontend.Views
{
	public class TodoItemView : UserControl
	{
		public TodoItemView()
		{
			InitializeComponent();
		}
		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}
	}
}