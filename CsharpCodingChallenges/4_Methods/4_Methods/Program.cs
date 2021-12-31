using System;

namespace _4_MethodsChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string name = GetName();
            Console.WriteLine(GreetFriend(name));

            Console.WriteLine(DoAction(GetNumber(), GetNumber(), GetAction()));

            Console.WriteLine(" || Above is the solution.");
           
        }

        public static string GetName()
        {
            //throw new NotImplementedException("GetName() is not implemented yet0");
            Console.WriteLine("PLEASE ENTER THY NAME:");
            string myname = Console.ReadLine();
            return myname;

        }

        public static string GreetFriend(string name)
        {
            //throw new NotImplementedException("GreetFriend() is not implemented yet");
            return $"Hello, {name}. You are my friend."; //use string interpolation to convert string value to denoted variable
        }

        public static double GetNumber()
        {
            //throw new NotImplementedException("GetNumber() is not implemented yet");
            double input;
            bool redo = true;
            do
            {
                Console.WriteLine("enter a Double value");
                string enter = Console.ReadLine();
                if (double.TryParse(enter, out input)) //Tries to convert "enter" string into double. "input" result will determine if conversion worked or not.
                {
                    redo = false;
                }
                else
                {
                    Console.WriteLine("Incorrect value. now redoing...");
                }
            } while (redo);
            return input;

        }

        public static int GetAction()
        {
            //throw new NotImplementedException("GetAction() is not implemented yet");
            int button;
            bool redo = true;
            do
            {
                Console.WriteLine("Choose one: 1.Add   2.Subtract   3.Multiply   4.Divide");
                if(Int32.TryParse(Console.ReadLine(), out button))
                {
                    redo = false;
                }
                else
                {
                    Console.WriteLine("Incorrect value. now redoing...");
                }

            } while (redo);
            return button;

        }

        public static double DoAction(double x, double y, int action)
        {
            //throw new NotImplementedException("DoAction() is not implemented yet");
            try
            {
                switch (action)
                {
                    case 1:
                        double add = x + y;
                        return add;
                    case 2:
                        double sub = x - y;
                        return sub;
                    case 3:
                        double multi = x * y;
                        return multi;
                    case 4:
                        double div = x / y;
                        return div;
                    default:
                        throw new FormatException("System.FormatExceptiion");
                }
            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
    }
}
