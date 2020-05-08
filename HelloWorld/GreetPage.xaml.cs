
using Xamarin.Forms;

namespace HelloWorld
{
    public partial class GreetPage : ContentPage
    {
        public GreetPage()
        {
            InitializeComponent();
            hello_slider.Value = 0.5;
        }

        void Slider_ValueChanged(System.Object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
            label.Text = string.Format("Value : {0:F2}", e.NewValue);
        }

    }
}
