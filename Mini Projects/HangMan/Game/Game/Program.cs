using System;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "apple", "ball", "cat", "dog" };

            Random r = new Random();
            string word = words[r.Next(words.Length)];

            int lives = 6;
            char[] display = new char[word.Length];
            char[] guessed = new char[26];
            int guessCount = 0;

           
            for (int i = 0; i < display.Length; i++)
            {
                display[i] = '_';
            }

            Console.WriteLine("Welcome to C# Hangman");
            Console.WriteLine();

            while (lives > 0)
            {
                Console.Write("Word: ");
                Console.WriteLine(display);

                Console.WriteLine("Lives Left: " + lives);
                Console.Write("Guessed: ");
                for (int i = 0; i < guessCount; i++)
                    Console.Write(guessed[i] + ",");
                Console.WriteLine();

                Console.Write("Guess a letter: ");
                char c;
                bool valid = char.TryParse(Console.ReadLine(), out c);

                if (!valid)
                {
                    Console.WriteLine("Please enter a valid letter");
                    continue;
                }

                bool found = false;

                for (int i = 0; i < word.Length; i++)
                {
                    int x = 0;
                    if (word[i] == c)
                    {
                       display[i] = c;
                        found = true;
                    }

                }
               

                guessed[guessCount++] = c;

                if (!found)
                {
                    lives--;
                    Console.WriteLine("Wrong guess!");
                }
                else Console.WriteLine("Right Guess!!!");

                
                if (!display.Contains('_'))
                {
                    Console.WriteLine("\nYou Win!");
                    Console.WriteLine("Word was: " + word);
                    break;
                }

                Console.WriteLine();
            }

            if (lives == 0)
            {
                Console.WriteLine("\nYou Lost!");
                Console.WriteLine("Word was: " + word);
            }
        }
    }
}
