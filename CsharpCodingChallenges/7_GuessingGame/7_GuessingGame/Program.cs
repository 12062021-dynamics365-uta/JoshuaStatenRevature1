using System;
using System.Collections.Generic;

namespace _7_GuessingGameChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool redo = true;
            do
            {
                Console.WriteLine("Let's play a guessing game! You have 10 tries to guess my number!\n");
                List<int> tries = new List<int>();
                int secret = GetRandomNumber();
                int chances = 0;
                bool win = false;
                do
                {
                    int guess = GetUsersGuess();
                    chances++;
                    tries.Add(guess);
                    if (CompareNums(secret, guess) == 0)
                    {
                        win = true;
                    }
                    if (chances >= 10)
                    {
                        break;
                    }
                } while (win == false);
                Console.WriteLine("\nHere are your guesses for each round:\n");
                foreach (int dec in tries)
                {
                    Console.WriteLine($"Round {tries.IndexOf(dec) + 1}: {dec}");
                }
                Console.WriteLine();
                redo = PlayGameAgain();
                Console.Clear();
            } while (redo);
           
        }

        /// <summary>
        /// This method returns a randomly chosen number between 1 and 100, inclusive.
        /// </summary>
        /// <returns></returns>
        public static int GetRandomNumber()
        {
            //throw new NotImplementedException();
            Random rndm = new Random();
            return rndm.Next(0, 101);
        }

        /// <summary>
        /// This method gets input from the user, 
        /// verifies that the input is valid and 
        /// returns an int.
        /// </summary>
        /// <returns></returns>
        public static int GetUsersGuess()
        {
            //throw new NotImplementedException();
            int guess;
            bool again = true;
            do
            {
                Console.WriteLine("Guess the number I am thinking right now...");
                if (Int32.TryParse(Console.ReadLine(), out guess))
                {
                    again = false;
                }
                else
                {
                    again = true;
                }
                Console.Clear();

            } while (again);
            return guess;
            

        }

        /// <summary>
        /// This method will has two int parameters.
        /// It will:
        /// 1) compare the first number to the second number
        /// 2) return -1 if the first number is less than the second number
        /// 3) return 0 if the numbers are equal
        /// 4) return 1 if the first number is greater than the second number
        /// </summary>
        /// <param name="randomNum"></param>
        /// <param name="guess"></param>
        /// <returns></returns>
        public static int CompareNums(int randomNum, int guess)
        {
            //throw new NotImplementedException();
            if (randomNum < guess)
            {
                Console.WriteLine("Oops! Too high!");
                return -1;
            }
            else if (randomNum > guess)
            {
                Console.WriteLine("Sad! Too low!");
                return 1;
            }
            else
            {
                Console.WriteLine("Ding! Ding! You win!");
                return 0;
            }
        }

        /// <summary>
        /// This method offers the user the chance to play again. 
        /// It returns true if they want to play again and false if they do not.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static bool PlayGameAgain()
        {
            //throw new NotImplementedException();
            Console.WriteLine("Wanna go again?      PRESS 1 FOR YES |||| PRESS 2 FOR NO");
            string choice = Console.ReadLine();
            if (choice == "1")
                return false;
            else
                return true;
        }
    }
}
