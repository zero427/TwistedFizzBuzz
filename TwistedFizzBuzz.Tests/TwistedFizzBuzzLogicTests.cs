using TwistedFizzBuzz.Logic;

namespace TwistedFizzBuzz.Tests
{
    public class TwistedFizzBuzzLogicTests
    {
        [Fact]
        public void FizzBuzz_WithStartAndEnd_ShouldPrintCorrectly()
        {
            // Arrange
            int start = 1;
            int end = 15;
            var expectedOutput = new List<string>
            {
                "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz"
            };

            // Act
            var output = CaptureConsoleOutput(() =>
            {
                var logic = new TwistedFizzBuzzLogic();
                logic.FizzBuzz(start, end).Wait();
            });

            // Assert
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void FizzBuzz_WithElementsArray_ShouldPrintCorrectly()
        {
            // Arrange
            int[] elements = { 3, 5, 15, 7, 11 };
            var expectedOutput = new List<string> { "Fizz", "Buzz", "FizzBuzz", "7", "11" };

            // Act
            var output = CaptureConsoleOutput(() =>
            {
                var logic = new TwistedFizzBuzzLogic();
                logic.FizzBuzz(elements).Wait();
            });

            // Assert
            Assert.Equal(expectedOutput, output);
        }

        // Helper method to capture the console output during testing
        private List<string> CaptureConsoleOutput(Action action)
        {
            var consoleOutput = new List<string>();
            var originalConsoleOut = Console.Out;
            using (var consoleOutputWriter = new StringWriter())
            {
                Console.SetOut(consoleOutputWriter);
                action.Invoke();
                consoleOutput.AddRange(consoleOutputWriter.ToString().Trim().Split(Environment.NewLine));
            }
            Console.SetOut(originalConsoleOut);
            return consoleOutput;
        }
    }
}
