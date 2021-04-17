using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Markup.Xaml;

namespace Frontend.Views
{
	//https://github.com/FrankenApps/Avalonia-CustomTitleBarTemplate
	public class WindowControlsView : UserControl
	{
		private Window? window;
		private Button? minimizeButton;
		private Button? maximizeButton;
		private Button? closeButton;
		private Path? maximizeIcon;
		private ToolTip? maximizeToolTip;
		public WindowControlsView()
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
			minimizeButton = this.FindControl<Button>("MinimizeButton");
			maximizeButton = this.FindControl<Button>("MaximizeButton");
			closeButton = this.FindControl<Button>("CloseButton");
			maximizeIcon = this.FindControl<Path>("MaximizeIcon");
			maximizeToolTip = this.FindControl<ToolTip>("MaximizeToolTip");

			minimizeButton.Click += MinimizeWindow;
			maximizeButton.Click += MaximizeWindow;
			closeButton.Click += CloseWindow;
			window = (Window)this.VisualRoot;
			SubscribeToWindowState();
		}
		private void CloseWindow(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
		{
			window!.Close();
		}
		private void MaximizeWindow(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
		{
			if (window!.WindowState == WindowState.Normal)
			{
				window.WindowState = WindowState.Maximized;
				return;
			}
			window.WindowState = WindowState.Normal;
		}
		private void MinimizeWindow(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
		{
			window!.WindowState = WindowState.Minimized;
		}
		private void SubscribeToWindowState()
		{
			window!
				.GetObservable(Window.WindowStateProperty)
				.Subscribe(windowState =>
				{
					if (windowState != WindowState.Maximized)
					{
						maximizeIcon!.Data = Avalonia.Media.Geometry.Parse(
							"M2048 2048v-2048h-2048v2048h2048zM1843 1843h-1638v-1638h1638v1638z");
						window!.Padding = new Thickness(0, 0, 0, 0);
						maximizeToolTip!.Content = "Maximize";
					}
					if (windowState == WindowState.Maximized)
					{
						maximizeIcon!.Data = Avalonia.Media.Geometry.Parse(
							"M2048 1638h-410v410h-1638v-1638h410v-410h1638v1638zm-614-1024h-1229v1229h1229v-1229zm409-409h-1229v205h1024v1024h205v-1229z");
						window!.Padding = new Thickness(7, 7, 7, 7);
						maximizeToolTip!.Content = "Restore Down";
					}
				});
		}
	}
}