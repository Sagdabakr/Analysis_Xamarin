using System;
using System.Collections.Generic;
using System.Text;
using Analysis.Services;
using Analysis.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Xamarin.Forms;
using System.IO;

namespace Analysis.ViewModels
{
    class RegisterViewModel : BaseViewModel
    {
        public User User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        private User _user;
        public string userimg
        {
            get { return _userimg; }
            set { SetProperty(ref _userimg, value); }
        }

        private string _userimg;


        public RegisterViewModel()
        {
            User = new User();
            _user = new User();
            
        }

        public async Task<User> Register(User user)
        {
            UserServices userServices = new UserServices();
            var userData = await userServices.Register(user);
            return userData;
        }   

        public async Task<string> UploadImage(Stream image, string fileName)
        {
            UserServices userServices = new UserServices();
            var userimage =await userServices.UploadImage(image,fileName);
            return userimage;

        }

    }
}
