using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analysis.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Analysis.Models;
namespace Analysis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : PopupPage
    {
        LoginViewModel LoginViewModel;
        public LoginView()
        {
            InitializeComponent();
            LoginViewModel = new LoginViewModel();
        }

        private void LoginFB_Btn_Clicked(object sender, EventArgs e)
        {

        }

        private async void Login_Btn_Clicked(object sender, EventArgs e)
        {
            User user = new User();
            user.Email = UserEmail.Text.ToLower();
            user.Password = UserPassword.Text;
            var userData = await LoginViewModel.Login(user);
            if( userData == null )
            {
               await DisplayAlert("Warning","Please Enter Valid Email & Password ","Thanks");
                UserEmail.Text = "";
                UserPassword.Text = "";
            }
            else
            {
                Application.Current.Properties["IsLoggedin"] = "True";
                Application.Current.Properties["UserID"] = userData.ID.ToString();
                await Navigation.PushAsync(new HomePage());
                this.IsVisible = false;
            }
            
        }

        private  void SignUp_Btn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUpPage());
            this.IsVisible = false;
        }

        private void LoginFaceBook_Tapped(object sender, EventArgs e)
        {

        }
    }
}