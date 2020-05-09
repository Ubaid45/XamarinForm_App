using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using HelloWorld.Models;
using Xamarin.Forms;

namespace HelloWorld
{
    public partial class ListViewPage : ContentPage
    {

        IEnumerable<Contact> GetContacts(string searchText = null)
        {
            var contacts= new ObservableCollection<Contact>
            {
                new Contact {Name= "Ubaid", ImageUrl = "http://lorempixel.com/100/100/people/1/"},
                new Contact {Name= "Sibgha", ImageUrl = "http://lorempixel.com/100/100/people/2/", Status="Hey Sibgha, Lets talk"},
                new Contact {Name= "Ali", ImageUrl = "http://lorempixel.com/100/100/people/3/", Status="Moderator"},
            };

            if (string.IsNullOrWhiteSpace(searchText))
                return contacts;

            return contacts.Where(c => c.Name.StartsWith(searchText));
        }
        public ListViewPage()
        {
            InitializeComponent();
            listView.ItemsSource = GetContacts();
        }


        void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            listView.ItemsSource = GetContacts(e.NewTextValue);
        }
    }
}
