using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NewsMVVMApp
{
	public partial class NewsItemDetailsPage : ContentPage
	{
		public NewsItemDetailsPage (Article article)
		{
			InitializeComponent ();
			this.BindingContext = article;
			this.Title="Summary";
		}


	}
}

