using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HelloWorld.DataAccess
{
    public partial class ApplicationPropertiesPage : ContentPage
    {
        public ApplicationPropertiesPage()
        {
            InitializeComponent();

            // Restore
            if (Application.Current.Properties.ContainsKey("Name"))
                title.Text = Application.Current.Properties["Name"].ToString();

            if (Application.Current.Properties.ContainsKey("NotificationsEnabled"))
                notificationsEnabled.On = (bool) Application.Current.Properties["NotificationsEnabled"] ;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        void OnChange(System.Object sender, System.EventArgs e)
        {
            Application.Current.Properties["Name"] = title.Text;
            Application.Current.Properties["NotificationsEnabled"] = notificationsEnabled.On;
        }

    }
}
