public static class InputValidator
{
    public static string GetValidInput(string prompt, Func<string, bool> validator, string errorMessage)
    {
        string input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input is required.");
                continue;
            }

            if (!validator(input))
            {
                Console.WriteLine(errorMessage);
                continue;
            }

            return input;
        } while (true);
    }
}
