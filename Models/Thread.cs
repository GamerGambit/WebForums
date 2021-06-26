using System.Collections.Generic;

namespace WebForums.Models
{
	public class Thread
	{
		public int ID { get; set; }
		public virtual Forum Forum { get; set; }
		public string Title { get; set; }
		public User Starter { get; set; }
		public virtual ICollection<Post> Posts { get; set; }
	}
}
