using AppRedarbor.Models;
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
    public class EmployeeRepository : IEmployeeRepository
    {
        public async Task<bool> SaveAsync(string url, Employee itemSave)
        {
            if (itemSave == null) return false;

            try
            {
                Uri requestUri = new Uri(url);
                HttpClientHandler clientHandler = new HttpClientHandler();

                HttpClient httpClient = new HttpClient(clientHandler);
                var contentJson = new StringContent(JsonConvert.SerializeObject(itemSave), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(requestUri, contentJson);

                if (response.StatusCode == HttpStatusCode.OK)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> DeleteAsync(string url, int Id)
        {
            try
            {
                Uri requestUri = new Uri(url + Id);
                HttpClientHandler clientHandler = new HttpClientHandler();

                HttpClient httpClient = new HttpClient(clientHandler);

                var response = await httpClient.DeleteAsync(requestUri);

                if (response.StatusCode == HttpStatusCode.NoContent)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Employee>> GetAllAsync(string url)
        {
            try
            {
                Uri requestUri = new Uri(url);
                HttpClientHandler clientHandler = new HttpClientHandler();

                HttpClient httpClient = new HttpClient(clientHandler);

                var response = await httpClient.GetAsync(requestUri);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();

                    var jsonDeserialize = JsonConvert.DeserializeObject<IEnumerable<Employee>>(jsonString);
                    return jsonDeserialize;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Employee> GetAsync(string url, int Id)
        {
            Uri requestUri = new Uri(url + Id);
            HttpClientHandler clientHandler = new HttpClientHandler();

            HttpClient httpClient = new HttpClient(clientHandler);

            var response = await httpClient.GetAsync(requestUri);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                var jsonDeserialize = JsonConvert.DeserializeObject<Employee>(jsonString);
                return jsonDeserialize;
            }
            else
                return null;
        }

        public async Task<bool> UpdateAsync(string url, Employee itemUpdate)
        {
            if (itemUpdate == null) return false;

            try
            {
                Uri requestUri = new Uri(url);
                HttpClientHandler clientHandler = new HttpClientHandler();

                HttpClient httpClient = new HttpClient(clientHandler);
                string json = JsonConvert.SerializeObject(itemUpdate);
                var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(requestUri, contentJson);

                if (response.StatusCode == HttpStatusCode.NoContent)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}