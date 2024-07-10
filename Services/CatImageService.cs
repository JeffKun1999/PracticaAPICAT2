using Newtonsoft.Json;
using PracticaAPICAT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaAPICAT2.Services
{
    public class CatImageService
    {
        private readonly HttpClient _httpClient;

        public CatImageService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<CatImage> GetRandomCatImage()
        {
            CatImage catImage = null;
            HttpResponseMessage response;
            string requestUrl = "https://api.thecatapi.com/v1/images/search";

            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                response = await _httpClient.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var catImages = JsonConvert.DeserializeObject<List<CatImage>>(json);
                    catImage = catImages?.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }

            return catImage;

        }
    }
}