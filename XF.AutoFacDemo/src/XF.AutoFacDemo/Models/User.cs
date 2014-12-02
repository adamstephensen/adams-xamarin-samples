using System;

namespace XF.AutoFacDemo
{
	public class AppSettings
	{
		public User CurrentUser { get; set; }

	}
	public class User
	{
		public int UserId { get; set; }

		public string Name { get; set; }
	}
}

