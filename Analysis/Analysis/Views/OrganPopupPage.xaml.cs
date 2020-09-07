using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Analysis.ViewModels;
namespace Analysis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrganPopupPage : PopupPage
    {
        int OrganID;
        HomeViewModel OrganPopUpViewModel;
        Frame Frame;
        public OrganPopupPage(int _organID, Frame _frame)
        {
            InitializeComponent();
            OrganID = _organID;
            Frame = _frame;
            OrganPopUpViewModel = new HomeViewModel();
            OrganPopUpViewModel.PopupContent = OrganPopUpViewModel.GetPopupContent(_organID);
            OrganPopUpViewModel.PopupItems = OrganPopUpViewModel.GetPopupItems(_organID);
            BindingContext = OrganPopUpViewModel;
        }
        protected async override void OnDisappearing()
        {
            
            await Frame.ScaleTo(1,150);
        }
        

    }
}