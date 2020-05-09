using System;
using System.Collections.Generic;
using HelloWorld.Models;
using Xamarin.Forms;

namespace HelloWorld
{
    public partial class ListViewPage : ContentPage
    {
        public ListViewPage()
        {
            InitializeComponent();
            var names = new List<Contact>
            {
                new Contact {Name= "Ubaid", ImageUrl = "http://lorempixel.com/100/100/people/1/"},
                new Contact {Name= "Sibgha", ImageUrl = "http://lorempixel.com/100/100/people/2/", Status="Hey Sibgha, Lets talk"},
                new Contact {Name= "Ali", ImageUrl = "http://lorempixel.com/100/100/people/3/", Status="Moderator"},
            };
            listView.ItemsSource = names;
        }
    }
}
