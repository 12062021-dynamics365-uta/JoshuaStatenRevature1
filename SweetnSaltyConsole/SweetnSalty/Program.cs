using System;

namespace SweetnSalty
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int sweet = 0;
            int salt = 0;    //setting values to ints so that they can be incremented to reflect the sweet, salt, and both counters respectively
            int ss = 0;
            
            for(int n = 1; n <= 1000; n++) //using a for loop to generate the numbers 1-1000
            {
                
                
                    if (n % 3 == 0 && n % 5 == 0) //Obtains remainder of n/3 or n/5; if 0, then that number is a multiple of both 3 and 5
                    {
                        Console.Write("sweet'nSalty" + " "); // Replace numbers that are multiples of 3 and 5 with this string value
                        ss++; //increment int for final flavor counter
                        if (n % 20 == 0)
                        {
                            Console.Write("\n"); //if the the number is also a multiple of 20, then the line will break into a new line; should break after every 20 numbers

                        }
                    }
                    else if (n % 5 == 0)
                    {
                        Console.Write("salty" + " "); // Replace numbers that are multiples of 5 with this string value
                    salt++;
                        if (n % 20 == 0)
                        {
                            Console.Write("\n");
                        }
                    }
                    else if (n % 3 == 0)
                    {
                        Console.Write("sweet" + " "); // Replace numbers that are multiples of 3 with this string value
                    sweet++;
                        if (n % 20 == 0)
                        {
                            Console.Write("\n");
                        }
                    }
                    else
                    {
                        Console.Write(n + " "); // Numbers that do not pass any of the above conditions will be printed normally with no string replacement
                        if (n % 20 == 0)
                        {
                            Console.Write("\n");
                        }
                    }
                    
                
                
                

                    
            }
            Console.WriteLine($"sweet : {sweet} \nsalty: {salt}  \nsweet'nSalty : {ss}");
            //With string interpolation , the final count of sweet, salty, and sweet'nSalty are printed on different lines with the incremented ints inserted into the string

        }
    }
}
