using System;
using Xamarin.Forms;
using Autofac;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XF.AutoFacDemo
{



	public class NavigationService:INavigationService
	{
		public INavigation Navigation { get; set; }

		public Page StartPage { get; set; }

		public Task PushAsync<TPage> () where TPage:Page
		{
			Page page = App.Resolve<TPage>();
			return Navigation.PushAsync (page);
		}

		public Task<Page> PopAsync ()
		{
			return Navigation.PopAsync ();
		}

		public Task PushModalAsync <TPage> () where TPage:Page
		{
			Page page = App.Resolve<TPage>();
			return Navigation.PushModalAsync (page);
		}

		public Task<Page> PopModalAsync ()
		{
			return Navigation.PopModalAsync ();
		}

		public Task PopToRootAsync ()
		{
			return Navigation.PopToRootAsync ();
		}

		public Task<bool> DisplayAlert(string title, string message, string accept, string cancel = null)
		{
			return StartPage.DisplayAlert(title, message, accept, cancel);
		}
	}

}
