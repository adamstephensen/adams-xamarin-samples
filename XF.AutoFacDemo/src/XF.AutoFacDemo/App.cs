using System;
using Xamarin.Forms;
using Autofac;
using System.Diagnostics;

namespace XF.AutoFacDemo
{
	public interface IPlatformSpecificMessageGenerator 
	{
		string GetMessage();
	}

	public class App
	{
	
		public static T Resolve<T>()
		{
			try
			{
				return _container.Resolve<T>();
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Error resolving type {0}:  {1}", typeof(T).FullName, ex);

				throw;
			}
		}

		private static IContainer _container;

		public static void Init(DependencyResolver dependencyResolver)
		{
			_container = dependencyResolver.CreateContainer();
		}
		public static Page GetStartPage<TStartUpPage>() where TStartUpPage:Page
		{
			var startupPage = _container.Resolve<TStartUpPage> ();
			var navPage = new NavigationPage (startupPage);

			//get the navigation service from the nav page and assign it to the navigation service
			var navService = _container.Resolve<INavigationService> ();
			navService.Navigation = navPage.Navigation;
			navService.StartPage = navPage;

			return navPage;
		}


	}

}

