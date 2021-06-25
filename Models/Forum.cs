using System.Collections.Generic;

namespace WebForums.Models
{
	public class Forum
	{
		public int ID { get; set; }
		public Category Category { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public List<Thread> Threads { get; set; }
	}
}
