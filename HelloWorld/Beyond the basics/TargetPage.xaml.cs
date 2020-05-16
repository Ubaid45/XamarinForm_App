using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HelloWorld.Beyondthebasics
{
    public partial class TargetPage : ContentPage
    {
        //public event EventHandler<double> SliderValueChanged;

        public TargetPage()
        {
            InitializeComponent();
        }

        void slider_ValueChanged(System.Object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
            MessagingCenter.Send(this, Events.SliderValueChanged, e.NewValue);
            //SliderValueChanged?.Invoke(this, e.NewValue);
        }
    }
}
