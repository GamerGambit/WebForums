namespace WebForums.Shared
{
	public class ThreadVM
	{
		public int ID { get; set; }
		public ForumVM Forum { get; set; }
		public string Title { get; set; }
		public UserVM Starter { get; set; }
		public PostVM LastestPost { get; set; }
	}
}
