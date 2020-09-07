using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Analysis.Models;
using Analysis.Services;
namespace Analysis.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        public User User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        private User _user;

        public LoginViewModel()
        {
            User = new User();
            _user = new User();
        }

        public async Task<User> Login(User user)
        {
            UserServices userServices = new UserServices();
            var userData = await userServices.Login(user);
            return userData;
        }
    }
}
