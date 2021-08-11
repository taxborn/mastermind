// Created by: Braxton Fair
// Created on: 03/16/2021
using System;

namespace Mastermind
{
    public class Game
    {
        // Our variables for the game.
        public char[] Key { get; set; }
        public int Length { get; set; }
        public int Guesses { get; set; }

        // Our constructors.
        public Game(int length)
        {
            this.Length = length;
            this.Guesses = 0;

            // Generate a random key
            this.Key = Utility.RandomAlphaNumeric(length);
        }
        
        // Create a default game of length 4.
        public Game() : this(4) { }

        // Compare the user input to the key, and return the comparison string.
        public string Compare(string userInput)
        {
            // Create the result of the comparison, a character list this.Length long.
            char[] output = new char[this.Length];

            // Create a string version of the key for comparison purposes
            string stringVersionOfKey = new String(this.Key);

            // Loop this.Length iterations, and compare.
            for (var i = 0; i < this.Length; i++)
            {
                // First check if the characters between the input and key are the exact same.
                if (userInput[i] == this.Key[i])
                {
                    output[i] = 'X';
                }
                // Otherwise, if the key contains that certain letter of the input, we print an O.
                else if (stringVersionOfKey.Contains(userInput[i]))
                {
                    output[i] = 'O';
                }
                // Finally, if the key doesn't contain the character we are guessing, output a question mark.
                else
                {
                    output[i] = '?';
                }
            }

            // Increment the guesses counter
            this.Guesses++;

            // Return a string version of the output array.
            return new String(output);
        }
    }
}
