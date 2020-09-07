using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Analysis.ViewModels;
using Analysis.Views.PopupPages;
using Analysis.Models;

namespace Analysis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPopup : PopupPage
    {
        MenuViewModel MenuViewModel;
        Image MenuIcon;
        public MenuPopup(Image _menuIcon)
        {
            InitializeComponent();
            MenuIcon = _menuIcon;
            MenuViewModel = new MenuViewModel();
            MenuViewModel.MenuItems = MenuViewModel.GetMenuItems();

            if (Application.Current.Properties["IsLoggedin"].ToString().Equals("True"))
            {
                MenuViewModel.MenuItems.First(obj => obj.ID == 4 ).PageName = "تـسجـيل الـخروج";
                MenuViewModel.MenuItems.First(obj => obj.ID == 4).PageIcon = "menuLogout.png";
            }
            else
            {
                MenuViewModel.MenuItems.First(obj => obj.ID == 4).PageName = "تـسجـيل الدخـول";
                MenuViewModel.MenuItems.First(obj => obj.ID == 4).PageIcon = "menulogin.png";
            }
            BindingContext = MenuViewModel;
        }
        protected async override void OnDisappearing()
        {
            await MenuIcon.TranslateTo(0, 0, 200);
        }

        
        private async void Back_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.PopAsync();
        }

        private async void Menu_Tabbed(object sender, EventArgs e)
        {
            int ID = int.Parse(((sender as StackLayout).GestureRecognizers[0] as TapGestureRecognizer).CommandParameter.ToString());
            int currentUser = int.Parse(Application.Current.Properties["UserID"].ToString());
            switch (ID)
            {
                case 0: 
                    if(currentUser == 0 )
                    {
                       await  DisplayAlert("Sorry","Please Login First","Thanks");
                    }
                    else
                    {
                        await Navigation.PushAsync(new UserProfileView());
                        await PopupNavigation.PopAsync();
                    }                   
                break;
                case 1:
                    if (currentUser == 0)
                    {
                        await DisplayAlert("Sorry", "Please Login First", "Thanks");
                    }
                    else
                    {
                        await PopupNavigation.PopAsync();
                        await PopupNavigation.Instance.PushAsync(new AddRelative());
                    }                  
                    break;

                case 4:
                    if (currentUser == 0)
                    {
                        await PopupNavigation.PopAsync();
                        await PopupNavigation.Instance.PushAsync(new LoginView());
                    }
                    else
                    {
                        Application.Current.Properties["UserID"] = "0";
                        Application.Current.Properties["IsLoggedin"] = "False";                      
                        await Navigation.PushAsync(new HomePage());
                        await PopupNavigation.PopAsync();
                    }                                
                    break;

                case 3:
                    if (currentUser == 0)
                    {
                        await DisplayAlert("Sorry", "Please Login First", "Thanks");
                    }
                    else
                    {
                        await Navigation.PushAsync(new MessagesPage());
                        await PopupNavigation.PopAsync();
                    }                   
                    break;
                default:
                    await PopupNavigation.PopAsync();
                    break;
            }
        }
    }
}