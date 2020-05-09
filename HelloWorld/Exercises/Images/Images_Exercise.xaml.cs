using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HelloWorld.Exercises.Images
{
    public partial class ImagesExercise : ContentPage
    {
		private int _currentImageId = 1;

		public ImagesExercise()
		{
			InitializeComponent();

			_currentImageId = 1;

			LoadImage();
		}

		void LoadImage()
		{
			image.Source = new UriImageSource
			{
				Uri = new Uri(String.Format("http://lorempixel.com/1920/1080/city/{0}", _currentImageId)),
				CachingEnabled = false
			};
		}

		void Previous_Clicked(object sender, System.EventArgs e)
		{
			_currentImageId--;
			if (_currentImageId == 0)
				_currentImageId = 10;

			LoadImage();
		}

		void Next_Clicked(object sender, System.EventArgs e)
		{
			_currentImageId++;
			if (_currentImageId == 11)
				_currentImageId = 1;

			LoadImage();
		}
	}

}
