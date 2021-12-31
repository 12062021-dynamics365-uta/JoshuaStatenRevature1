using System;
using System.Collections.Generic;

namespace _8_LoopsChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            

        }

        /// <summary>
        /// Return the number of elements in the List<int> that are odd.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int UseFor(List<int> x)
        {
            //throw new NotImplementedException("UseFor() is not implemented yet.");
            int odd = 0;
            for (int i=0; i < x.Count; i++)
            {
                if(x[i] % 2 != 0)
                {
                    odd++;
                }
            }
            return odd;
        }

        /// <summary>
        /// This method counts the even entries from the provided List<object> 
        /// and returns the total number found.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int UseForEach(List<object> x)
        {
            // throw new NotImplementedException("UseForEach() is not implemented yet.");
            int evens = 0;
            foreach(object y in x)
            {
                if(Int64.TryParse(y.ToString(), out long i)) //tries to convert string objects to longs
                {
                    if (i % 2 ==0) //if number in list is multiple of two, add to returned total
                    {
                        evens++;
                    }
                }
            }
            return evens;
        }

        /// <summary>
        /// This method counts the multiples of 4 from the provided List<int>. 
        /// Exit the loop when the integer 1234 is found.
        /// Return the total number of multiples of 4.
        /// </summary>
        /// <param name="x"></param>
        public static int UseWhile(List<int> x)
        {
            //throw new NotImplementedException("UseFor() is not implemented yet.");
            int four = 0;
            bool exit = true;
            while (exit)
            {
                foreach (int i in x)
                {
                    if (i == 1234) //when the 1234th int is found, the loop becomes false and the loop is exited(break)
                    {
                        exit = false;
                        break;
                    }
                    else if (i % 4 == 0) //Any number that is a multiple is added to the returned total 
                    {
                        four++;
                    }
                }
            }
            return four;
        }

        /// <summary>
        /// This method will evaluate the Int Array provided and return how many of its 
        /// values are multiples of 3 and 4.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int UseForThreeFour(int[] x)
        {
            //throw new NotImplementedException("UseForThreeFour() is not implemented yet.");
            int threefour = 0;
            foreach (int i in x)
            {
                if ((i % 4 == 0) && (i % 3 == 0)) //use "&&" to denote that ints must pass both conditions to be added to returned total
                {
                    threefour++;
                }
            }
            return threefour;
        }

        /// <summary>
        /// This method takes an array of List<string>'s. 
        /// It concatenates all the strings, with a space between each, in the Lists and returns the resulting string.
        /// </summary>
        /// <param name="stringListArray"></param>
        /// <returns></returns>
        public static string LoopdyLoop(List<string>[] stringListArray)
        {
            //throw new NotImplementedException("LoopdyLoop() is not implemented yet.");
            string neo = "";

            foreach (List<string> s in stringListArray) 
            {
                foreach (string s2 in s) 
                {
                    neo += (s2 + " ");
                }
            }
            return neo;
        }
    }
}