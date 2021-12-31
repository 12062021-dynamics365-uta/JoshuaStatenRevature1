using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("9_ClassesChallenge.Tests")]
namespace _9_ClassesChallenge
{
    internal class Human2
    {
        private string firstName = "Pat";
        private string lastname = "Smyth";
        private string eyeColor;
        private int age;
        public int weight { get; set; }

        public Human2() 
        { 
        }
        public Human2(string firstName, string lastname, int age)
        {
            this.firstName = firstName;
            this.lastname = lastname;
            this.age = age;
        }

        public Human2(string firstName, string lastname, string eyeColor)
        {
            this.firstName = firstName;
            this.lastname = lastname;
            this.eyeColor = eyeColor;
        }

        public Human2(string firstName, string lastname, string eyeColor, int age)
        {
            this.firstName = firstName;
            this.lastname = lastname;
            this.eyeColor = eyeColor;
            this.age = age;
        }
        public void AboutMe2()
        {
            string fullname = $"My name is {firstName} {lastname}. ";
            string HAge = $"My age is {age}. ";
            string HEyes = $"My eye color is {eyeColor}. ";

            if (HAge != null && HEyes != null)
            {
                Console.WriteLine(fullname + HAge + HEyes);
            }
            else if (HAge != null && HEyes == null)
            {
                Console.WriteLine(fullname + HEyes);
            }
            else if (HEyes == null && HAge != null)
            {
                Console.WriteLine(fullname + HAge); ;
            }
            else
            {
                Console.WriteLine(fullname);
            }
        }
        public int WeightVar(int weight)
        {
            if (weight < 0 || weight > 400)
                { weight = 0; }
            else 
            { 
                return weight; 
            }
            return weight;
        }
    }
}