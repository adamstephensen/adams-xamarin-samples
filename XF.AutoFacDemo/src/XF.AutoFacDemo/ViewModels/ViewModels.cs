using System;
using Xamarin.Forms;
using Autofac;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XF.AutoFacDemo
{

	public class Page1ViewModel
	{
		public INavigationService Navigation { get; set; }

		IPlatformSpecificMessageGenerator messageGenerator;

		ILogger logger;

		public Page1ViewModel (INavigationService navigation, IPlatformSpecificMessageGenerator messageGenerator, ILogger logger)
		{
			this.logger = logger;
			this.messageGenerator = messageGenerator;
			this.Navigation = navigation;
		}

		public string Message {
			get { 
				var message = messageGenerator.GetMessage ();
				logger.Info ("message generated {0}",message);
				return message;
			} 
		}

		public ICommand GoToStartPageCommand {
			get { return new Command (() => Navigation.PushAsync<SecondPage> ()); }
		}

	}

	public class Page2ViewModel
	{
		public INavigationService Navigation { get; set; }

		IPlatformSpecificMessageGenerator messageGenerator;

		public Page2ViewModel (INavigationService navigation, IPlatformSpecificMessageGenerator messageGenerator)
		{
			this.messageGenerator = messageGenerator;
			this.Navigation = navigation;
		}

		public string Message { get { return messageGenerator.GetMessage (); } }

		public ICommand GoToStartPageCommand {
			get { return new Command (() => Navigation.PushAsync<ThirdPage> ()); }
		}

	}

	public class Page3ViewModel
	{
		public INavigationService Navigation { get; set; }

		IPlatformSpecificMessageGenerator messageGenerator;

		public Page3ViewModel (INavigationService navigation, IPlatformSpecificMessageGenerator messageGenerator)
		{
			this.messageGenerator = messageGenerator;
			this.Navigation = navigation;
		}

		public string Message { get { return messageGenerator.GetMessage (); } }

		public ICommand GoToStartPageCommand {
			get { return new Command (() => Navigation.PushAsync<SecondPage> ()); }
		}

	}
	
}
