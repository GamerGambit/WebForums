using System;

namespace WebForums.Shared
{
	public class PostVM
	{
		public int ID { get; set; }
		public ThreadVM Thread { get; set; }
		public string Content { get; set; }
		public UserVM Poster { get; set; }
		public DateTime Created { get; set; }
		public DateTime Update { get; set; }
	}
}
