namespace WebForums.Shared
{
	public class ThreadShortVM
	{
		public int ID { get; set; }
		public ForumShortVM Forum { get; set; }
		public string Title { get; set; }
		public PostShortVM LastestPost { get; set; }
	}
}
