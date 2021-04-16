using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Frontend.Views
{
	public class TodoListView : UserControl
	{
		private ItemsControl? items;
		public TodoListView()
		{
			InitializeComponent();
		}
		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}
		protected override void OnInitialized()
		{
			base.OnInitialized();
			items = this.Find<ItemsControl>("Items");
			this.PropertyChanged += OnSizedChangedHandler;
		}
		private void OnSizedChangedHandler(object? sender, AvaloniaPropertyChangedEventArgs e)
		{
			items!.MaxWidth = this.Bounds.Width;
		}
	}
}