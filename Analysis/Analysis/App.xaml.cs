using Analysis.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Analysis
{
    public partial class App : Application
    {
        public static string ServiceURL = "http://sagdabakr-001-site1.dtempurl.com/";
                                             
        public App()
        {
            InitializeComponent();
            Application.Current.Properties["IsLoggedin"] = "False";
 
            var CurrentUser = Application.Current.Properties["IsLoggedin"].ToString();
            if (CurrentUser == "False")
            {
                Application.Current.Properties["UserID"] = "0";
               // Application.Current.Properties["FinishQuiz"] = "False";
            }
            MainPage = new NavigationPage(new HomePage());
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
