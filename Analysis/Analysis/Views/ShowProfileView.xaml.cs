using Analysis.LocalServices;
using Analysis.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Analysis.Models;


namespace Analysis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowProfileView : ContentPage
    {
        UserProfileViewModel UserProfileViewModel;
        User Relative;
        private MediaFile selectedimgfile;
        public ShowProfileView(User _relative)
        {
            InitializeComponent();
            UserProfileViewModel = new UserProfileViewModel();
            Relative = _relative;
        }
        protected override void OnAppearing()
        {                    

            RelativeImage.Source = Relative.Image;
            RelativeName.Text = Relative.Name;                                
        }
       

        private async void EditUserIcon_Tabbed(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Alert", "not supprored", "ok");
                return;
            }
            var mediaoptions = new Plugin.Media.Abstractions.PickMediaOptions()
            {
                PhotoSize = PhotoSize.Medium
            };
            selectedimgfile = await CrossMedia.Current.PickPhotoAsync(mediaoptions);
            if (selectedimgfile == null)
            {
                await DisplayAlert("error", "tryagain", "ok");
            }
            RelativeImage.Source = ImageSource.FromStream(() => selectedimgfile.GetStream());
            Stream stream = selectedimgfile.GetStream();
            var imagePath = await UserProfileViewModel.UploadImage(stream, selectedimgfile.Path);
            var userID = int.Parse(Application.Current.Properties["UserID"].ToString());
            Relative.Image = App.ServiceURL + imagePath;

            Relative = await UserProfileViewModel.EditUser(Relative, Relative.ID);
            RelativeImage.Source = Relative.Image;
        }

        private void DownArrowIcon_Tabbed(object sender, EventArgs e)
        {

        }

        private void LeftArrowIcon_Tabbed(object sender, EventArgs e)
        {

        }

        private void RightArrowIcon_Tabbed(object sender, EventArgs e)
        {

        }

        private void UserChoicesIcon_Tapped(object sender, EventArgs e)
        {

        }

        private async void Delete_Relative(object sender, EventArgs e)
        {
           
            var response = await UserProfileViewModel.DeleteRelative(Relative.ID);
            await Navigation.PushAsync(new UserProfileView());
            await DisplayAlert("Alert", $"You Deleted {Relative.Name}'s Account Successfully" ,"Okay" );
        }
    }
}