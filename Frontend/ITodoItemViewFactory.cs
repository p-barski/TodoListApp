using Frontend.ViewModels;
using Backend;

namespace Frontend
{
	public interface ITodoItemViewFactory
	{
		TodoItemViewModel Create(TodoItem todoItem);
	}
}