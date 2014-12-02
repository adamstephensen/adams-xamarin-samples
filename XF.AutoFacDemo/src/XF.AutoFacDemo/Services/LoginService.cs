using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace XF.AutoFacDemo
{

	public class LoginService : ILoginService
	{
		AppSettings appSettings;

		public LoginService (AppSettings appSettings)
		{
			this.appSettings = appSettings;
			
		}

		public async Task<bool> IsLoggedIn()
		{
			return appSettings.CurrentUser != null;
		}

		public async Task<User> LoginAsync(string username, string password)
		{
			var user = Login(username, password);

			appSettings.CurrentUser = user;

			return user;
		}

		private User Login(string username, string password)
		{
			if (string.IsNullOrWhiteSpace(username)) return null;
			if (username.Contains("fake")) return null;

			appSettings.CurrentUser =  new User {UserId = 1, Name = username};

			return appSettings.CurrentUser;
		}

		public async Task LogOutAsync()
		{
			appSettings.CurrentUser = null;
		}
	}
}
