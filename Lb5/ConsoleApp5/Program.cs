using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DogApiClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();
            var dogApiClient = new DogApiClient(httpClient);

            // GET
            var dogApiResponseGet = await dogApiClient.Get();
            Console.WriteLine($"Status code: {dogApiResponseGet.StatusCode}");
            Console.WriteLine($"Message: {dogApiResponseGet.Message}");
            Console.WriteLine($"Data: {(dogApiResponseGet.Data != null ? string.Join(",", dogApiResponseGet.Data) : "No data")}");

            // POST
            var parameters = new Dictionary<string, string>
            {
                { "breed", "bulldog" }
            };
            var dogApiResponsePost = await dogApiClient.Post(parameters);
            Console.WriteLine($"Status code: {dogApiResponsePost.StatusCode}");
            Console.WriteLine($"Message: {dogApiResponsePost.Message}");
            Console.WriteLine($"Data: {(dogApiResponsePost.Data != null ? string.Join(",", dogApiResponsePost.Data) : "No data")}");

            Console.ReadKey();
        }
    }
}
