using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NewsMVVMApp
{
	public partial class NewsListPage : ContentPage
	{
		public NewsListViewModel ViewModel {
			get;
			set;
		}
		public NewsListPage (NewsCategory category)
		{
			InitializeComponent ();
			ViewModel= new NewsListViewModel (category);
			this.Title=category.display_category_name;
			this.BindingContext = ViewModel;
		}

		protected async override void OnAppearing ()
		{
			base.OnAppearing ();
			await ViewModel.Init ();
			listView.ItemsSource = ViewModel.Articles;
		}

		async void OnItemTapped(object sender, ItemTappedEventArgs args)
		{
			var article= args.Item as Article;
			if (article != null)
				await this.Navigation.PushAsync (new NewsItemDetailsPage (article));
		}
	}
}

