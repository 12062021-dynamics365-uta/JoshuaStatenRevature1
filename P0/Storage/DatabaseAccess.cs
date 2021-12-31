using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Storage
{
    class DatabaseAccess
    {
        string db = "Data source =LAPTOP-NI3BRHG2\\SQLEXPRESS; initial Catalog = ToySanta; integrated security = true";
        public SqlConnection connection;
        public Mapper mapper;
        Random r = new Random();

        public void DBAccess()
        {
            this.connection = new SqlConnection(this.db);
            connection.Open();
            this.mapper = new Mapper();
        }

        public void addLocation(int Cityid, string CityName)
        {
            string query = $"INSERT INTO City (StoreNum, StoreLocation) VALUES ('{Cityid}' , '{CityName}');";
            DBAccess();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader dr = cmd.ExecuteReader();


            dr.Close();
        }

        public void insertOrderHistory(int Customerid, int toyhID, decimal Price)
        {
            string query = $"INSERT INTO OldOrder(Customerid, toyhID, Price) VALUES ('{Customerid}' , '{toyHID}' , '{Price}');";
            DBAccess();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader dr = cmd.ExecuteReader();


            dr.Close();
        }

        public void checkOrderHistory(int Customerid)
        {
            string query = $"SELECT DISTINCT Customerid, toyhID, Price FROM PastOrders3 WHERE CustomerID = {Customerid};";
            List<CartItems> itemsInCart = new List<CartItems>();

            DBAccess();
            SqlCommand command = new SqlCommand(query, this.connection);

            SqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    Console.WriteLine(dr.GetValue(i));
                };

            }
        }
        public string GetToyName(int toyhID)
        {
            string toyName = "";
            string query = $"SELECT Tname FROM Toyinvo WHERE toyhID = {toyhID};";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                toyName = dr[0].ToString();
            }
            dr.Close();
            return toyName;
        }
        public int GetToyPrice(int toyhID)
        {
            int cost = 0;
            string query = $"SELECT Price FROM Toyinvo WHERE toyhID = '{toyhID}';";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cost += Convert.ToInt32(dr[0].ToString());
            }
            dr.Close();
            int cartCost = cost;
            return cartCost;
        }
        public void getCustomers()
        {
            string query = "SELECT uname FROM Customer;";

            using (connection)
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader dataRead = command.ExecuteReader())
                    {
                        while (dataRead.Read())
                        {
                            for (int i = 0; i < dataRead.FieldCount; i++)
                            {
                                Console.WriteLine(dataRead.GetValue(i));
                            }
                            Console.WriteLine();
                        }
                    }

                }

            }
        }
        public int getCustomerID(string fname, string lname)
        {
            int Customerid = 0;
            string query = $"SELECT Customerid FROM Customer WHERE fname = '{fname}' AND lname = '{lname}';";
            DBAccess();
            using (SqlCommand command = new SqlCommand(query, this.connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        Customerid = Convert.ToInt32(dr[0].ToString());

                    };
                }

                dr.Close();
            }
            return Customerid;


        }
        public void addCustomer(int Customerid, string fname, string lname, string uname)
        {
            SqlCommand command;
            DBAccess();
            command = connection.CreateCommand();

            if (Customerid > 0)
            {

                string query = "INSERT INTO Customers(Customerid, fname, lname, uname) values('" + Customerid + "', '" + fname + "', '" + lname + "', '" + uname + "');";

                using (connection)
                {
                    using (command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader dataRead = command.ExecuteReader())
                        {
                            while (dataRead.Read())
                            {
                                for (int i = 0; i < dataRead.FieldCount; i++)
                                {
                                    Console.WriteLine(dataRead.GetValue(i));

                                }
                                Console.WriteLine();
                            }
                        }

                    }

                }
            }
            else
            {
                Console.WriteLine("Error creating new customer.");
            }



        }
        public void findStore()
        {
            string query = "SELECT Cityid, cityName FROM City;";
            DBAccess();
            using (connection)
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader dataRead = command.ExecuteReader())
                    {
                        while (dataRead.Read())
                        {
                            for (int i = 0; i < dataRead.FieldCount; i++)
                            {
                                Console.WriteLine(dataRead.GetValue(i));
                            }
                            Console.WriteLine();
                        }
                    }

                }

            }

        }
        public List<Toys> displayToys(int Cityid)
        {

            string query = "SELECT toyhID, Tname, Price, Script" +
                           "FROM Toyinvo " +
                           "LEFT OUTER JOIN City " +
                           "ON City.Cityid = Toyinvo.Cityid " +
                           "LEFT OUTER JOIN Products p " +
                           "ON p.toyhID = Inventory.ProductID " +
                           "WHERE Inventory.Cityid = " + Cityid + " ;";

            List<Toys> toys = new List<Toys>();
            DBAccess();
            using (SqlCommand command = new SqlCommand(query, this.connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                toys = this.mapper.EntityToProducts(dr);
                dr.Close();
            }
            return toys;

        }
        public int newCart(int Cityid, int Customerid, decimal CartTotal)
        {
            int Cartid = r.Next(1, 3000);
            string query = "INSERT INTO Cart(Cartid, Cityid, Customerid, CartTotal) values('" + Cartid + "', '" + Cityid + "', '" + Customerid + "', '" + CartTotal + "')";
            List<Carts> cart = new List<Carts>();
            DBAccess();
            using (SqlCommand command = new SqlCommand(query, this.connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {

                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        Console.WriteLine(dr.GetValue(i));

                    };
                }
                dr.Close();
            }

        }
        public decimal getorder(int Orderid, int Cityid, int Customerid, decimal Total)
        {
            string query = $"INSERT INTO CustOrder (Orderid, Cityid, Customerid, Total) values('{Orderid}','{Cityid}', '{Customerid}', '{Total}');";
            List<Orders> order = new List<Orders>();
            DBAccess();
            SqlCommand command = new SqlCommand(query, this.connection);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    Console.WriteLine(dr.GetValue(i));
                };

            }

            return Total;
        }
        public decimal getorderitem(int Cartid, int Cityid, int Customerid, decimal CartTotal)
        {
            string query1 = "SELECT CartTotal FROM Cart WHERE CartID = " + Cartid + ";";
            List<Orders> order = new List<Orders>();
            DBAccess();
            SqlCommand command = new SqlCommand(query1, this.connection);
            SqlDataReader dr = command.ExecuteReader();
            using (command = new SqlCommand(query1, this.connection))
            {
                dr.Close();
                dr = command.ExecuteReader();

                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        Console.WriteLine(dr.GetValue(i));
                    };

                }


            }
            return CartTotal;
        }

    }
}
