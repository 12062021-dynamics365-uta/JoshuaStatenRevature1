using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Data.SqlClient;

namespace Storage
{
    public class Data : IData
    {
        public Store currentCity { get; set; }
        public Order currentOrder { get; set; }

        public List<Cart> cart;
        public List<Space> spaces;

        public Space toyhID { get; set; }

        private IDBAccess _DataBaseAccess;

        public Data(IDBAccess dba)
        {
            toyhID = new Space();
            currentCity = new Store();
            cart = new List<Cart>();
            spaces = new List<Space>();
            currentOrder = new Order();
            this._DataBaseAccess = dba;

        }
        public void getCustomer(string fname, string lname)
        {
            int Customerid = 0;
            Customerid = this._DataBaseAccess.getCustomerID(fname, lname);

        }

        public void Load()
        {
            currentCity.toys = this._DataBaseAccess.displayToys(currentCity.Cityid);
        }

        public int addCart (int Cityid, int Customerid, decimal CartTotal)
        {
            decimal Total = 0;
            int Cartid = this._DataBaseAccess.newCart(Cityid, Customerid, CartTotal);
            return Cartid;
        }
        public List<Toys> addToCart(int CSpaceid, int Cartid, int toyhID)
        {
            decimal itotal = 0;
            int Lineid = Cartid;
            List<Toys> toys = new List<Toys>();
            Toys t;
            foreach (Toys prod in currentCity.toys)
            {
                if (prod.toyhID == toyhID)
                {

                    t = prod;
                    itotal = t.Price;
                }
            }
            this._DataBaseAccess.addToCart(Cartid, Lineid, Cartid, toyhID);
            return toys;
        }

        public void viewCart()
        {

        }

        public void getorder(int Cartid, int Cityid, int Customerid, decimal Total)
        {
            List<Order> order = new List<Order>();
            Order o;
            
            foreach(Order orders in order)
            {
                o = orders;
            }

            this._DataBaseAccess.getorder(Cartid, Cityid, Customerid, Total);
        }

        public int addCart(int isStore, int customerid)
        {
            throw new NotImplementedException();
        }
    }
}
