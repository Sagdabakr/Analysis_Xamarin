using Analysis.Models;
using Analysis.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Analysis.ViewModels
{
     public class MessageViewModel : BaseViewModel
    {
        public List<Message> Messages
        {
            get { return _messages; }
            set { SetProperty(ref _messages, value); }
        }
        private List<Message> _messages;


        public UserChoice FavMessages
        {
            get { return _favmessages; }
            set { SetProperty(ref _favmessages, value); }
        }
        private UserChoice _favmessages;

     


        public MessageViewModel()
        {
            _messages = new List<Message>();
            Messages = new List<Message>();
            FavMessages = new UserChoice();
          
        }



        public async Task<List<Message>> GetMessage(int id)
        {
            MessageService messageService = new MessageService();
            var FavMsgs = await messageService.GetFavMessage(id);
            var msgs = await messageService.GetMessage(id);
            /*foreach (var item in FavMsgs)
            {
                if (msgs.Any(obj => obj.ID == item.ID))
                    msgs.First(obj => obj.ID == item.ID).IsFavourited = true;
                    
            }*/
            foreach (var item in msgs)
            {
                if (FavMsgs.Any(obj => obj.ID == item.ID))
                {
                    msgs.First(obj => obj.ID == item.ID).IsFavourited = true;
                    msgs.First(obj => obj.ID == item.ID).StarImageSource = "stared.png";

                }
                else
                    msgs.First(obj => obj.ID == item.ID).StarImageSource = "star.png";


            }
            return msgs;
        }

        public async Task<UserChoice> PutUserChoice(UserFavMsgModel userFavMsgModel)

        {
            MessageService messageService = new MessageService();
            var msgfav = await messageService.PutUserChoice(userFavMsgModel);
            return msgfav;


        }


        public async Task<List<Message>> GetFavMessage(int id)
        {
            MessageService messageService = new MessageService();
            var FavMsg = await messageService.GetFavMessage(id);
            foreach (var item in FavMsg)
            {
                if (FavMsg.Any(obj => obj.ID == item.ID))
                {
                    FavMsg.First(obj => obj.ID == item.ID).IsFavourited = true;
                    FavMsg.First(obj => obj.ID == item.ID).StarImageSource = "stared.png";

                }
                else
                    FavMsg.First(obj => obj.ID == item.ID).StarImageSource = "star.png";
            }
                return FavMsg;
        }





        }
}
