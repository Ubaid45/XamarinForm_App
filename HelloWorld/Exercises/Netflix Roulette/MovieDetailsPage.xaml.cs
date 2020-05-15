using System;
using System.Collections.Generic;
using MovieApp;
using Xamarin.Forms;

namespace HelloWorld.Exercises.NetflixRoulette
{
    public partial class MovieDetailsPage : ContentPage
    {
		private MovieService _movieService = new MovieService();
		private Movie _movie;

		public MovieDetailsPage(Movie movie)
		{
			if (movie == null)
				throw new ArgumentNullException(nameof(movie));

			_movie = movie;

			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			BindingContext = await _movieService.GetMovie(_movie.Title);

			base.OnAppearing();
		}
	}
}
