using System.Collections.Generic;

namespace WebForums.Models
{
	public class Forum
	{
		public int ID { get; set; }
		public virtual Category Category { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public virtual ICollection<Thread> Threads { get; set; }
	}
}
