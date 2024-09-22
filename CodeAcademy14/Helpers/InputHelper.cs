

/// <summary>
/// Provides helper methods for input handling in the console application.
/// </summary>
public static class InputHelper
{
    /// <summary>
    /// Reads a line from the console with the specified prompt, validates it using the given validator function, and returns the valid input.
    /// </summary>
    /// <param name="prompt">The prompt to display to the user.</param>
    /// <param name="validator">The validation function to use.</param>
    /// <param name="errorMessage">The error message to display if the input is invalid.</param>
    /// <returns>The valid input from the user.</returns>
    public static string ReadLine(string prompt, Func<string, bool> validator, string errorMessage)
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
        }
    }

    /// <summary>
    /// Reads an integer from the console with the specified prompt, validates it using the given validator function, and returns the valid input.
    /// </summary>
    /// <param name="prompt">The prompt to display to the user.</param>
    /// <param name="validator">The validation function to use.</param>
    /// <param name="errorMessage">The error message to display if the input is invalid.</param>
    /// <returns>The valid integer input from the user.</returns>
    public static int ReadInt(string prompt, Func<int, bool> validator, string errorMessage)
    {
        while (true)
        {
            string input = ReadLine(prompt, s => int.TryParse(s, out _), "Invalid input. Please enter a number.");

            if (int.TryParse(input, out int result) && validator(result))
            {
                return result;
            }

            Console.WriteLine(errorMessage);
        }
    }
}
