using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace HelloWorld.DataAccess
{
	public class Post : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public int Id { get; set; }
		public string _title { get; set; }
		public string Body { get; set; }

		public string Title
		{
			get
			{
				return _title;
			}
			set
			{
				if (_title == value)
					return;

				_title = value;

				OnPropertyChanged();
			}
		}

		private void OnPropertyChanged([CallerMemberName]string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

	}

	public partial class WebServicePage : ContentPage
	{
		private const string Url = "https://jsonplaceholder.typicode.com/posts";
		private HttpClient _client = new HttpClient();
		private ObservableCollection<Post> _posts;

		public WebServicePage()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			var content = await _client.GetStringAsync(Url);
			var posts = JsonConvert.DeserializeObject <List<Post>>(content);

			_posts = new ObservableCollection<Post>(posts);
			postsListView.ItemsSource = _posts;

			base.OnAppearing();
		}

		async void OnAdd(object sender, System.EventArgs e)
		{
			var post = new Post { Title = "title " + DateTime.Now.Ticks };
			_posts.Insert(0, post);

			var content = JsonConvert.SerializeObject(post);
			await _client.PostAsync(Url, new StringContent(content));

		}

		async void OnUpdate(object sender, System.EventArgs e)
		{
			var post = _posts[0];
			post.Title += " Updated";

			var content = JsonConvert.SerializeObject(post);


			await _client.PutAsync(Url+"/"+post.Id, new StringContent(content));

		}

		async void OnDelete(object sender, System.EventArgs e)
		{
			var post = _posts[0];
			_posts.Remove(post);

			await _client.DeleteAsync(Url + "/" + post.Id);
		}
	}
}
