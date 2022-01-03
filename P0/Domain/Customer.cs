using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Customer
    {
        public List<Customer> customers;
        public int Customerid { get; set; }

        public string fname { get; set; }
        public string lname { get; set; }
        public string uname { get; set; }

        public Customer returner;

        public Customer(string name, string surname)
        {
            name = fname;
            surname = lname;
        }

        bool Login()
        {
            throw new NotImplementedException();
        }

        public void LogIn(string name, string surname)
        {
            Customer c0 = customers.Where(c0 => c0.fname == name && c0.lname == surname).FirstOrDefault();
            if(c0 == null)
            {
                Customer c = new Customer(name, surname);
                this.returner = c;
                customers.Add(c);
            }
            else
            {
                this.returner = c0;
            }
        }
    }
}
