namespace WebForums.Shared
{
	public class ForumShortVM
	{
		public int ID { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public ThreadShortVM LatestThreadPostedIn { get; set; }
	}
}
