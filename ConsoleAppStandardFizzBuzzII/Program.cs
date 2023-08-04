
using TwistedFizzBuzz.Logic;

namespace ConsoleAppStandardFizzBuzz
{
    partial class Program
    {
        static async Task Main(string[] args)
        {

            ITwistedFizzBuzzLogic twistedFizzBuzzLogic = new CustomTwistedFizzBuzzLogic();
            
            int[] numbers = Enumerable.Range(-20, 127).ToArray();
            await twistedFizzBuzzLogic.FizzBuzz(numbers);

        }
    }
}