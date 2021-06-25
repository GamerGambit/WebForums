using System.Collections.Generic;

namespace WebForums.Models
{
	public class Thread
	{
		public int ID { get; set; }
		public Forum Forum { get; set; }
		public string Title { get; set; }
		public User Starter { get; set; }
		public List<Post> Posts { get; set; }
	}
}
