using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using KomunikatorTekstowy.Models;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace KomunikatorTekstowy.Sevices
{
    class AzureDataStore :IDataStore<UserDetailData>, IDataMessage<UserMessage>
    {
        HttpClient client;
        IEnumerable<UserDetailData> items;
        IEnumerable<UserMessage> mess;
        string url = @"https://192.168.0.107:45455/api/item";
        public AzureDataStore()
        {
            var insecHandler = GetInsecureHandler();
            client = new HttpClient(insecHandler);
            //client = new HttpClient(GetInsecureHandler());
            client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");

            items = new List<UserDetailData>();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
        public async Task<IEnumerable<UserDetailData>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"/api/item");
                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<UserDetailData>>(json));
                //var response = await client.GetAsync($"api/item");
                //if (response.IsSuccessStatusCode)
                //{
                //    var json = await response.Content.ReadAsStringAsync();
                //    items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<UserDetailData>>(json));
                //}

            }

            return items;
        }
        public async Task<UserDetailData> FindItemAsync(string loginName)
        {
            if(!string.IsNullOrEmpty(loginName) && IsConnected)
            {
                var json = await client.GetStringAsync($"api/item/{loginName}");
                return await Task.Run(() => JsonConvert.DeserializeObject<UserDetailData>(json));
            }
            return null;
        }
        public async Task<UserDetailData> GetItemAsync(string id)
        {
            if (id != null && IsConnected)
            {
                var json = await client.GetStringAsync($"api/item/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<UserDetailData>(json));
            }

            return null;
        }

        public async Task<bool> AddItemAsync(UserDetailData item)
        {
            if (item == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await client.PostAsync($"api/item", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateItemAsync(UserDetailData item)
        {
            if (item == null || item.UserId == null || !IsConnected)
                return false;

            //var serializedItem = JsonConvert.SerializeObject(item);
            //var buffer = Encoding.UTF8.GetBytes(serializedItem);
            //var byteContent = new ByteArrayContent(buffer);


            //var response = await client.PutAsync(new Uri($"api/item/{item.Id}"), byteContent);
            var serializedItem = JsonConvert.SerializeObject(item);
            var response = await client.PostAsync($"{url}/{item.UserId}", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            if (id == null && !IsConnected)
                return false;

            var response = await client.DeleteAsync($"api/item/{id}");

            return response.IsSuccessStatusCode;
        }
        // This method must be in a class in a platform project, even if
        // the HttpClient object is constructed in a shared project.
        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain,
           errors) =>
            {
                return true;
            };
            return handler;
        }

        public async Task<bool> AddMessageAsync(UserMessage mess)
        {
            if (mess == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(mess);
            var response = await client.PostAsync($"api/messages", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<UserMessage> GetMessageAsync(string id)
        {
            if (id != null && IsConnected)
            {
                var json = await client.GetStringAsync($"api/messages/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<UserMessage>(json));
            }

            return null;
        }

        public async Task<IEnumerable<UserMessage>> GetMessagesAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"/api/messages");
                mess = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<UserMessage>>(json));    

            }

            return mess;
        }
    }
}

