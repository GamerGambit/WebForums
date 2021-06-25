using System.Collections.Generic;

namespace WebForums.Models
{
	public class Category
	{
		public int ID { get; set; }
		public string Title { get; set; }
		public List<Forum> Forums { get; set; }
	}
}
