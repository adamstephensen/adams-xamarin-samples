using System;
using Xamarin.Forms;
using Autofac;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XF.AutoFacDemo
{
	public partial class FirstPage : ContentPage
	{
		public FirstPage (Page1ViewModel vm, ILogger logger)
		{
			BindingContext = vm;

			Title = "Page 1";

			var welcomeButton = new Button {
				Text = vm.Message,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};

			//this is OK, but it even better would be to have a command on the view model
			welcomeButton.Clicked += (sender, e) => vm.Navigation.PushAsync <SecondPage> ();

			Content = welcomeButton;
		}
	}

	public partial class SecondPage : ContentPage
	{
		public SecondPage (Page1ViewModel vm, ILogger logger)
		{
			BindingContext = vm;

			Title = "Page 2";

			var welcomeButton = new Button {
				Text = vm.Message,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};

			//this is OK, but it even better would be to have a command on the view model
			welcomeButton.Clicked += (sender, e) => vm.Navigation.PushAsync <ThirdPage> ();

			Content = welcomeButton;
		}
	}

	public partial class ThirdPage : ContentPage
	{
		public ThirdPage (Page1ViewModel vm, ILogger logger)
		{
			BindingContext = vm;

			Title = "Page 3";

			var welcomeButton = new Button {
				Text = vm.Message,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};

			//this is OK, but it even better would be to have a command on the view model
			welcomeButton.Clicked += (sender, e) => 
				vm.Navigation.DisplayAlert("message box title","message box message","ok");

			Content = welcomeButton;
		}
	}
}
