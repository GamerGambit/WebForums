using System.Collections.Generic;

namespace WebForums.Models
{
	public class User
	{
		public int ID { get; set; }
		public string Username { get; set; }
		public List<Thread> Threads { get; set; }
		public List<Post> Posts { get; set; }
	}
}
