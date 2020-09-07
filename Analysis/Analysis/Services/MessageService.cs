using Analysis.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Analysis.Services
{
    public class MessageService
    {
        HttpClient client;
        public MessageService()
        {

            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.ServiceURL}");
        }
        string api = App.ServiceURL + "api/";
        public async Task<List<Message>> GetMessage(int id)
        {
            var httpClient = new HttpClient();
            var URL = string.Format(api + "{0}{1}", "Messages/", id);
            var ResponseMessage = await httpClient.GetStringAsync(URL);
            ResponseMessage = ResponseMessage.Replace("\\", "");
            List<Message> usermsg =
                JsonConvert.DeserializeObject<List<Message>>(ResponseMessage);
            return usermsg;
        }






        public async Task<UserChoice> PutUserChoice(UserFavMsgModel userFavMsgModel)

        {

            var serializedUser = JsonConvert.SerializeObject(userFavMsgModel);
            var content = new StringContent(serializedUser, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"api/UserChoices/PutUserFavourite", content);
            var result = await response.Content.ReadAsStringAsync();
            var UserFavMSg = await Task.Run(() => JsonConvert.DeserializeObject<UserChoice>(result));
            return UserFavMSg;
        }


        public async Task<List<Message>> GetFavMessage(int id)
        {
            var httpClient = new HttpClient();
            var URL = string.Format(api + "{0}{1}", "Messages/GetFavMessage?id=", id);
            var ResponseMessage = await httpClient.GetStringAsync(URL);
            ResponseMessage = ResponseMessage.Replace("\\", "");
            List<Message> usermsg =
                JsonConvert.DeserializeObject<List<Message>>(ResponseMessage);
            return usermsg;
        }
           
        }
}