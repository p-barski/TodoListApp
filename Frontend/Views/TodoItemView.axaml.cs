using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;

namespace Frontend.Views
{
	public class TodoItemView : UserControl
	{
		private readonly string editText = "Edit";
		private readonly string saveText = "Save";
		private TextBlock? taskTextBlock;
		private TextBox? taskTextBox;
		private Button? editSaveButton;
		public TodoItemView()
		{
			InitializeComponent();
		}
		protected override void OnInitialized()
		{
			base.OnInitialized();
			taskTextBlock = this.Find<TextBlock>("TaskTextBlock");
			taskTextBox = this.Find<TextBox>("TaskTextBox");
			editSaveButton = this.Find<Button>("EditSaveButton");
		}
		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}
		private void OnEditSaveClick(object sender, RoutedEventArgs e)
		{
			taskTextBlock!.IsVisible = !taskTextBlock!.IsVisible;
			taskTextBox!.IsVisible = !taskTextBox!.IsVisible;
			if (editSaveButton!.Content.Equals(editText))
			{
				editSaveButton!.Content = saveText;
			}
			else
			{
				editSaveButton!.Content = editText;
			}
		}
	}
}