using Analysis.LocalServices;
using Analysis.Models;
using Analysis.ViewModels;
using Rg.Plugins.Popup.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using Analysis.Views.PopupPages;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.IO;

namespace Analysis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserProfileView : ContentPage
    {
        private Plugin.Media.Abstractions.MediaFile selectedimgfile;
        readonly UserProfileViewModel UserProfileViewModel;        
        User User;
        public UserProfileView()
        {

            InitializeComponent();
            //_connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            UserProfileViewModel = new UserProfileViewModel();          
            User = new User();          
        }

        static int descIndex = 0;

        protected async override void OnAppearing()
        {
            int userID = Convert.ToInt32(Application.Current.Properties["UserID"]);
            User = await UserProfileViewModel.GetUser( userID );

            UserName.Text = User.Name;
            UserImage.Source = App.ServiceURL + User.Image;

            UserProfileViewModel.Relatives = await UserProfileViewModel.GetUserRelatives(userID);
          //  UserProfileViewModel.Relatives = await UserProfileViewModel.SQLiteGetUserRelatives();

            UserProfileViewModel.OrganDetails = await UserProfileViewModel.GetUserChoice(userID);

            if (UserProfileViewModel.OrganDetails != null)
            {               
               /* UserProfileViewModel.LblText = UserProfileViewModel.OrganDetails[descIndex].Description;
                descIndex++;
                UserProfileViewModel.Messages = await UserProfileViewModel.GetMessage(userID);
                UserProfileViewModel.LblTextMsg = UserProfileViewModel.Messages[UserProfileViewModel.Messages.Count - 1].MessageBody;  */            
            }
            BindingContext = UserProfileViewModel;
        }
        protected  override bool OnBackButtonPressed()
        {
             Navigation.PushAsync(new HomePage());
            return true;
        }

        private async void EditIcon_Tabbed(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Alert", "not supprored", "ok");
                
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
            else
            {


                UserImage.Source = ImageSource.FromStream(() => selectedimgfile.GetStream());
                Stream stream = selectedimgfile.GetStream();
                var imagePath = await UserProfileViewModel.UploadImage(stream, selectedimgfile.Path);
                var userID = int.Parse(Application.Current.Properties["UserID"].ToString());
                User.Image = imagePath;

                User = await UserProfileViewModel.EditUser(User, User.ID);
                UserImage.Source = App.ServiceURL + User.Image;
            }
            
        }

        private void UserRate_Tabbed(object sender, EventArgs e)
        {

        }

        private void DownArrow_Tabbed(object sender, EventArgs e)
        {

            
         //   PopupNavigation.Instance.PushAsync(new ShapesPage());

        }

        private void LeftArrow_Tabbed(object sender, EventArgs e)
        {

            RightArrow.Source = "rightarrow.png";
            RightArrow.IsEnabled = true;
            UserProfileViewModel.LblText = UserProfileViewModel.OrganDetails[descIndex].Description;
            descIndex++;

            if (descIndex == UserProfileViewModel.OrganDetails.Count)
            {
                //   (sender as Image).IsVisible = false;

                Image image = sender as Image;
                image.Source = "Leftarrowend.png";
                image.IsEnabled = false;
                descIndex--;

            }
        }
        private void rightArrow_Tabbed(object sender, EventArgs e)
        {
            LeftArrow.Source = "leftarrow.png";
            LeftArrow.IsEnabled = true;
            if (descIndex != 0)
            {
                descIndex--;
                UserProfileViewModel.LblText = UserProfileViewModel.OrganDetails[descIndex].Description;
            }
            else      // (descIndex ==  (DescribeOrganViewModel.describeOrgans.Count)
            {
                Image image = sender as Image;
                image.Source = "Rightarrowend.png";
                image.IsEnabled = false;
                descIndex++;
            }
        }
   
        private void Choices_Tapped(object sender, EventArgs e)
        {

        }

        private async void Menu_Tapped(object sender, EventArgs e)
        {
            await MenuIcon.TranslateTo(100, 0, 200);
            await PopupNavigation.Instance.PushAsync(new MenuPopup(MenuIcon));
        }

        private async void AddRelative_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new AddRelative());
        }

    

      
        private async void Relative_Tabbed(object sender, EventArgs e)
        {
            var Relative = ((sender as Frame).GestureRecognizers[0] as TapGestureRecognizer).CommandParameter as User;

            await Navigation.PushAsync(new ShowProfileView(Relative));
        }
    }
}