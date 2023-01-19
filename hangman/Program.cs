﻿using System;
using System.Collections.Generic;
using static System.Random;
using System.Text;

namespace Hangman
{

    internal class Program
    {
        private static void printHangman(int wrong)
        {

            if (wrong == 0)
            {
                Console.WriteLine("\n +---+");
                Console.WriteLine("\n     |");
                Console.WriteLine("\n     |");
                Console.WriteLine("\n     |");
                Console.WriteLine("\n  ====");
            }
            else if (wrong == 1)
            {
                Console.WriteLine("\n  +---+");
                Console.WriteLine("\n  o   |");
                Console.WriteLine("\n      |");
                Console.WriteLine("\n      |");
                Console.WriteLine("\n   ====");

            }

            else if (wrong == 2)
            {
                Console.WriteLine("\n +---+");
                Console.WriteLine("\n o    |");
                Console.WriteLine("\n |    |");
                Console.WriteLine("\n      |");
                Console.WriteLine("\n  ====");
            }
            else if (wrong == 3)
            {
                Console.WriteLine("\n +---+");
                Console.WriteLine("\n o    |");
                Console.WriteLine("\n |\\  |");
                Console.WriteLine("\n      |");
                Console.WriteLine("\n  ====");
            }
            else if (wrong == 4)
            {
                Console.WriteLine("\n  +---+");
                Console.WriteLine("\n  o   |");
                Console.WriteLine("\n /|\\ |");
                Console.WriteLine("\n      |");
                Console.WriteLine("\n  ====");
            }
            else if (wrong == 5)
            {
                Console.WriteLine("\n  +---+");
                Console.WriteLine("\n  o   |");
                Console.WriteLine("\n /|\\ |");
                Console.WriteLine("\n /    |");
                Console.WriteLine("\n  ====");
            }
            else if (wrong == 6)
            {
                Console.WriteLine("\n +---+");
                Console.WriteLine("\n o   |");
                Console.WriteLine("\n/|\\ |");
                Console.WriteLine("\n/ \\ |");
                Console.WriteLine("\n ====");
            }

        }


        private static int printWord(List<char> guessedLetters, string randomWord)
        {
            int counter = 0;
            int rightLetters = 0;
            Console.Write("\r\n");
            foreach (char c in randomWord)
            {
                if (guessedLetters.Contains(c))
                {
                    Console.Write(c + " ");
                    rightLetters++;

                }
                else
                {
                    Console.Write(" ");
                }
            }
            return rightLetters;
        }

        private static void printLines(String randomWord)
        {
            Console.Write("\r");
            foreach (char c in randomWord)
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.Write("\u0305 ");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to hangman! :D");
            Console.WriteLine("-------------------------------------------");

            Random random = new Random();
            List<string> wordDictionary = new List<string> { "stupid", "aired", "trashed", "house", "makeup", "protein", "scrub", "diamond", "rogue", "hypochondriac", "yeet", "hired" };
            int index = random.Next(wordDictionary.Count);
            String randomWord = wordDictionary[index];

            foreach (char x in randomWord)
            {
                Console.Write("_ ");

            }

            int lenghOfWordToGuess = randomWord.Length;
            int amountOfTimesWrong = 0;
            List<char> currentLettersGuessed = new List<char>();
            int currentLetterRight = 0;

            while (amountOfTimesWrong != 6 && currentLetterRight != lenghOfWordToGuess)
            {
                Console.Write("\nLetters guessed so far: ");
                foreach (char letter in currentLettersGuessed)
                {
                    Console.Write(letter + " ");

                }
                Console.Write("\n Guess a letter: ");
                char letterGuessed = Console.ReadLine()[0];
                if (currentLettersGuessed.Contains(letterGuessed))
                {
                    Console.Write("\r\n You have already guessed that letter");
                    printHangman(amountOfTimesWrong);
                    currentLetterRight = printWord(currentLettersGuessed, randomWord);
                    printLines(randomWord);
                }
                else
                {
                    bool right = false;
                    for (int r = 0; r < randomWord.Length; r++) { if (letterGuessed == randomWord[r]) { right = true; } }
                    if (right)
                    {
                        printHangman(amountOfTimesWrong);
                        currentLettersGuessed.Add(letterGuessed);
                        currentLetterRight = printWord(currentLettersGuessed, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }
                    else
                    {
                        amountOfTimesWrong++;
                        currentLettersGuessed.Add(letterGuessed);
                        printHangman(amountOfTimesWrong);
                        Console.Write("\r\n");
                        currentLetterRight = printWord(currentLettersGuessed, randomWord);
                    }
                    {

                    }
                }
            }

            Console.WriteLine("\r\n Game over! Thanks for playing!");

        }
    }
}