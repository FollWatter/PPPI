using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace DogApiClient
{
    public class DogApiClient
    {
        private readonly HttpClient _httpClient;

        public DogApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DogApiResponse> Get()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://dog.ceo/api/breeds/image/random");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var dogApiResponse = JsonConvert.DeserializeObject<DogApiResponse>(content);
                    dogApiResponse.StatusCode = (int)response.StatusCode;
                    return dogApiResponse;
                }
                else
                {
                    return new DogApiResponse
                    {
                        Message = $"Failed to retrieve data, status code: {response.StatusCode}",
                        StatusCode = (int)response.StatusCode
                    };
                }
            }
            catch (Exception ex)
            {
                return new DogApiResponse
                {
                    Message = $"Failed to retrieve data, error message: {ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        public async Task<DogApiResponse> Post(Dictionary<string, string> parameters)
        {
            try
            {
                var content = new FormUrlEncodedContent(parameters);
                var response = await _httpClient.PostAsync("https://dog.ceo/api/breeds/image/random", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var dogApiResponse = JsonConvert.DeserializeObject<DogApiResponse>(responseContent);
                    dogApiResponse.StatusCode = (int)response.StatusCode;
                    return dogApiResponse;
                }
                else
                {
                    return new DogApiResponse
                    {
                        Message = $"Failed to retrieve data, status code: {response.StatusCode}",
                        StatusCode = (int)response.StatusCode
                    };
                }
            }
            catch (Exception ex)
            {
                return new DogApiResponse
                {
                    Message = $"Failed to retrieve data, error message: {ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
