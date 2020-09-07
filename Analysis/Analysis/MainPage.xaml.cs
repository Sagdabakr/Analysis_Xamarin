using Analysis.LocalServices;
using Analysis.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Analysis
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        SQLiteAsyncConnection _connection;
        ObservableCollection<Message> UserMessages;
        public MainPage()
        {
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }
        protected async override void OnAppearing()
        {
            UserMessages = new ObservableCollection<Message>(await _connection.Table<Message>().ToListAsync());
            List.ItemsSource = UserMessages;
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
          /*  var UserMessages = new Messages();
            UserMessages.ID = int.Parse(TAbleID.Text);
            UserMessages.UserID = int.Parse(USErId.Text);
            UserMessages.MessageDate = MessageDate.Text;
            UserMessages.Message = Message.Text;
            UserMessages.Favourite = bool.Parse(Favourite.Text);
            await _connection.CreateTableAsync<Messages>();
            await _connection.InsertAsync(UserMessages);
            TAbleID.Text = "";
            Message.Text = "";
            USErId.Text = "";
            MessageDate.Text = "";
            Favourite.Text = "";*/
        }
    }
}
