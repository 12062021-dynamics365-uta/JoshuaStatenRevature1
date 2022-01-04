using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Storage;

namespace SantaShop
{
    public class Program
    {


        static void Main(string[] args)
        {

            Random r = new Random();
            Mapper mapper = new Mapper();
            DatabaseAccess db = new DatabaseAccess();
            Data dm = new Data(db);
            Console.WriteLine("Welcome to Santa's Toy Sled!");
            bool currentcustomer = false;
            bool login = false;
            int Customerid = 1;
            do
            {
                do
                {
                    Console.WriteLine("Hit 1 to log-in, or 2 to register.");
                    string log = Console.ReadLine();

                    if (log == "1")
                    {
                        Console.WriteLine("First name?");
                        string fname = Console.ReadLine();
                        Console.WriteLine("Last name?");
                        string lname = Console.ReadLine();
                        Console.WriteLine("Username?");
                        string uname = Console.ReadLine();

                        Customer check = new Customer(fname, lname);
                        DatabaseAccess Custcheck = new DatabaseAccess();
                        Customerid = Custcheck.getCustomerID(fname, lname);
                        Console.WriteLine(Customerid);

                        if (Customerid == 0)
                        {
                            Console.WriteLine("Whoops! Your log-in is not registered with us! Please do so first!");
                            currentcustomer = false;
                        }
                        else
                        {
                            login = true;
                            Console.WriteLine("Time to shop!");
                        }
                    }
                    else if (log == "2")
                    {
                        Console.WriteLine("Enter your first name \n ");
                        string newfirst = Console.ReadLine();
                        Console.WriteLine("Enter your last name \n");
                        string newlast = Console.ReadLine();
                        Console.WriteLine("Enter your username \n");
                        string newusername = Console.ReadLine();
                        DatabaseAccess newCID = new DatabaseAccess();
                        Customerid = newCID.getNextCustomerID();
                        DatabaseAccess newLog = new DatabaseAccess();
                        newLog.addCustomer(Customerid, newfirst, newlast, newusername);

                        login = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid, please try again");
                        login = false;
                    }

                } while (!login);
            } while (currentcustomer);


            bool ifStore = false;
            int isStore = 0;
            do
            {
                Console.WriteLine("Please choose the corresponding number for the city you want to shop for:");
                DatabaseAccess CityName = new DatabaseAccess();
                CityName.findStore();
                string selectCity = Console.ReadLine();
                int convertNum = -1;
                bool convertBool = false;
                convertBool = Int32.TryParse(selectCity, out convertNum);
                isStore = Convert.ToInt32(selectCity);
                if (convertNum > 0)
                {
                    DatabaseAccess displayToys = new DatabaseAccess();
                    dm.currentCity.Cityid = convertNum;
                    Console.WriteLine("Look at what we have: \n");

                    dm.Load();
                    foreach (Toys t in dm.currentCity.toys)
                    {
                        Console.WriteLine($"toyhID: {t.toyhID}\n  tname: {t.tname}\n ${t.Price}\n");
                    }
                }

                else
                {
                    Console.WriteLine("Invalid, please try again");
                }
            } while (ifStore);

            int Cartid = dm.addCart(isStore, Customerid);
            decimal totalPrice = 0;
            int CSpaceid = r.Next(1, 3000);
            bool addCart = false;
            do
            {
                int itemcount = 0;
                Console.Write("Enter the number of the toy you want to buy /n");
                int toyhIDSelect = Convert.ToInt32(Console.ReadLine());
                decimal ToyPrice = db.GetToyPrice(toyhIDSelect);
                string toyName = db.GetToyName(toyhIDSelect);
                totalPrice = totalPrice + ToyPrice;
                foreach (Toys t in dm.currentCity.toys)
                {
                    CSpaceid++;

                    if (toyhIDSelect == t.toyhID)
                    {
                        
                        itemcount++;
                    }
                }

                if (itemcount == 0)
                {
                    Console.WriteLine("Invalid.");
                }

                DatabaseAccess order = new DatabaseAccess();
                order.insertOrderHistory(Customerid, toyhIDSelect, ToyPrice);
                bool menu = true;
                do
                {

                    Console.WriteLine("What else would you like to do? \n" +
                                        "1: View Cart \n" +
                                        "2: Go to Checkout \n" +
                                        "3: Order History \n" +
                                        "4: Delete Item \n" +
                                        "5: Cancel Order \n" +
                                        "6: Add Item to Count \n" +
                                        "7: Exit \n"
                                        );
                    string uInput = (Console.ReadLine().ToString());

                    if (uInput == "1")
                    {
                        Console.WriteLine("\n Order #, \n Item Name:, \n Price:\n");
                        DatabaseAccess viewToys = new DatabaseAccess();
                        viewToys.ViewCart(Cartid);
                    }
                    else if (uInput == "2")
                    {
                        DatabaseAccess checkout = new DatabaseAccess();
                        Console.WriteLine("Total: $" + totalPrice);
                        Console.WriteLine("Thank you for your patronage! Ho Ho Ho!!");
                        checkout.DeleteCartItems(Cartid);
                        totalPrice = 0;
                    }
                    else if (uInput == "3")
                    {
                        Console.WriteLine("\n Order #, \n Item Name:, \n Price:\n");
                        DatabaseAccess orderhistory = new DatabaseAccess();
                        orderhistory.checkOrderHistory(Customerid);
                    }
                    else if (uInput == "4")
                    {
                        Console.WriteLine("Pick the number of the item you want to remove:");
                        int toyhID = Convert.ToInt32(Console.ReadLine());
                        DatabaseAccess delete = new DatabaseAccess();
                        delete.DeleteFromCart(Cartid, toyhID);
                    }
                    else if (uInput == "5")
                    {
                        DatabaseAccess deletecart = new DatabaseAccess();
                        deletecart.DeleteCartItems(Cartid);
                        Console.WriteLine("Your order has benn canceled.");
                    }
                    else if (uInput == "6")
                    {
                        addCart = false;
                        menu = false;
                    }
                    else if (uInput == "7")
                    {
                        Console.WriteLine("Thank you for shopping, see you on the Nice List!");
                        menu = false;
                        addCart = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice, please enter again.");
                    }

                }
                while (menu);

            } while (!addCart);

            
            }
        }


      

    }

