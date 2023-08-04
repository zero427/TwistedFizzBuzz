namespace TwistedFizzBuzz.Logic
{
    public class TwistedFizzBuzzLogic: ITwistedFizzBuzzLogic
    {

        public async Task FizzBuzz(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                string result = (i % 3 == 0, i % 5 == 0) switch
                {
                    (true, true) => "FizzBuzz",
                    (true, false) => "Fizz",
                    (false, true) => "Buzz",
                    _ => i.ToString()
                };

                Console.WriteLine(string.IsNullOrEmpty(result) ? i.ToString() : result);
            }
        }

        public async Task FizzBuzz(int[] elements)
        {
            foreach (int element in elements)
            {
                string result = (element % 3 == 0, element % 5 == 0) switch
                {
                    (true, true) => "FizzBuzz",
                    (true, false) => "Fizz",
                    (false, true) => "Buzz",
                    _ => element.ToString()
                };

                Console.WriteLine(string.IsNullOrEmpty(result) ? element.ToString() : result);
            }
        }
    }
}
