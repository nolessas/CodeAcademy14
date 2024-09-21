using System;

namespace CodeAcademy14.Helpers
{
    public static class InputHelper
    {
        public static string GetValidInput(string prompt, Func<string, bool> validator, string errorMessage)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (input?.ToLower() == "q")
                {
                    throw new OperationCanceledException("User cancelled the operation.");
                }

                if (validator(input))
                {
                    return input;
                }

                Console.WriteLine(errorMessage);
                Console.WriteLine("Press 'Q' to quit or any other key to try again.");
                if (Console.ReadKey().Key == ConsoleKey.Q)
                {
                    throw new OperationCanceledException("User cancelled the operation.");
                }
                Console.WriteLine();
            }
        }
    }
}