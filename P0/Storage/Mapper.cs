using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Domain;

namespace Storage
{
    public class Mapper
    {
        public int CustomerMap (SqlDataReader dr)
        {
            string name = " ";
            string surname = " ";
            int Customerid = 0;

            while (dr.Read())
            {
                Customer tocust = new Customer(name, surname)
                {
                    Customerid = Convert.ToInt32(dr[0].ToString()),
                };
            }
            return Customerid;

        }

        public List<Toys> ToyMap (SqlDataReader dr)
        {
            List<Toys> toys = new List<Toys>();
            while(dr.Read())
            {

                Toys toy = new Toys()
                {
                    toyhID = Convert.ToInt32(dr[0].ToString()),
                    tname = dr[1].ToString(),
                    Price = Convert.ToDecimal(dr[2].ToString()),
                    Script = dr[3].ToString()

                };
                toys.Add(toy);
            }
            return toys;

        }

        public List<Cart> CartMap(SqlDataReader dr)
        {

            List<Cart> newcart = new List<Cart>();
            while (dr.Read())
            {

                Cart cart = new Cart()
                {
                    Cartid = Convert.ToInt32(dr[0].ToString()),
                    Cityid = Convert.ToInt32(dr[0].ToString()),
                    Customerid = Convert.ToInt32(dr[1].ToString()),
                    CartTotal = Convert.ToDecimal(dr[2].ToString()),
                };
                newcart.Add(cart);
            }
            return newcart;
        }

        public List<Space> CartSpaceMap (SqlDataReader dr)
        {

            List<Space> spaces = new List<Space>();
            while (dr.Read())
            {

                Space space = new Space()
                {
                    CSpaceid = Convert.ToInt32(dr[0].ToString()),
                    Lineid = Convert.ToInt32(dr[1].ToString()),
                    Cartid = Convert.ToInt32(dr[2].ToString()),
                    toyhID = Convert.ToInt32(dr[3].ToString()),
                };
                spaces.Add(space);
                    

                
            }
            return spaces;
        }
    }
}
