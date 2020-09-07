using Analysis.LocalServices;
using Analysis.Models;
using Analysis.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Analysis.ViewModels
{
    public class PopupItems
    {
        public string Desc { get; set; }
        public string Image { get; set; }
        public double WidthRequest{ get; set; }
    }
    public class PopupContent
    {

        public string PopupIcon { get; set; }

        public string PopupLabel { get; set; }

        //public ObservableCollection<PopupItems> PopupItems { get; set; }
    }
    public class HomeViewModel : BaseViewModel
    {
        public ObservableCollection<OrganDetail> Organs
        {
            get { return _organs; }
            set { SetProperty(ref _organs, value); }
        }
        private ObservableCollection<OrganDetail> _organs;
         public UserChoice UserChoices
        {
            get { return _userchoices; }
            set { SetProperty(ref _userchoices, value); }
        }
        private UserChoice _userchoices;
        public UserChoice UserEditedChoices
        {
            get { return _usereditedchoices; }
            set { SetProperty(ref _usereditedchoices, value); }
        }
        private UserChoice _usereditedchoices;

        public ObservableCollection<PopupContent> PopupContent { get; set; }
        public ObservableCollection<PopupItems> PopupItems { get; set; }       
      //  public List<Organ> Organs { get; set; }
        public List<UserChoice> InsertedOrgans { get; set; }
        SQLiteAsyncConnection _connection;
     
        public HomeViewModel()
        {
            PopupContent = new ObservableCollection<PopupContent>();
            PopupItems   = new ObservableCollection<PopupItems>();            
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            Organs = new ObservableCollection<OrganDetail>();
            _organs = new ObservableCollection<OrganDetail>();
            UserChoices = new UserChoice();

        }
        string api = App.ServiceURL + "api/";

        /*   public async Task<List<Organ>> GetOrgans(int ID)
           {
                var _organs = (from x in _connection.Table<Organ>()
                         where x.OrganID == ID
                         select x).ToListAsync();

                   // new ObservableCollection<Organ>(_connection.Table<Organ>().FirstAsync(obj=>obj.OrganID==ID); 
               return await _organs;
           }*/
        /* public async void   InsertUserOrgan(int ID)
         {
             UserChoices userChoices = new UserChoices()
             {
                 EyeID = ID
             };

             await _connection.CreateTableAsync<UserChoices>();
             await _connection.InsertAsync(userChoices);

         }*/


        public async Task<ObservableCollection<OrganDetail>> GetOrganDetail(int id)
        {
            OrganService organService = new OrganService();
            var Organs = await organService.GetOrganDetail(id);
            return Organs;
        }

        public async Task<User> GetUser(int userId)
        {
            UserServices userServices = new UserServices();
            var Relatives = await userServices.GetUser(userId);
            return Relatives;
        }
        public async Task<UserChoice> PostUserChoice(UserChoice userChoice)
        {
            UserServices userServices = new UserServices();
            var userchoice = await userServices.PostUserChoice(userChoice);
            return userchoice;
        }
        public async Task<UserChoice> EditUserChoice(EditQuiz editQuiz)
        {
            UserServices userServices = new UserServices();
            var userEditedChoices = await userServices.EditUserChoice(editQuiz);
            return userEditedChoices;
        }

            public ObservableCollection<PopupItems> GetPopupItems(int ID)
        {
            if (ID == 2)
            {
                var PopupItems = new ObservableCollection<PopupItems>
                {

                    new PopupItems  {Image="eye.png",Desc="شكل العين يكون",WidthRequest=200},
                     new PopupItems {Image="eye.png",Desc="شكل العين يكون",WidthRequest=240},
                     new PopupItems {Image="eye.png",Desc="شكل العين يكون",WidthRequest=280}


                };
                return PopupItems;
            }
            if (ID == 3)
            
            {
                var PopupItems = new ObservableCollection<PopupItems>
                {

                    new PopupItems  {Image="nose.png",Desc="شكل الأنف يكون", WidthRequest=200},
                     new PopupItems {Image="nose.png",Desc="شكل الأنف يكون", WidthRequest=240},
                     new PopupItems {Image="nose.png",Desc="شكل الأنف يكون", WidthRequest=280}


                };
                return PopupItems;
            }
            if (ID == 6)
            {
                var PopupItems = new ObservableCollection<PopupItems>
                {

                    new PopupItems  {Image="palm.png",Desc="شكل اليد يكون", WidthRequest=200},
                     new PopupItems {Image="palm.png",Desc="شكل اليد يكون", WidthRequest=240},
                     new PopupItems {Image="palm.png",Desc="شكل اليد يكون", WidthRequest=280}


                };
                return PopupItems;
            }
            if (ID == 4)
            {
                var PopupItems = new ObservableCollection<PopupItems>
                {
                     new PopupItems  {Image="ear.png",Desc="شكل الأذن يكون", WidthRequest=200},
                     new PopupItems {Image="ear.png",Desc="شكل الأذن يكون", WidthRequest=240},
                     new PopupItems {Image="ear.png",Desc="شكل الأذن يكون", WidthRequest=280}
                };
                return PopupItems;
            }
            if (ID == 5)
            {
                var PopupItems = new ObservableCollection<PopupItems>
                {
                     new PopupItems  {Image="hair.png",Desc="شكل الشـعر يكون", WidthRequest=200},
                     new PopupItems {Image="hair.png",Desc="شكل الشـعر يكون", WidthRequest=240},
                     new PopupItems {Image="hair.png",Desc="شكل الشـعر يكون", WidthRequest=280}
                };
                return PopupItems;
            }
            if (ID == 5)
            {
                var PopupItems = new ObservableCollection<PopupItems>
                {
                     new PopupItems  {Image="eyebrow.png",Desc="شكل الحـاجـب يكون", WidthRequest=200},
                     new PopupItems {Image="eyebrow.png",Desc="شكل الحـاجـب يكون", WidthRequest=240},
                     new PopupItems {Image="eyebrow.png",Desc="شكل الحـاجـب يكون", WidthRequest=280}
                };
                return PopupItems;
            }
            if (ID == 7)
            {
                var PopupItems = new ObservableCollection<PopupItems>
                {
                     new PopupItems  {Image="chin.png",Desc="شكل الـذقـن يكون", WidthRequest=200},
                     new PopupItems {Image="chin.png",Desc="شكل الـذقـن يكون", WidthRequest=240},
                     new PopupItems {Image="chin.png",Desc="شكل الـذقـن يكون", WidthRequest=280}
                };
                return PopupItems;
            }
            if (ID == 7)
            {
                var PopupItems = new ObservableCollection<PopupItems>
                {
                     new PopupItems  {Image="lips.png",Desc="شكل الشفاه يكون", WidthRequest=200},
                     new PopupItems {Image="lips.png",Desc="شكل الشفاه يكون", WidthRequest=240},
                     new PopupItems {Image="lips.png",Desc="شكل الشفاه يكون", WidthRequest=280}
                };
                return PopupItems;
            }
            
            else return new ObservableCollection<PopupItems>();
        }

        public ObservableCollection<PopupContent> GetPopupContent(int ID)
        {
            if (ID == 2)
            {
                var PopupContent = new ObservableCollection<PopupContent>
                {
                    new PopupContent
                    {
                        PopupIcon = "eye.png",
                        PopupLabel = "العين",
                    },

                };
                return PopupContent;
            }
            if (ID == 3)
            {
                var PopupContent = new ObservableCollection<PopupContent>
                {
                    new PopupContent
                    {
                        PopupIcon = "nose.png",
                        PopupLabel = "الأنف",
                    },

                };
                return PopupContent;
            }
            if (ID == 6)
            {
                var PopupContent = new ObservableCollection<PopupContent>
                {
                    new PopupContent
                    {
                        PopupIcon = "palm.png",
                        PopupLabel = "الـيـد",
                    },

                };
                return PopupContent;
            }
            if (ID == 4)
            {
                var PopupContent = new ObservableCollection<PopupContent>
                {
                    new PopupContent
                    {
                        PopupIcon = "ear.png",
                        PopupLabel = "الأذن",
                    },

                };
                return PopupContent;
            }
            if (ID == 5)
            {
                var PopupContent = new ObservableCollection<PopupContent>
                {
                    new PopupContent
                    {
                        PopupIcon = "hair.png",
                        PopupLabel = "الـشـعر",
                    },

                };
                return PopupContent;
            }
            if (ID == 5)
            {
                var PopupContent = new ObservableCollection<PopupContent>
                {
                    new PopupContent
                    {
                        PopupIcon = "eyebrow.png",
                        PopupLabel = "الـحـاجـب",
                    },

                };
                return PopupContent;
            }
            if (ID == 7)
            {
                var PopupContent = new ObservableCollection<PopupContent>
                {
                    new PopupContent
                    {
                        PopupIcon = "chin.png",
                        PopupLabel = "الـذقـن",
                    },

                };
                return PopupContent;
            }
            if (ID == 7)
            {
                var PopupContent = new ObservableCollection<PopupContent>
                {
                    new PopupContent
                    {
                        PopupIcon = "lips.png",
                        PopupLabel = "الـشفاه",
                    },

                };
                return PopupContent;
            }
            else return new ObservableCollection<PopupContent>();
           /* 
            if (ID == 0)
            {
                 var PopupContent = new ObservableCollection<PopupContent>
                {
                    new PopupContent
                    {
                        PopupIcon = "eye.png",
                        PopupLabel = "Choose your Eyes",
                        PopupItems = new ObservableCollection<PopupItems>
                    {new PopupItems {Image="eye.png",Desc="Wide Eyes"},
                     new PopupItems {Image="eye.png",Desc="Narrow Eyes"},
                     new PopupItems {Image="eye.png",Desc="Round Eyes" }}
                    },
                   
                };
                return PopupContent;
            }
            if (ID == 1)
            {
                var PopupContent = new ObservableCollection<PopupContent>
                {
                    new PopupContent
                    {PopupIcon= "nose.png", PopupLabel ="Choose your Nose" ,
                    PopupItems = new ObservableCollection<PopupItems>
                    {new PopupItems {Image="nose.png",Desc="Wide Eyes"},
                     new PopupItems {Image="nose.png",Desc="Narrow Eyes"},
                     new PopupItems {Image="nose.png",Desc="Round Eyes" }}
                    },

                };
                return PopupContent;
            }
            else
                PopupContent = new ObservableCollection<PopupContent>();
                return PopupContent;*/
        }

    }
}
