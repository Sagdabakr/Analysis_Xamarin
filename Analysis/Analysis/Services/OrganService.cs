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
   public class OrganService 
    {
        HttpClient client;
        public OrganService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.ServiceURL}");
        }
        string api = App.ServiceURL + "api/";
        public async Task<ObservableCollection<Organ>> GetOrgan(int id)
        {
            var httpClient = new HttpClient();
            var URL = string.Format(api + "{0}", "Organs/GetOrgan");
            var ResponseMessage = await httpClient.GetStringAsync(URL);
            ResponseMessage = ResponseMessage.Replace("\\", "");
            ObservableCollection<Organ> Organs =
                JsonConvert.DeserializeObject<ObservableCollection<Organ>>(ResponseMessage);
            return Organs;
        }
        public async Task<ObservableCollection<OrganDetail>> GetOrganDetail(int id)
        {
            var httpClient = new HttpClient();
            var URL = string.Format(api + "{0}{1}", "OrganDetails/", id);
            var ResponseMessage = await httpClient.GetStringAsync(URL);
            ResponseMessage = ResponseMessage.Replace("\\", "");
            ObservableCollection<OrganDetail> Organs =
                JsonConvert.DeserializeObject<ObservableCollection<OrganDetail>>(ResponseMessage);
            return Organs;
        }
    }
}
