using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("9_ClassesChallenge.Tests")]
namespace _9_ClassesChallenge
{
    internal class Human
    {
        private string firstName = "Pat";
        private string lastname = "Smyth";


        public Human()
        {

        }
        public Human(string fname, string lname)
        {
            this.firstName = fname;
            this.lastname = lname;
        }
        public void AboutMe(Human nhume)
        {
            Console.WriteLine($"My name is {firstName} {lastname}"); //Use string interpolation to add variables into string
        }
    }//end of class
}//end of namespace