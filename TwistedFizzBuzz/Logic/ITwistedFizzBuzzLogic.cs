
using TwistedFizzBuzzModels;

namespace TwistedFizzBuzz.Logic
{
    public interface ITwistedFizzBuzzLogic
    {
        Task FizzBuzz(int start, int end);
        Task FizzBuzz(int[] elements);

        //Task<List<CustomTokenModel>> GetTokens();
    }
}
