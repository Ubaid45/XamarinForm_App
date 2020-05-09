using HelloWorld.Exercises.AbsoluteLayout;
using HelloWorld.Exercises.GridLayout;
using HelloWorld.Exercises.StackLayout;
using Xamarin.Forms;

namespace HelloWorld
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new GridLayout_Exercise2();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
