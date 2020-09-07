using Analysis.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Analysis.Services;
using System.IO;
using System.Net.Http;
using Xamarin.Forms;
using Analysis.LocalServices;

namespace Analysis.ViewModels
{
   
    public class UserProfileViewModel : BaseViewModel
    {
        SQLiteAsyncConnection _connection;
        public User User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        private User _user;
        public List<Message> Messages
        {
            get { return _messages; }
            set { SetProperty(ref _messages, value); }

        }
        private List<Message> _messages;
        public List<User> Relatives
        {
            get { return _relatives; }
            set { SetProperty(ref _relatives, value); }
        }

        private List<User> _relatives;

        public List<OrganDetail> OrganDetails
        {
            get { return _OrganDetails; }
            set { SetProperty(ref _OrganDetails, value); }
        }
        private List<OrganDetail> _OrganDetails;




        private string _lblText;
        public string LblText
        {
            get { return _lblText; }
            set { SetProperty(ref _lblText, value); }
        }
        private string _lblTextmsg;
        public string LblTextMsg
        {
            get { return _lblTextmsg; }
            set { SetProperty(ref _lblTextmsg, value); }
        }
        public UserProfileViewModel()
        {
            User = new User();
            Messages = new List<Message>();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            _user = new User();
            OrganDetails = new List<OrganDetail>();
            Relatives = new List<User>();
            _relatives = new List<User>();
        }

/*       public async Task<User> CreateRelative(User user , int basicUser)
        {
            UserServices userServices = new UserServices();
            var userData = await userServices.CreateRelative(user , basicUser);
            return userData;
        }*/

        public async Task<List<User>> GetUserRelatives(int userId)
        {
            UserServices userServices = new UserServices();
            var Relatives = await userServices.GetUserRelatives(userId);
            return Relatives;
        }
        public async Task<List<User>> SQLiteGetUserRelatives()
        {
           foreach(User Item in Relatives)
            {
                await _connection.CreateTableAsync<User>();
                await _connection.InsertAsync(Item);
            }
            return new List<User>(await _connection.Table<User>().ToListAsync());
        }
        public async Task<User> EditUser(User user , int userId)
        {
            UserServices userServices = new UserServices();
            var Relatives = await userServices.EditUser(user,userId);
            return Relatives;
        }
        public async Task<string> UploadImage(Stream image, string fileName)
        {
            UserServices userServices = new UserServices();
            var userimage = await userServices.UploadImage(image, fileName);
            return userimage;

        }
        public async Task<User> GetUser(int userId)
        {
            UserServices userServices = new UserServices();
            var Relatives = await userServices.GetUser(userId);
            return Relatives;
        }


        ///////////////////////////////////
        public async Task<List<OrganDetail>> GetUserChoice(int id)
        {
            UserServices userServices = new UserServices();
            var userresult = await userServices.GetUserChoice(id);
            return userresult;

        }
        public  async Task<HttpResponseMessage> DeleteRelative(int id)
        {
            UserServices userServices = new UserServices();
            var respone = await userServices.DeleteRelative(id);
            return respone;
        }

        public async Task<List<Message>> GetMessage(int id)
        {
            MessageService messageService = new MessageService();

            var msgs = await messageService.GetMessage(id);


            return msgs;
        }

    }

}
