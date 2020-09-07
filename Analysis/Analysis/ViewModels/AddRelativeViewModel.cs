using System;
using System.Collections.Generic;
using System.Text;
using Analysis.Services;
using Analysis.Models;
using System.Threading.Tasks;

namespace Analysis.ViewModels
{
    public class AddRelativeViewModel : BaseViewModel
    {
        public User User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        private User _user;

        public AddRelativeViewModel()
        {
            User = new User();
            _user = new User();
        }
        public async Task<User> CreateRelative(User Relative, int userID)
        {
            UserServices userServices = new UserServices();
            var Relatives = await userServices.CreateRelative(Relative, userID);
            return Relatives;
        }
    }
}
