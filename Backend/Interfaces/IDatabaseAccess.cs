using System;
using System.Collections.Generic;

namespace Backend
{
	public interface IDatabaseAccess
	{
		void Add(TodoItem todoItem);
		void Update(TodoItem todoItem);
		void Remove(TodoItem todoItem);
		List<TodoItem> Filter(DateTime date);
	}
}