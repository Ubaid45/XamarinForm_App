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
            var names = new List<ContactGroup>
            {
                new ContactGroup("U", "U"){
                    new Contact {Name= "Ubaid", ImageUrl = "http://lorempixel.com/100/100/people/1/"}
                },
                new ContactGroup("S", "S"){
                    new Contact {Name= "Sibgha", ImageUrl = "http://lorempixel.com/100/100/people/2/", Status="Hey Sibgha, Lets talk"}

                },
                new ContactGroup("A", "A"){
                    new Contact {Name= "Ali", ImageUrl = "http://lorempixel.com/100/100/people/3/", Status="Moderator"}

                }
            };
            listView.ItemsSource = names;
        }
    }
}
