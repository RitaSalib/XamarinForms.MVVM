using System;
using Acr.XamForms.UserDialogs;
using Xamarin.Forms;

namespace NewsMVVMApp
{
	public class BaseViewModel:BindableBase
	{
		protected NewsService newsServices;
		protected IUserDialogService _dialogService;

		public BaseViewModel ()
		{
			_dialogService = DependencyService.Get<IUserDialogService> ();
			newsServices = new NewsService ();
			
		}
		private bool _IsDataLoaded;

		public bool IsDataLoaded {
			get { return _IsDataLoaded; } 
			set { SetProperty (ref  _IsDataLoaded, value); }
		}
	}
}

