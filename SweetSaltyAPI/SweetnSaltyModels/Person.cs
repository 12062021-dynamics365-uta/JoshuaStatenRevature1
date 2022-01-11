using System;
using System.Collections.Generic;

namespace SweetnSaltyModels
{
    public class Person
    {
        public int userId { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public List<Flavor> personFlavors { get; set; }
    }
}