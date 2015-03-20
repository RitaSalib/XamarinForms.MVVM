using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace NewsMVVMApp
{
	public class NewsCategoriesViewModel:BaseViewModel
	{

		public NewsCategoriesViewModel ()
		{
			NewsCategories = new ObservableCollection<NewsCategory> ();
			RefreshCommand = new DelegateCommand (Refresh);
		}

		public async Task Init()
		{
			if (!IsDataLoaded) {
				List<NewsCategory> _categories;
				using (this._dialogService.Loading ("Loading..")) {

					_categories = await newsServices.GetNewsCategories ();

				} 
				if (_categories != null) {
					NewsCategories = new ObservableCollection<NewsCategory> (_categories);
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

		public ObservableCollection<NewsCategory> NewsCategories {
			get;
			set;
		}
	}
}

