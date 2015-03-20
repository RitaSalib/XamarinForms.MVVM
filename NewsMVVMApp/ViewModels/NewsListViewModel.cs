using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Acr.XamForms.UserDialogs;

namespace NewsMVVMApp
{
	public class NewsListViewModel:BaseViewModel
	{

		public NewsCategory CurrentCategory {
			get;
			set;
		}
		public NewsListViewModel (NewsCategory _category)
		{
			CurrentCategory = _category;
			Articles = new ObservableCollection<Article> ();
			RefreshCommand = new DelegateCommand (Refresh);
		}

		public async Task Init()
		{
		if (!IsDataLoaded) {
				List<Article> _articles;
				using (this._dialogService.Loading ("Loading..")) {
					
					_articles = await newsServices.GetNewsArticles (CurrentCategory.category_id);
						
					} 
				if (_articles != null) {
					Articles = new ObservableCollection<Article> (_articles);
					IsDataLoaded = true;
				}
				else{
						_dialogService.Alert("check Internet Connection");
				}


			}
		}

		public async void Refresh(object obj)
		{
			IsDataLoaded = false;
			await Init ();
		}

		public DelegateCommand RefreshCommand {
			get;
			set;
		}


		public ObservableCollection<Article> Articles {
			get;
			set;
		}

	
	}
}

