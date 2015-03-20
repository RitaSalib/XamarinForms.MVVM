using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NewsMVVMApp
{
	public partial class NewsCategoriesPage : ContentPage
	{
		public NewsCategoriesViewModel ViewModel {
			get;
			set;
		}
		public NewsCategoriesPage ()
		{
			InitializeComponent ();
			ViewModel = new NewsCategoriesViewModel ();
			this.BindingContext = ViewModel;
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			ViewModel.Init ();
			listView.ItemsSource = ViewModel.NewsCategories;
	}

	async void OnItemTapped(object sender, ItemTappedEventArgs args)
	{
			var category= args.Item as NewsCategory;
			if (category != null)
				await this.Navigation.PushAsync (new NewsListPage (category));
	}
	}
}

