// Created by: Braxton Fair
// Created on: 03/16/2021
using System;
using System.Text;

namespace Mastermind
{
    public static class Utility
    {
        // Generate a random letter.
        public static char RandomLetter()
        {
            Random random = new Random();

            // When you add a character and an integer, it gets its Unicode(or ASCII?) position and adds to
            // it, so when we add a random number from 0-25, it will get us a random letter from A-Z.
            char randomCharacter = (char) ('A' + random.Next(26));

            return randomCharacter;
        }

        // Generate a random number, returned as a character rather than an integer.
        public static char RandomNumber()
        {
            Random random = new Random();

            // Create a random number from 48-57(Unicode for 0-9) and return it as a char.
            return Convert.ToChar(random.Next(48, 58));
        }

        // Generate a random alphanumeric character.
        public static char RandomAlphaNumeric()
        {
            Random random = new Random();
            
            // Choose a random number from either 0 or 1. If it is zero, return a random letter.
            if (random.Next(2) == 0)
            {
                return Utility.RandomLetter();
            }

            // ... else return a random number.
            return Utility.RandomNumber();
        }

        public static char[] RandomAlphaNumeric(int length)
        {
            // Create a character array the size of our key length
            char[] key = new char[length];

            // This code will generate the key of length this.Length.
            // 
            // To make it randomly choose between a letter or a number, we introduce
            // another RNG to choose either 0 or 1, if it chooses 0, it will generate
            // and add a random letter to they key array. If it chooses 1, it will
            // generate and add a random number to the list.
            for (var i = 0; i < length; i++)
            {
                key[i] = Utility.RandomAlphaNumeric();
            }

            return key;
        }

        // Generate what the correct string given a certain length would look like.
        public static string CorrectString(int length)
        {
            StringBuilder builder = new StringBuilder();

            // Create a string of length 'length', with only X's. This is because X is 
            // what is outputted when the guessed letter is correct itself and is in the 
            // correct place, so a string full of X's would mean that they guessed the
            // correct string.
            builder.Append('X', length);

            return builder.ToString();
        }
    }
}
