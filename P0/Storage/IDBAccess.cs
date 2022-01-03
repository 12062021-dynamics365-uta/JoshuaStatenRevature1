using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Storage
{
    public interface IDBAccess
    {
        public void getCustomers();
        public int getCustomerID(string fname, string lname);
        public void addCustomer(int Customerid, string fname, string lname, string uname);
        public void findStore();
        public List<Toys> displayToys(int Cityid);
        public int newCart(int Cityid, int Customerid, decimal CartTotal);
        public void addToCart(int CSpaceid, int Lineid, int Cartid, int toyhID);
        public void DeleteFromCart(int Cartid, int toyhID);
        public decimal getorder(int Orderid, int Cityid, int Customerid, decimal Total);
        public decimal getorderitem(int Cartid, int Cityid, int Customerid, decimal CartTotal);
        public int GetToyPrice(int toyhID);
    }
}
