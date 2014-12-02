using System;
using Xamarin.Forms;
using Autofac;
using System.Reflection;

namespace XF.AutoFacDemo
{

	public class DependencyResolver
	{
		public IContainer CreateContainer ()
		{
			var containerBuilder = new ContainerBuilder ();
			RegisterDepenencies (containerBuilder);
			return containerBuilder.Build ();
		}

		protected virtual void RegisterDepenencies (ContainerBuilder containerBuilder)
		{
			var uiAssembly = typeof(App).GetTypeInfo ().Assembly;

			//services
			containerBuilder.RegisterType<LoginService> ().As<ILoginService> ().SingleInstance ();

			//Business
			containerBuilder.RegisterType<NavigationService> ().As<INavigationService> ().SingleInstance ();
			//containerBuilder.RegisterType<NavigationHelper>().As<INavigation>().SingleInstance();


			//Repositories

			//Utilities


			//View models
			containerBuilder.RegisterAssemblyTypes (uiAssembly)
			.Where (t => t.Name.EndsWith ("ViewModel"))				
			.AsSelf ();


			//Views
			containerBuilder.RegisterAssemblyTypes (uiAssembly)
			//.Where(t => t.IsInstanceOfType(typeof(ContentPage)))
			.Where (t => t.Name.EndsWith ("Page"))				
			.AsSelf ();


		}
	}

}
