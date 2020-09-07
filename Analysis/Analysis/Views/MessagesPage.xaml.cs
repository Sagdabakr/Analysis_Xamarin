using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Analysis.ViewModels;
using Analysis.Models;

namespace Analysis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessagesPage : ContentPage
    {
         static MessageViewModel MessageViewModel;
        readonly int currentUser = int.Parse(Application.Current.Properties["UserID"].ToString());
        bool FavTab = false;

        public MessagesPage()
        {
            InitializeComponent();

            MessageViewModel = new MessageViewModel();
        }
        protected async override void OnAppearing()
        {
            
            MessageViewModel.Messages = await MessageViewModel.GetMessage(currentUser);     
            BindingContext = MessageViewModel;
        }

        private async void Menu_Tapped(object sender, EventArgs e)
        {
            await MenuIcon.TranslateTo(100, 0, 200);
           // await MenuIcon.RotateTo(22, 250);
            await PopupNavigation.Instance.PushAsync(new MenuPopup(MenuIcon));
        }

        private async void Star_Tapped(object sender, EventArgs e)
        {
           Message msg = ((sender as Image).GestureRecognizers[0] as TapGestureRecognizer).CommandParameter as Message;

            /*if (msg.IsVisibleStared)

            {
                MessageViewModel.Messages.Find(obj => obj.ID == msg.ID).IsVisibleStared =true;
                MessageViewModel.Messages.Find(obj => obj.ID == msg.ID).IsVisibleStar = false;
           
            }
            else
              MessageViewModel.Messages.Find(obj => obj.ID == msg.ID).IsVisibleStar = true;*/

            if (msg.IsFavourited)
                msg.StarImageSource = "star.png";
            else
                msg.StarImageSource = "stared.png";

            
            int id = msg.ID;
            UserFavMsgModel userFavMsgModel = new UserFavMsgModel()
            {
               UserId = currentUser,
                MessageId = id,
            };
            
            MessageViewModel.FavMessages = await MessageViewModel.PutUserChoice(userFavMsgModel);
         
   
        }

        private async void Ring_Tabbed(object sender, EventArgs e)
        {
                     MessageViewModel.Messages = await MessageViewModel.GetMessage(currentUser);


                      RingTitle.TextColor = Xamarin.Forms.Color.FromHex("#84C5CB");
                            FavTitle.TextColor = Xamarin.Forms.Color.FromHex("#95a5a6");
                            await RingIcon.ScaleTo(0, 150);
                            RingIcon.Source = "bell.png";
                            await RingIcon.ScaleTo(1, 150);
                            if (FavTab)
                            {
                                await FavIcon.ScaleTo(0, 150);
                                FavIcon.Source = "star.png";
                                await FavIcon.ScaleTo(1, 150);
                                FavTab = false;
                            }
        }

        private async void Fav_Tabbed(object sender, EventArgs e)
        {
            


            MessageViewModel.Messages = await MessageViewModel.GetFavMessage(currentUser);


           



               FavTitle.TextColor = Xamarin.Forms.Color.FromHex("#84C5CB");
                  RingTitle.TextColor = Xamarin.Forms.Color.FromHex("#95a5a6");
                  if (!FavTab)
                  {
                      await RingIcon.ScaleTo(0, 150);
                      RingIcon.Source = "menuRing.png";
                      await RingIcon.ScaleTo(1, 150);
                      FavTab = true;
                  }

                  await FavIcon.ScaleTo(0, 150);
                  FavIcon.Source = "stared.png";
                  await FavIcon.ScaleTo(1, 150);
              }


        }
    }
