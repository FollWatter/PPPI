using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace DogApiClient
{
    public class DogApiResponse
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public List<string> Data { get; set; }
    }
}

