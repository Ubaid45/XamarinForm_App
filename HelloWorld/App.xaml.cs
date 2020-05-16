
using HelloWorld.Beyondthebasics;
using HelloWorld.DataAccess;
using HelloWorld.Exercises.Styles.After;
using HelloWorld.Exercises.Styles.Before;
using Xamarin.Forms;

namespace HelloWorld
{
    public partial class App : Application
    {

        private const string TitleKey = "Name";
        private const string NotificationsEnabledKey = "NotificationsEnabled";

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new SubscriberPage());
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

        public string Title
        {
            get
            {
                if (Properties.ContainsKey(TitleKey))
                    return Properties[TitleKey].ToString();

                return "";
            }

            set
            {
                Properties[TitleKey] = value;
            }
        }

        public string NotificationsEnabled
        {
            get
            {
                if (Properties.ContainsKey(NotificationsEnabledKey))
                    return Properties[NotificationsEnabledKey].ToString();

                return "";
            }

            set
            {
                Properties[NotificationsEnabledKey] = value;
            }
        }
    }
}
