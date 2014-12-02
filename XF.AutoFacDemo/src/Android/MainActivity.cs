using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;
using Autofac;


namespace XF.AutoFacDemo.Android
{
	public class AndroidMessageGenerator : IPlatformSpecificMessageGenerator
	{
		public string GetMessage ()
		{
			return "Hello Android !";
		}
	}

	public class AndroidDependencyResolver : DependencyResolver
	{
		protected override void RegisterDepenencies(ContainerBuilder containerBuilder)
		{
			base.RegisterDepenencies(containerBuilder);

			containerBuilder.RegisterType<AndroidLogger>().As<ILogger>().SingleInstance();
			containerBuilder.RegisterType<AndroidMessageGenerator>().As<IPlatformSpecificMessageGenerator>().SingleInstance();
		}
	}

	[Activity (Label = "XF.AutoFacDemo.Android.Android", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : AndroidActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			Xamarin.Forms.Forms.Init (this, bundle);

			//SetPage (App.GetMainPage ());
			App.Init (new AndroidDependencyResolver ());

			var startPage = App.GetStartPage<FirstPage> ();

			SetPage (startPage);
		}
	}
}

