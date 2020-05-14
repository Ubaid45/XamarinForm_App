using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HelloWorld.FormsandSettingPages
{
    public partial class InputPage : ContentPage
    {
        public InputPage()
        {
            InitializeComponent();
        }

        void ViewCell_Tapped(System.Object sender, System.EventArgs e)
        {
            var page = new ContactMethodsPage();
            page.ContactMethods.ItemSelected += (source, args) =>
            {
                contactMethod.Text = args.SelectedItem.ToString();
                Navigation.PopAsync();
            };

            Navigation.PushAsync(page);
        }
    }
}
