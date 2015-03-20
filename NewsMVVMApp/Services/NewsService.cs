using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace NewsMVVMApp
{
	public class NewsService
	{
		private const string ApiBaseAddress = "http://api.feedzilla.com/v1/";
		private const string NewsUrl="categories/";
		private const string CategoriesUrl="categories";


		private HttpClient CreateClient ()
		{
			var httpClient = new HttpClient 
			{ 
				BaseAddress = new Uri(ApiBaseAddress)
			};

			httpClient.DefaultRequestHeaders.Accept.Clear();
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			return httpClient;
		}

		public async Task<List<Article>> GetNewsArticles (int category_id)
		{
			var categoryArticlesUrl=NewsUrl+category_id+"/articles";
			IEnumerable<Article> articles = Enumerable.Empty<Article>();
			RootObject root = null;
			try{
			using (var httpClient = CreateClient ()) {
					var response = await httpClient.GetAsync (categoryArticlesUrl).ConfigureAwait(false);
				if (response.IsSuccessStatusCode) {
					var json = await response.Content.ReadAsStringAsync ().ConfigureAwait(false);
					if (!string.IsNullOrWhiteSpace (json)) {
						root = await Task.Run (() => 
							JsonConvert.DeserializeObject<RootObject>(json)
						).ConfigureAwait(false);
							
					}
				}
			}
			}
			catch(TaskCanceledException timeOut) {
				System.Diagnostics.Debug.WriteLine (timeOut);
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				return null;
			}

			if (root != null) {
				articles = root.articles;
			}
			return articles.ToList();
		}

		public async Task<List<NewsCategory>> GetNewsCategories ()
		{

			IEnumerable<NewsCategory> categories = Enumerable.Empty<NewsCategory>();

			try{
				using (var httpClient = CreateClient ()) {
					var response = await httpClient.GetAsync (CategoriesUrl).ConfigureAwait(false);
					if (response.IsSuccessStatusCode) {
						var json = await response.Content.ReadAsStringAsync ().ConfigureAwait(false);
						if (!string.IsNullOrWhiteSpace (json)) {
							categories = await Task.Run (() => 
								JsonConvert.DeserializeObject<IEnumerable<NewsCategory>>(json)
							).ConfigureAwait(false);

						}
					}
				}
			}
			catch(TaskCanceledException timeOut) {
				System.Diagnostics.Debug.WriteLine (timeOut);
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				return null;
			}

		
			return categories.ToList();
		}
	}
}

