using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Storage
{
    public interface IData
    {
        public void getCustomer(string fname, string lname);
        public int addCart(int Cityid, int Customerid, decimal CartTotal);
        public List<Toys> addToCart(int CSpaceid, int Cartid, int toyhID);
        public void getorder(int Cartid, int Cityid, int Customerid, decimal Total);
    }
}
