using AppRedarbor.Services.IRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppRedarbor.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        readonly List<T> items;

        // Inyeccion de dependencias se debe importar el IHttpClientFactory
        private readonly IHttpClientFactory _clientFactory;
        public Repository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public Repository() { }

        public async Task<bool> SaveAsync(string url, T itemSave)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            HttpClient httpClient = new HttpClient();

            if (itemSave != null)
                request.Content = new StringContent(JsonConvert.SerializeObject(itemSave), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            else
                return false;
        }

        public async Task<bool> DeleteAsync(string url, int Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, url + Id);
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage response = await httpClient.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            else
                return false;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string url)
        {
            Uri requestUri = new Uri(url);
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient httpClient = new HttpClient(clientHandler);

            var response = await httpClient.GetAsync(requestUri);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                var jsonDeserialize = JsonConvert.DeserializeObject<IEnumerable<T>>(jsonString);
                return jsonDeserialize;
            }
            else
                return null;
        }

        public async Task<T> GetAsync(string url, int Id)
        {
            Uri requestUri = new Uri(url + Id);
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient httpClient = new HttpClient(clientHandler);

            var response = await httpClient.GetAsync(requestUri);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                var jsonDeserialize = JsonConvert.DeserializeObject<T>(jsonString);
                return jsonDeserialize;
            }
            else
                return null;
        }

        public async Task<bool> UpdateAsync(string url, T itemUpdate)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            HttpClient httpClient = new HttpClient();

            if (itemUpdate != null)
                request.Content = new StringContent(JsonConvert.SerializeObject(itemUpdate), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.NoContent)
                return true;
            else
                return false;
        }
        public async Task<IEnumerable<T>> GetAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
