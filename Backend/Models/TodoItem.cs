using System;

namespace Backend
{
	public class TodoItem
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public string Task { get; set; }
		public bool IsFinished { get; set; }
	}
}