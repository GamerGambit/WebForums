using System.ComponentModel.DataAnnotations;

namespace WebForums.Shared
{
	public class PostForm
	{
		[Required]
		public int ThreadId { get; set; }

		[Required]
		public string Content { get; set; }
	}
}
