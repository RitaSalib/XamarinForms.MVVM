using System;
using System.Collections.Generic;

namespace NewsMVVMApp
{
	public class Enclosure
	{
		public int length { get; set; }
		public string media_type { get; set; }
		public string uri { get; set; }
	}

	public class Article
	{
		public List<Enclosure> enclosures { get; set; }
		public string publish_date { get; set; }
		public string source { get; set; }
		public string source_url { get; set; }
		public string summary { get; set; }
		public string title { get; set; }
		public string url { get; set; }
		public string author { get; set; }
	}

	public class RootObject
	{
		public List<Article> articles { get; set; }
		public string description { get; set; }
		public string syndication_url { get; set; }
		public string title { get; set; }
	}
}

