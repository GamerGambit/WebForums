using System.Collections.Generic;

namespace WebForums.Server.Models
{
	public class User
	{
		public int ID { get; set; }
		public string Username { get; set; }
		public virtual ICollection<Thread> Threads { get; set; }
		public virtual ICollection<Post> Posts { get; set; }
	}
}
