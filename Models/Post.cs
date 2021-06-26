using System;

namespace WebForums.Models
{
	public class Post
	{
		public int ID { get; set; }
		public virtual Thread Thread { get; set; }
		public string Content { get; set; }
		public User Poster { get; set; }
		public DateTime Created { get; set; }
		public DateTime Update { get; set; }
	}
}
