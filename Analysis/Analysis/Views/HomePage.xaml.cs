using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Analysis.ViewModels;
using Rg.Plugins.Popup.Pages;
using SQLite;
using Analysis.LocalServices;
using Analysis.Models;

namespace Analysis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {       
        HomeViewModel HomeViewModel;
       // DescribeOrganViewModel DescribeOrganViewModel;
        UserChoice UserChoice;
        SQLiteAsyncConnection _connection;     
        int currentUser = int.Parse(Application.Current.Properties["UserID"].ToString());
        public HomePage()
        {
            InitializeComponent();
            HomeViewModel = new HomeViewModel();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();   
            
            UserChoice = new UserChoice();
        }
        protected async override void OnAppearing()
        {
            if(currentUser == 0)
            {
                HomeUserName.Text = "مـسـتـخـدم";
                HomeUserIcon.Source = "anonymous.jpg";
            }
            else
            {
                var user = await HomeViewModel.GetUser(currentUser);
                HomeUserName.Text = user.Name;
                HomeUserIcon.Source = App.ServiceURL + user.Image;
            }
        }


        private async void OrgansList_Tapped(object sender, EventArgs e)
        {
            int OrganID = int.Parse(((sender as Image).GestureRecognizers[0] as TapGestureRecognizer).CommandParameter.ToString());
            MainQuizIcons.IsVisible = false;
            QuizOptions.IsVisible = true;

            
            HomeViewModel.PopupContent = HomeViewModel.GetPopupContent(OrganID);
            HomeViewModel.Organs = await HomeViewModel.GetOrganDetail(OrganID);

            var image = sender as Image;
            SelectedOrgan.Source = image.Source;
            BindingContext = HomeViewModel;
        }

        private async  void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            if (currentUser == 0)
            {
               await DisplayAlert("Warning", "Please Login First", "Ok");
            }
            else
            {
                var userOrgan = e.Item as OrganDetail;

                MainQuizIcons.IsVisible = true;
                QuizOptions.IsVisible = false;


                UserChoice = new UserChoice();
                UserChoice.UserID = currentUser;
                UserChoice.OrganDetailID = userOrgan.ID;
                HomeViewModel.UserChoices = await HomeViewModel.PostUserChoice(UserChoice);

                EditQuiz editQuiz = new EditQuiz();
                    editQuiz.userId = currentUser;
                    editQuiz.organDetailId = userOrgan.ID;
                    HomeViewModel.UserChoices = await HomeViewModel.EditUserChoice(editQuiz);
              

                

            }
            }


        

        private async void Menu_Tapped(object sender, EventArgs e)
        {
            
            await MenuIcon.TranslateTo(100,0,200);
            await PopupNavigation.Instance.PushAsync(new MenuPopup(MenuIcon));
            //await Navigation.PushAsync(new MenuPopup());
        }
    }
}