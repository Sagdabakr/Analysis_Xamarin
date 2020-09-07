using Analysis.Models;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analysis.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Analysis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        RegisterViewModel RegisterViewModel;
       // string imgpath;
        public SignUpPage()
        {
            InitializeComponent();
            RegisterViewModel = new RegisterViewModel();
            
        }
        private Plugin.Media.Abstractions.MediaFile selectedimgfile;
        private async void SignUp_Btn_Clicked(object sender, EventArgs e)
        {

            bool ValidEmail = false;
            if (string.IsNullOrEmpty(UserEmail.Text))
            {
               ValidEmail = false;
            }

            else
            if (UserEmail.Text.Contains("@") && UserEmail.Text.Contains(".com"))
            {
                ValidEmail = true;
            }

            if (string.IsNullOrEmpty(UserName.Text) || string.IsNullOrEmpty(UserEmail.Text) || string.IsNullOrEmpty(UserPhone.Text) || string.IsNullOrEmpty(UserPassword.Text) || ValidEmail == false)
            {                
                if (string.IsNullOrEmpty(UserName.Text))
                {
                    NameFrame.BorderColor = Color.Red;
                }
                else
                {
                    NameFrame.BorderColor = Color.LightGreen;
                }

                if (string.IsNullOrEmpty(UserEmail.Text) || ValidEmail==false )
                {
                    EmailFrame.BorderColor = Color.Red;
                }
                else
                {
                    EmailFrame.BorderColor = Color.LightGreen;
                }

                if (string.IsNullOrEmpty(UserPhone.Text))
                {
                    PhoneFrame.BorderColor = Color.Red;
                }
                else
                {
                    PhoneFrame.BorderColor = Color.LightGreen;
                }

                if (string.IsNullOrEmpty(UserPassword.Text))
                {
                    PasswordFrame.BorderColor = Color.Red;
                }
                else
                {
                    PasswordFrame.BorderColor = Color.LightGreen;
                }
            }

            else
            {
                User user = new User();
                user.Name = UserName.Text;
                user.Email = UserEmail.Text;
                user.Password = UserPassword.Text;
                user.PhoneNumber = UserPhone.Text;
                var x = image.Source.ToString();
                if (x == "File: userprofile.jpg")
                {
                    user.Image = "/uploads/64884803.png";
                }
                else
                {
                    Stream stream = selectedimgfile.GetStream();
                    var imagePath = await RegisterViewModel.UploadImage(stream, selectedimgfile.Path);
                    user.Image = imagePath;
                }

                var userData = await RegisterViewModel.Register(user);
                Application.Current.Properties["UserID"] = userData.ID.ToString();
                Application.Current.Properties["IsLoggedin"] = "True";

                await Navigation.PushAsync(new HomePage());
            }
         
            
        }

        private void Login_Btn_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new LoginView());

        }

        private async void AddUserPhoto_Tapped(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Alert", "not supprored", "ok");
                return;
            }
            var mediaoptions = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Medium
            };
             selectedimgfile = await CrossMedia.Current.PickPhotoAsync(mediaoptions);
            if (selectedimgfile == null)
            {
                await DisplayAlert("error", "tryagain", "ok");
            }              
            image.Source = ImageSource.FromStream(() => selectedimgfile.GetStream());                                     
        }

        private void EditIcon_Tabbed(object sender, EventArgs e)
        {

        }

        private async void Menu_Tapped(object sender, EventArgs e)
        {
            await MenuIcon.TranslateTo(100, 0, 200);
            await PopupNavigation.Instance.PushAsync(new MenuPopup(MenuIcon));

        }
    }
}