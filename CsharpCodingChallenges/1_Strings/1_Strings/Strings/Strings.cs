using System;

namespace StringManipulationChallenge
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
            *
            * implement the required code here and within the methods below.
            *
            */
            Console.WriteLine("Enter a string.");
            string s1 = Console.ReadLine();
            string s2 = Program.StringToUpper(s1); //Convert string to Uppercase
            Console.WriteLine(s2);

            //call StringtoLower method
            Console.WriteLine("Enter a string.");
            string s3 = Console.ReadLine();
            string s4 = Program.StringToLower(s3); //Convert string to Lowercase
            Console.WriteLine(s4);

            //call the StringTrim method
            string s5 = "  Milk ";
            string s6 = "Yogurt  ";

            Console.WriteLine(s5.Trim()); //Should return strings without the spaces
            Console.WriteLine(s6.Trim());

            //call the substring method
            string subStr = Program.StringSubstring("This is a very long string!!!", 1, 8); //Indexed return of this string's second postion and ends at the ninth position
            Console.WriteLine(subStr);

            //call the SearchChar method
            string s7 = "Ringer";
            int i1 = s7.IndexOf("g");
            Console.WriteLine(i1); //search string for selected char and then return indexed position

            //call the Concat method
            string s8 = "Josh";
            string s9 = "Staten";
            string sc = string.Concat(s8 + " " + s9);
            Console.WriteLine(sc); //Combine strings s8 and s9 and place a space between them

        }

        /// <summary>
        /// This method has one string parameter and will: 
        /// 1) change the string to all upper case and 
        /// 2) return the new string.
        /// </summary>
        /// <param name="usersString"></param>
        /// <returns></returns>
        public static string StringToUpper(string usersString)
        {
            //throw new NotImplementedException("StringToUpper method not implemented.");
            usersString = usersString.ToUpper();
            return usersString;
        }

        /// <summary>
        /// This method has one string parameter and will:
        /// 1) change the string to all lower case,
        /// 2) return the new string into the 'lowerCaseString' variable
        /// </summary>
        /// <param name="usersString"></param>
        /// <returns></returns>       
        public static string StringToLower(string usersString)
        {
            //throw new NotImplementedException("StringToUpper method not implemented.");
            usersString = usersString.ToLower();
            return usersString;

        }

        /// <summary>
        /// This method has one string parameter and will:
        /// 1) trim the whitespace from before and after the string, and
        /// 2) return the new string.
        /// HINT: When getting input from the user (you are the user), try inputting "   a string with whitespace   " to see how the whitespace is trimmed.
        /// </summary>
        /// <param name="usersStringWithWhiteSpace"></param>
        /// <returns></returns>
        public static string StringTrim(string usersStringWithWhiteSpace)
        {
            //throw new NotImplementedException("StringTrim method not implemented.");
            return usersStringWithWhiteSpace.Trim();
        }

        /// <summary>
        /// This method has three parameters, one string and two integers. It will:
        /// 1) get the substring based on the first integer element and the length 
        /// of the substring desired.
        /// 2) return the substring.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="firstElement"></param>
        /// <param name="lastElement"></param>
        /// <returns></returns>
        public static string StringSubstring(string x, int firstElement, int lengthOfSubstring)
        {
            //throw new NotImplementedException("StringSubstring method not implemented.");
            return x.Substring(firstElement, lengthOfSubstring);

        }

        /// <summary>
        /// This method has two parameters, one string and one char. It will:
        /// 1) search the string parameter for first occurrance of the char parameter and
        /// 2) return the index of the char.
        /// HINT: Think about how StringTrim() (above) would be useful in this situation
        /// when getting the char from the user. 
        /// </summary>
        /// <param name="userInputString"></param>
        /// <param name="charUserWants"></param>
        /// <returns></returns>
        public static int SearchChar(string userInputString, char charUserWants)
        {
            //throw new NotImplementedException("SearchChar method not implemented.");
            int result = userInputString.IndexOf(charUserWants);
            return result;
        }

        /// <summary>
        /// This method has two string parameters. It will:
        /// 1) concatenate the two strings with a space between them.
        /// 2) return the new string.
        /// HINT: You will need to get the users first and last name in the 
        /// main method and send them as arguments.
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <returns></returns>
        public static string ConcatNames(string fName, string lName)
        {
            //throw new NotImplementedException("ConcatNames method not implemented.");
            return string.Concat(fName, " ", lName);
            //return fName + " " + lName;
        }
    }//end of program
}
