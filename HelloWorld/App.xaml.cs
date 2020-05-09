using HelloWorld.Exercises.AbsoluteLayout;
using HelloWorld.Exercises.GridLayout;
using HelloWorld.Exercises.Images;
using HelloWorld.Exercises.RelativeLayout;
using HelloWorld.Exercises.StackLayout;
using HelloWorld.Exercises.XAMLEssentials;
using Xamarin.Forms;

namespace HelloWorld
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ListViewPage();
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
