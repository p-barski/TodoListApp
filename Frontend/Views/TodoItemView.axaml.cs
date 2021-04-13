using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;

namespace Frontend.Views
{
	public class TodoItemView : UserControl
	{
		private readonly string editText = "Edit";
		private readonly string saveText = "Save";
		private Label? taskLabel;
		private TextBox? taskTextBox;
		private Button? editSaveButton;
		public TodoItemView()
		{
			InitializeComponent();
		}
		protected override void OnInitialized()
		{
			base.OnInitialized();
			taskLabel = this.Find<Label>("TaskLabel");
			taskTextBox = this.Find<TextBox>("TaskTextBox");
			editSaveButton = this.Find<Button>("EditSaveButton");
		}
		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}
		private void OnEditSaveClick(object sender, RoutedEventArgs e)
		{
			taskLabel!.IsVisible = !taskLabel!.IsVisible;
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