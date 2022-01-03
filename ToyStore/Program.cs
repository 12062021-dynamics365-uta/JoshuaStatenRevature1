
﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyStore
{
    class Program
    {
      

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Santa's Toy Sled!");
            int action = ChooseAction();

            while (action != 0)
            {
                switch (action)
                {
                    case 1:
                        Console.WriteLine("Welcome to the Atlanta location. Please select from our collection");
                        {
                            string query = $"SELECT * FROM ToyStock";
                            SqlCommand command = new SqlCommand(query);
                            using (SqlDataReader dr = command.ExecuteReader())
                                while (dr.Read())
                                {
                                    Console.WriteLine(dr[0].ToString() + " " + Convert.ToDouble(dr[1].ToString()) + " " + dr[2].ToString() + " ");


                                }
                        }


                        break;



                    case 2:
                        Console.WriteLine("Welcome to the Hoschton location. Please select from our collection");
                        {
                            string query = $"SELECT * FROM ToyStock";
                            SqlCommand command = new SqlCommand(query);
                            using (SqlDataReader dr = command.ExecuteReader())
                                while (dr.Read())
                                {
                                    Console.WriteLine(dr[3].ToString() + " " + Convert.ToDouble(dr[4].ToString()) + " " + dr[5].ToString() + " ");


                                }
                        }


                        break;


                    case 3:
                        Console.WriteLine("Welcome to the Norcross location. Please select from our collection");
                        {
                            string query = $"SELECT * FROM ToyStock";
                            SqlCommand command = new SqlCommand(query);
                            using (SqlDataReader dr = command.ExecuteReader())
                                while (dr.Read())
                                {
                                    Console.WriteLine(dr[6].ToString() + " " + Convert.ToDouble(dr[7].ToString()) + " " + dr[8].ToString() + " ");


                                }
                        }


                        break;
                }
            }
        }
        

        static public int ChooseAction()
        {
            int  choice = 0;
            Console.WriteLine("Please choose which store you wish to shop at: 1 for Atlanta, 2 for Hoschton, and 3 for Norcross");
            choice = int.Parse(Console.ReadLine());
            return choice;

        }
    }﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyStore
{
    class Program
    {
      

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Santa's Toy Sled!");
            int action = ChooseAction();

            while (action != 0)
            {
                switch (action)
                {
                    case 1:
                        Console.WriteLine("Welcome to the Atlanta location. Please select from our collection");
                        {
                            string query = $"SELECT * FROM ToyStock";
                            SqlCommand command = new SqlCommand(query);
                            using (SqlDataReader dr = command.ExecuteReader())
                                while (dr.Read())
                                {
                                    Console.WriteLine(dr[0].ToString() + " " + Convert.ToDouble(dr[1].ToString()) + " " + dr[2].ToString() + " ");


                                }
                        }


                        break;



                    case 2:
                        Console.WriteLine("Welcome to the Hoschton location. Please select from our collection");
                        {
                            string query = $"SELECT * FROM ToyStock";
                            SqlCommand command = new SqlCommand(query);
                            using (SqlDataReader dr = command.ExecuteReader())
                                while (dr.Read())
                                {
                                    Console.WriteLine(dr[3].ToString() + " " + Convert.ToDouble(dr[4].ToString()) + " " + dr[5].ToString() + " ");


                                }
                        }


                        break;


                    case 3:
                        Console.WriteLine("Welcome to the Norcross location. Please select from our collection");
                        {
                            string query = $"SELECT * FROM ToyStock";
                            SqlCommand command = new SqlCommand(query);
                            using (SqlDataReader dr = command.ExecuteReader())
                                while (dr.Read())
                                {
                                    Console.WriteLine(dr[6].ToString() + " " + Convert.ToDouble(dr[7].ToString()) + " " + dr[8].ToString() + " ");


                                }
                        }


                        break;
                }
            }
        }
        

        static public int ChooseAction()
        {
            int  choice = 0;
            Console.WriteLine("Please choose which store you wish to shop at: 1 for Atlanta, 2 for Hoschton, and 3 for Norcross");
            choice = int.Parse(Console.ReadLine());
            return choice;

        }
    }

}