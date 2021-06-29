using System.Collections.Generic;

namespace WebForums.Server.Models
{
	public class Category
	{
		public int ID { get; set; }
		public string Title { get; set; }
		public virtual ICollection<Forum> Forums { get; set; }
	}
}
