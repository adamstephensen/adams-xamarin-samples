using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Xamarin.Forms;
using Autofac;

namespace XF.AutoFacDemo.iOS
{

	public class IosMessageGenerator : IPlatformSpecificMessageGenerator
	{
		public string GetMessage ()
		{
			return "Hello iOS !";
		}
	}

	public class iOSDependencyResolver : DependencyResolver
	{
		protected override void RegisterDepenencies(ContainerBuilder containerBuilder)
		{
			base.RegisterDepenencies(containerBuilder);
				
			containerBuilder.RegisterType<IosMessageGenerator>().As<IPlatformSpecificMessageGenerator>().SingleInstance();
			containerBuilder.RegisterType<DebugLogger>().As<ILogger>().SingleInstance();
		}
	}


	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			Forms.Init ();

			window = new UIWindow (UIScreen.MainScreen.Bounds);

			//window.RootViewController = App.GetMainPage ().CreateViewController ();
			App.Init (new iOSDependencyResolver ());
			var startPage = App.GetStartPage<FirstPage> ();
			window.RootViewController = startPage.CreateViewController ();

			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

