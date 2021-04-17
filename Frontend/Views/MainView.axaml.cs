using Avalonia.Input;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Frontend.Views
{
	public class MainView : UserControl
	{
		public MainView()
		{
			InitializeComponent();
		}
		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}
		private void TitleBarPressedEventHandler(object sender, PointerPressedEventArgs e)
		{
			if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
			{
				((Window)this.VisualRoot).BeginMoveDrag(e);
			}
		}
	}
}