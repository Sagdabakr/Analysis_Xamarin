using Analysis.ViewModels;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Analysis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShapesPage : PopupPage
    {
        UserProfileViewModel UserProfileViewModel;
        public ShapesPage()
        {
            InitializeComponent();
            UserProfileViewModel = new UserProfileViewModel();
         //   UserProfileViewModel.UserAccountList = UserProfileViewModel.GetUserAccounts();
            BindingContext = UserProfileViewModel;
        }
    }
}