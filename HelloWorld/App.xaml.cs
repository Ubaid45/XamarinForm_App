using HelloWorld.Exercises;
using Xamarin.Forms;

namespace HelloWorld
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AbsoluteLayout_Exercise1();
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
