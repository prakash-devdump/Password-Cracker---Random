using System;
using System.Security.Cryptography;

class PasswordCracker
{
    public static void Main()
    {
        Console.WriteLine("Enter Your Password");
        string userInput = Console.ReadLine();

        // Check whether user input is a number
        bool inputParsing = int.TryParse(userInput, out int parsedInput);

        if (!inputParsing)
        {
            Console.WriteLine("Enter Proper Value");
            return;
            // Have to add run again
        }

        string stringedInput = Convert.ToString(parsedInput);
        string computerPassword = Convert.ToString(RandomNumber(stringedInput));

        while (stringedInput != computerPassword)
        {
            computerPassword = Convert.ToString(RandomNumber(stringedInput));
            Console.WriteLine();
            Console.WriteLine("Trying to Crack the Password");
            Console.WriteLine();
            Console.WriteLine(computerPassword);

            if (stringedInput == computerPassword)
            {
                Console.WriteLine("We Cracked the Password");
                Console.WriteLine($"User Password is {stringedInput} and Computer Password is {computerPassword}");
            }
        }
    }

    public static long RandomNumber(string userInput)
    {
        long comPassword = 0;
        Random randomGenerator = new Random();
        int passwordLength = userInput.Length;
        comPassword = randomGenerator.Next(10);
        long lengthIndex = 1;

        while (passwordLength > lengthIndex)
        {
            if (lengthIndex <= passwordLength)
            {
                comPassword *= 10;
            }
            comPassword += randomGenerator.Next(10);
            lengthIndex++;
        }
        return comPassword;
    }
}