using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NintendoHangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Nintendo Hangman Game");

            // This is the array that holds the player names.
            string[] guess = new string[] { "Mario", "Bowser", "Link", "Kirby", "Yoshi" };

            Random rand = new Random();
            int select = rand.Next(guess.Length);

            string guessedWord = guess[select].ToLower(); // Convert to lowercase


           /* foreach (char ch in guessedWord)
            {
                Console.Write("_");
            }
           */

            Console.WriteLine("Hello! What's your name?");
            string playerName = Console.ReadLine();
            Console.WriteLine("Welcome, " + playerName + "! Let's play Hangman.");

            Console.WriteLine("Guess the right word before the man gets hanged");
            Console.WriteLine("The number of characters to guess is " + guessedWord.Length);

            char[] answerBook = new char[guessedWord.Length];

            for (int answerBookIndex = 0; answerBookIndex < answerBook.Length; answerBookIndex++)
            {
                answerBook[answerBookIndex] = '_';
            }

            int allowedGuess = guessedWord.Length + 5;

            while (allowedGuess > 0)
            {
                for (int answerBookIndex = 0; answerBookIndex < answerBook.Length; answerBookIndex++)
                {
                    Console.Write(answerBook[answerBookIndex]);
                }
                Console.WriteLine();
                Console.WriteLine("Enter a letter: ");
                string playerInput = Console.ReadLine();

                if (!string.IsNullOrEmpty(playerInput) && guessedWord.Contains(playerInput[0]))
                {
                    Console.WriteLine("Correct!");

                    int currentIndex = guessedWord.IndexOf(playerInput[0]);
                    answerBook[currentIndex] = playerInput[0];
                }
                else
                {
                    Console.WriteLine("Wrong!");
                    allowedGuess--; // Decrement the allowedGuess on wrong guess.
                    Console.WriteLine("Remaining guesses: " + allowedGuess);
                }
                if (!answerBook.Contains('_'))
                {
                    Console.WriteLine("The word is " + guessedWord);
                    Console.WriteLine("Win");
                    break;
                }
                if (allowedGuess == 0)
                {
                    Console.WriteLine("Sorry, you couldn't save the man. The correct word was: " + guessedWord);
                    break;
                }
            }

            }
    }
}
