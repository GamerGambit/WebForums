using System.Collections.Generic;

namespace WebForums.Shared
{
	public class CategoryVM
	{
		public int ID { get; set; }
		public string Title { get; set; }
		public ICollection<ForumShortVM> ForumShorts { get; set; }
	}
}
