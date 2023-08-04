using Microsoft.Extensions.Configuration;
using TwistedFizzBuzzModels;

namespace TwistedFizzBuzz.Logic
{
    public class CustomTwistedFizzBuzzLogic : ITwistedFizzBuzzLogic
    {
        private readonly List<CustomTokenModel> Tokens;

        public CustomTwistedFizzBuzzLogic()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            var items = configuration.GetSection("custom:tokens").GetChildren();
            Tokens = items.Select(i => new CustomTokenModel { Token =  i["token"], Divisor = Convert.ToInt32(i["divisor"]) }).ToList();
        }

        public async Task FizzBuzz(int start, int end)
        {

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
    }
}
