using System.Collections.Generic;

namespace WebForums.Shared
{
	public class ThreadVM
	{
		public int ID { get; set; }
		public ForumVM Forum { get; set; }
		public string Title { get; set; }
		public IEnumerable<PostVM> Posts { get; set; }
	}
}
