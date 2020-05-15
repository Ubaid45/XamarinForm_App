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

            BindingContext = Application.Current;
        }


    }
}
