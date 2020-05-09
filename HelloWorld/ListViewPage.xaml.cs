using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HelloWorld.Models;
using Xamarin.Forms;

namespace HelloWorld
{
    public partial class ListViewPage : ContentPage
    {
        private ObservableCollection<Contact> _contacts;
        public ListViewPage()
        {
            InitializeComponent();
            _contacts = new ObservableCollection<Contact>
            {
                new Contact {Name= "Ubaid", ImageUrl = "http://lorempixel.com/100/100/people/1/"},
                new Contact {Name= "Sibgha", ImageUrl = "http://lorempixel.com/100/100/people/2/", Status="Hey Sibgha, Lets talk"},
                new Contact {Name= "Ali", ImageUrl = "http://lorempixel.com/100/100/people/3/", Status="Moderator"},
            };
            listView.ItemsSource = _contacts;
        }

        void Call_Clicked(System.Object sender, System.EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var contact = menuItem.CommandParameter as Contact;

            DisplayAlert("Call", contact.Name, "Ok");
        }

        void Delete_Clicked(System.Object sender, System.EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;
            _contacts.Remove(contact);
        }
    }
}
