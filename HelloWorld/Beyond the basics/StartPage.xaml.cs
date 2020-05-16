using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HelloWorld.Beyondthebasics
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Resources["buttonBackgroundColor"] = Color.Red;
        }
    }
}
