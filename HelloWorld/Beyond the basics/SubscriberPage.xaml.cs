using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HelloWorld.Beyondthebasics
{
    public partial class SubscriberPage : ContentPage
    {
        public SubscriberPage()
        {
            InitializeComponent();
        }

        void OnClick(object sender, System.EventArgs e)
        {
            var page = new TargetPage();

            // If we had instance of target page

            //page.SliderValueChanged += OnSliderValueChanged;

            // If we have not the instance of target page, use Messaging center
            MessagingCenter.Subscribe<TargetPage, double>(this, Events.SliderValueChanged, OnSliderValueChanged);

            Navigation.PushAsync(page);


            //MessagingCenter.Unsubscribe<SubscriberPage>(this, Events.SliderValueChanged);
        }

        private void OnSliderValueChanged(TargetPage source, double newValue)
        {
            label.Text = newValue.ToString();
        }
    }
}
