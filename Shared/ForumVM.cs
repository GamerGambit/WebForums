using System.Collections.Generic;

namespace WebForums.Shared
{
	public class ForumVM
	{
		public int ID { get; set; }
		public CategoryVM Category { get; set; }
		public string Title { get; set; }
		public string Description { get;set; }
		public ICollection<ThreadVM> Threads { get; set; }
	}
}
