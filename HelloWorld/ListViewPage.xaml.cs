using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HelloWorld
{
    public partial class ListViewPage : ContentPage
    {
        public ListViewPage()
        {
            InitializeComponent();
            var names = new List<string>
            {
                "Ubaid",
                "Sibgha",
                "Abubakar"
            };
            listView.ItemsSource = names;
        }
    }
}
