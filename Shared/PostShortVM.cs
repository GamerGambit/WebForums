using System;

namespace WebForums.Shared
{
	public class PostShortVM
	{
		public int ID { get; set; }
		public UserVM Poster { get; set; }
		public DateTime Created { get; set; }
	}
}
