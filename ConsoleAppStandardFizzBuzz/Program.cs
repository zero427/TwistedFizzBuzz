
using TwistedFizzBuzz.Logic;

namespace ConsoleAppStandardFizzBuzz
{
    partial class Program
    {
        static async Task Main(string[] args)
        {
            
            /// Accept user input for a range of numbers and returns their FizzBuzz output. For example, 1-50, 1-2,000,000,000, or (-2)-(-37).
            ITwistedFizzBuzzLogic twistedFizzBuzzLogic = new TwistedFizzBuzzLogic();
            await twistedFizzBuzzLogic.FizzBuzz(1,50);

            /// Accept user input of a non-sequential set of numbers and returns their FizzBuzz output. For example: -5, 6, 300, 12, 15
            /*ITwistedFizzBuzzLogic twistedFizzBuzzLogic = new TwistedFizzBuzzLogic();
            int[] numbers = { -5, 6, 300, 12, 15 };
            await twistedFizzBuzzLogic.FizzBuzz(numbers);*/

            /// Accept user input for alternative tokens instead of "Fizz" and "Buzz" and alternative divisors instead of 3 and 5. 
            /// For example, 7, 17, and 3 would use "Poem", "Writer", and "College". 
            /// 119 would output "PoemWriter", 51 would output "WriterCollege", 21 would output "PoemCollege, and 357 would output "PoemWriterCollege"
            /*ITwistedFizzBuzzLogic twistedFizzBuzzLogic = new CustomTwistedFizzBuzzLogic();
            int[] numbers = { 119, 51, 21, 357 };
            await twistedFizzBuzzLogic.FizzBuzz(numbers);*/

            ///Accept user input for API generated tokens provided by [https://rich-red-cocoon-veil.cyclic.app/](https://rich-red-cocoon-veil.cyclic.app/)
            /*ITwistedFizzBuzzLogic twistedFizzBuzzLogic = new TwistedFizzBuzzApiLogic();
            await twistedFizzBuzzLogic.FizzBuzz(1,100);*/

        }
    }
}