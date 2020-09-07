using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Analysis.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Xamarin.Forms;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Analysis.Services
{
    public class UserServices
    {
        readonly HttpClient client;
        public UserServices()
        {
            client = new HttpClient()
            { 
                BaseAddress = new Uri($"{App.ServiceURL}")
            };
        }
       string api = App.ServiceURL + "api/";
        public async Task<User> Login(User user)
        {
         
            var serializedUser = JsonConvert.SerializeObject(user);
            var content = new StringContent(serializedUser, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"api/Users/Login", content);
            var result = await response.Content.ReadAsStringAsync();
            var User = await Task.Run(() => JsonConvert.DeserializeObject<User>(result));
            return User;
        }

        public async Task<User> Register(User user)
        {
            var serializedUser = JsonConvert.SerializeObject(user);
            var content = new StringContent(serializedUser, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"api/Users/Register", content);
            var result = await response.Content.ReadAsStringAsync();
            var registeredUser = await Task.Run(() => JsonConvert.DeserializeObject<User>(result));
            return registeredUser;
        }


        public async Task<List<User>> GetUserRelatives(int UserId)
        {
            var httpClient = new HttpClient();
            var URL = string.Format(api + "{0}{1}", "Users/GetUserRelatives?UserID=", UserId);
            var ResponseMessage = await httpClient.GetStringAsync(URL);
            ResponseMessage = ResponseMessage.Replace("\\", "");

            List<User> Relatives =
                JsonConvert.DeserializeObject<List<User>>(ResponseMessage);           
            return Relatives;
        }

        public async Task<User> GetUser(int UserId)
        {
            var httpClient = new HttpClient();
            var URL = string.Format(api + "{0}{1}", "Users/", UserId);
            var ResponseMessage = await httpClient.GetStringAsync(URL);
            ResponseMessage = ResponseMessage.Replace("\\", "");

            User user =
                JsonConvert.DeserializeObject<User>(ResponseMessage);
            return user;
        }
      
        public async Task<User> CreateRelative(User user , int basicUser)
        {           
            var serializedUser = JsonConvert.SerializeObject(user);
            var content = new StringContent(serializedUser, Encoding.UTF8, "application/json");
          //  var URL = string.Format($"/Users/CreateRelative?BasicUserID=, {basicUser} ");
            var response = await client.PostAsync($"api/Users/CreateRelative?BasicUserID={basicUser} ", content );
            var result = await response.Content.ReadAsStringAsync();
            var Relative = await Task.Run(() => JsonConvert.DeserializeObject<User>(result));
            return Relative;
        }
        public async Task<User> EditUser(User user , int userID)
        {           
            var serializedUser = JsonConvert.SerializeObject(user);
            var content = new StringContent(serializedUser, Encoding.UTF8, "application/json");
          //  var URL = string.Format($"/Users/CreateRelative?BasicUserID=, {basicUser} ");
            var response = await client.PutAsync($"api/Users/{userID}", content );
            var result = await response.Content.ReadAsStringAsync();
            var User = await Task.Run(() => JsonConvert.DeserializeObject<User>(result));
            return User;
        }



        public async Task<string> UploadImage(Stream image, string fileName)
        {
            string url = "http://sagdabakr-001-site1.dtempurl.com/" + "api/Users/UploadImage";
            HttpContent fileStreamContent = new StreamContent(image);
            fileStreamContent.Headers.ContentDisposition =
                new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data")
                { Name = "file", FileName = fileName };
            fileStreamContent.Headers.ContentType = new System.Net.Http.Headers.
                MediaTypeHeaderValue("application/octet-stream");
            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {
                formData.Add(fileStreamContent);
                var response = await client.PostAsync(url, formData);
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
       

        }
  




   
        ///////////////////////
        public async Task<UserChoice> PostUserChoice(UserChoice userChoice)
        {
            var serializedUser = JsonConvert.SerializeObject(userChoice);
            var content = new StringContent(serializedUser, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"/api/UserChoices", content);
            var result = await response.Content.ReadAsStringAsync();
            var userchoice = await Task.Run(() => JsonConvert.DeserializeObject<UserChoice>(result));
            return userchoice;

        }


        public async Task<List<OrganDetail>> GetUserChoice(int id)
        {
            var httpClient = new HttpClient();
            var URL = string.Format(api + "{0}{1}", "UserChoices/", id);
            var ResponseMessage = await httpClient.GetStringAsync(URL);
            ResponseMessage = ResponseMessage.Replace("\\", "");
            List<OrganDetail> DescribeOrgans =
                JsonConvert.DeserializeObject<List<OrganDetail>>(ResponseMessage);
            return DescribeOrgans;

        }
        public async Task<HttpResponseMessage> DeleteRelative(int id)
        {
            var client = new HttpClient();
            var uri = string.Format(api + "{0}{1}", "Users/", id);            
            var result = await client.DeleteAsync(uri); 
            if (result.IsSuccessStatusCode) 
            {
                return result; 
            }
            return result;
        /*var httpClient = new HttpClient();
        var URL = string.Format(api + "{0}{1}", "/Users/", id);
        var ResponseMessage = await httpClient.GetStringAsync(URL);
        ResponseMessage = ResponseMessage.Replace("\\", "");
        List<OrganDetail> DescribeOrgans =
            JsonConvert.DeserializeObject<List<OrganDetail>>(ResponseMessage);*/
        }

        public async Task<UserChoice> EditUserChoice(EditQuiz editQuiz)
        {

            var serializedUser = JsonConvert.SerializeObject(editQuiz);
            var content = new StringContent(serializedUser, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"api/UserChoices/EditUserChoice", content);
            var result = await response.Content.ReadAsStringAsync();
            var userchoice = await Task.Run(() => JsonConvert.DeserializeObject<UserChoice>(result));
            return userchoice;

        }


    }
}
