using System;
using Xamarin.Forms;
using Autofac;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XF.AutoFacDemo
{

	public interface INavigationService
	{
		INavigation Navigation { get; set; }

		Page StartPage { get; set; }

		Task PushAsync<TPage> () where TPage:Page;

		Task<Page> PopAsync ();

		Task PushModalAsync <TPage> ()where TPage:Page;

		Task<Page> PopModalAsync ();

		Task PopToRootAsync ();

		Task<bool> DisplayAlert (string title, string message, string accept, string cancel = null);
	}

}
