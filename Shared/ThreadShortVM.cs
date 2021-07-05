namespace WebForums.Shared
{
	public class ThreadShortVM
	{
		public int ID { get; set; }
		public string Title { get; set; }
		public UserVM Starter { get; set; } // For use in ForumVM
		public PostShortVM LastestPost { get; set; }
	}
}
