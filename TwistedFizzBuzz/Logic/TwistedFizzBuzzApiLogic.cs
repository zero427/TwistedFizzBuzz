using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;
using TwistedFizzBuzzModels;

namespace TwistedFizzBuzz.Logic
{
    public class TwistedFizzBuzzApiLogic : ITwistedFizzBuzzLogic
    {
        private readonly List<CustomTokenModel> Tokens;
        private readonly string Url;
        private readonly string Action;

        public TwistedFizzBuzzApiLogic()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            Url = configuration?["apiBaseUrl"];
            Action = configuration?["apiAction"];

            Tokens = new List<CustomTokenModel>();
        }

        public async Task FizzBuzz(int start, int end)
        {
            await GetTokens();

            for (int i = start; i <= end; i++)
            {
                string result = string.Empty;
                foreach (var token in Tokens)
                {
                    if (i % token.Divisor == 0)
                    {
                        result += token.Token.ToString();
                    }
                }

                Console.WriteLine(string.IsNullOrEmpty(result) ? i.ToString() : result);
            }
        }

        public async Task FizzBuzz(int[] elements)
        {
            await GetTokens();

            foreach (int element in elements)
            {
                string result = string.Empty;
                foreach (var token in Tokens)
                {
                    if (element % token.Divisor == 0)
                    {
                        result += token.Token.ToString();
                    }
                }

                Console.WriteLine(string.IsNullOrEmpty(result) ? element.ToString() : result);
            }
        }

        public async Task GetTokens()
        {
            //string apiBaseUrl = "https://rich-red-cocoon-veil.cyclic.app/";

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Url);
                HttpResponseMessage response = await httpClient.GetAsync(Action);
                
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    TwistApiResponseModel model = JsonConvert.DeserializeObject<TwistApiResponseModel>(responseBody);
                    Tokens.Add(new CustomTokenModel
                    {
                        Divisor = model.Multiple,
                        Token = model.Word
                    });
                }
                else
                {
                    Console.WriteLine($"API Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
        }
    }
}
