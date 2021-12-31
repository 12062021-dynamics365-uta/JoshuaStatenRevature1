using System;

namespace _9_ClassesChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Human hume = new Human();
            Human nhume = new Human("Dick", "Butkus");

            hume.AboutMe(hume);
            nhume.AboutMe(nhume);

            Human2 Josh = new Human2("Josh", "Staten", "brown", 25);
            Josh.weight = 150;
            Human2 King = new Human2("King", "Taft", "Amber", 90);
            King.weight = 405;


            Josh.AboutMe2();
            King.AboutMe2();

        }
    }
}
