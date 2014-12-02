using System;
using System.Threading.Tasks;

namespace XF.AutoFacDemo
{
	public interface ILoginService
	{
		Task<bool> IsLoggedIn();

		Task<User> LoginAsync(string username, string password);

		Task LogOutAsync();
	}
}

