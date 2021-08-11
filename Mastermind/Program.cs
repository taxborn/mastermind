// Created by: Braxton Fair
// Created on: 03/16/2021
using System;

namespace Mastermind
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Ask the user how long the key should be.
            Console.Write("What is the desired length of the key? (recommended 4): ");
            int length = Convert.ToInt32(Console.ReadLine());

            // Create a game instance.
            Game ourGame = new Game(length);

            // Allow the user to see the key if they desire.
            Console.Write("Do you want to see the key? [y/N]: ");
            char debugInput = Convert.ToChar(Console.ReadLine());

            // Print the key if they want it, usually used for debugging purposes.
            if (debugInput == 'Y' || debugInput == 'y')
            {
                Console.WriteLine("The key is: " + new String(ourGame.Key));
            }

            // Main game loop.
            while (true)
            {
                Console.WriteLine("Make your guess.");

                // Get the users input.
                string userInput = Console.ReadLine();

                // Make sure that the users input is the same as the key length, otherwise
                // bad things happen.
                if (userInput.Length != ourGame.Length)
                {
                    Console.WriteLine("Invalid input. Your guesses need to be of length " + ourGame.Length + ".");

                    continue;
                }

                // Compare the user input to the key.
                string output = ourGame.Compare(userInput);

                // Print the output of the comparison.
                Console.Write(output);

                // If the users input was correct, print out a success message and break from the loop.
                if (output == Utility.CorrectString(ourGame.Length))
                {
                    Console.WriteLine("\nYou won! The key was: " + new String(ourGame.Key) + " and you figured it out in " + ourGame.Guesses + " tries!");

                    break;
                }

                Console.WriteLine("... Try again!\n\n");
            }
        }
    }
}
