using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Analysis.ViewModels;
using Analysis.Models;
using Rg.Plugins.Popup.Services;

namespace Analysis.Views.PopupPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddRelative : PopupPage
    {
        AddRelativeViewModel AddRelativeViewModel;
        public AddRelative()
        {
            InitializeComponent();
            AddRelativeViewModel = new AddRelativeViewModel();
        }


        private async void Add_Clicked(object sender, EventArgs e)
        {
            var CurrentUser = int.Parse(Application.Current.Properties["UserID"].ToString());
            User user = new User();

            user.Name = RelativeName.Text;
            user.Image = "userprofile.jpg";

            AddRelativeViewModel.User = await AddRelativeViewModel.CreateRelative(user , CurrentUser);
            await Navigation.PushAsync(new UserProfileView());
            await PopupNavigation.PopAsync();          
        }
    }
}