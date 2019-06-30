using System;
using System.Linq;
using System.Data.Linq;
using System.Windows;
using System.Data.Common;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using log4net;

using Demo1.BL;
using Demo1.DAL;
using Demo1.Classes;


namespace Demo1
{
    class Program
    {
        static void Main(string[] args)
        {
            Navigation();

            Console.ReadLine();
        }
       

        static void Navigation()
        {
            Controller controllerInstance = new Controller
            {
                order = new Order()
            };

            Console.WriteLine("New Order - 1");
            Console.WriteLine("Explore Orders - 2");
            Console.WriteLine("Delete Order - 3");
            Console.WriteLine("Update Order - 4");

            Console.WriteLine("Back to Menu - 0");

            int nav = Convert.ToInt32(Console.ReadLine());


            switch (nav)
            {
                case 0:
                    Navigation();
                        break;
                case 1:
                    Console.WriteLine("----------------------- PERSONAL INFO -----------------------");
                    Console.Write("First Name:");
                    string temp;
                    temp = Console.ReadLine();
                    controllerInstance.order.ClientData.FirstName = temp;
                    temp = String.Empty;
                    Console.Write("Last Name:");
                    temp = Console.ReadLine();
                    controllerInstance.order.ClientData.LastName = temp;
                    temp = String.Empty;
                    Console.Write("Email:");
                    temp = Console.ReadLine();
                    controllerInstance.order.ClientData.Email = temp;
                    temp = String.Empty;
                    Console.Write("Phone Number:");
                    temp = Console.ReadLine();
                    controllerInstance.order.ClientData.PhoneNumber = temp;
                    temp = String.Empty;
                    Console.WriteLine("************* Address **************");
                    Console.Write("City:");
                    temp = Console.ReadLine();
                    controllerInstance.order.ClientData.Address.City = temp;
                    temp = String.Empty;
                    Console.Write("Street:");
                    temp = Console.ReadLine();
                    controllerInstance.order.ClientData.Address.Street = temp;
                    temp = String.Empty;                     
                    Console.Write("Building Number:");
                    temp = Console.ReadLine();
                    controllerInstance.order.ClientData.Address.BuildingNumber = Convert.ToInt32(temp);
                    temp = String.Empty;

                    Console.WriteLine("---------------------- SHOP INFO -----------------------");
                    Console.Write("Name:");
                    temp = Console.ReadLine();
                    controllerInstance.order.ShopData.Name = temp;
                    temp = String.Empty;
                    Console.WriteLine("************* Address **************");
                    Console.Write("City:");
                    temp = Console.ReadLine();
                    controllerInstance.order.ShopData.Address.City = temp;
                    temp = String.Empty;
                    Console.Write("Street:");
                    temp = Console.ReadLine();
                    controllerInstance.order.ShopData.Address.Street = temp;
                    temp = String.Empty;
                    Console.Write("Building Number:");
                    temp = Console.ReadLine();
                    controllerInstance.order.ShopData.Address.BuildingNumber = Convert.ToInt32(temp);
                    temp = String.Empty;
                    controllerInstance.SaveOrder();
                    Console.WriteLine();

                    Navigation();
                    break;
                case 2:
                    if (controllerInstance.OrdersList.Count > 0)
                    {
                        foreach (KeyValuePair<int, string> item in controllerInstance.OrdersList)
                        {
                            Console.WriteLine("ID: {0}  Name: {1}", item.Key, item.Value);
                        }
                        Console.WriteLine();
                        Navigation();
                    }
                    else {
                        Util.Info("Explore orders", "Orders table is empty!");
                        Console.WriteLine();
                        Navigation();
                    }
                    break;
                case 3:
                    Console.Write("Enter ID of order: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    controllerInstance.DeleteOrder(id);
                    Console.WriteLine();
                   
                    Navigation();
                    break;
                case 4:
                    Console.Write("Enter ID of order: ");
                     id = Convert.ToInt32(Console.ReadLine());
                    controllerInstance.order = controllerInstance.FindByID(id);
                    Console.Write("Enter field that you want to change:");
                    Console.WriteLine("----------------------- PERSONAL INFO -----------------------");
                    Console.WriteLine("FirstName - 1");
                    Console.WriteLine("LastName - 2");
                    Console.WriteLine("Email - 3");
                    Console.WriteLine("Phone Number - 4");
                    Console.WriteLine("************* Address **************");
                    Console.WriteLine("City - 5");
                    Console.WriteLine("Street - 6");
                    Console.WriteLine("Building Number - 7");
                    Console.WriteLine("---------------------- SHOP INFO -----------------------");
                    Console.WriteLine("Name - 8");
                    Console.WriteLine("************* Address **************");
                    Console.WriteLine("City - 9");
                    Console.WriteLine("Street - 10");
                    Console.WriteLine("Building Number - 11");
                    int field = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    switch (field)
                    {
                        case 1:
                            Console.Write("First Name:");                            
                            temp = Console.ReadLine();
                            controllerInstance.order.ClientData.FirstName = temp;
                            temp = String.Empty;
                            break;
                        case 2:
                            Console.Write("Last Name:");
                            temp = Console.ReadLine();
                            controllerInstance.order.ClientData.LastName = temp;
                            temp = String.Empty;
                            break;
                        case 3:
                            Console.Write("Email:");
                            temp = Console.ReadLine();
                            controllerInstance.order.ClientData.Email = temp;
                            temp = String.Empty;
                            break;
                        case 4:
                            Console.Write("Phone Number:");
                            temp = Console.ReadLine();
                            controllerInstance.order.ClientData.PhoneNumber = temp;
                            temp = String.Empty;
                            break;
                        case 5:
                            Console.Write("City:");
                            temp = Console.ReadLine();
                            controllerInstance.order.ClientData.Address.City = temp;
                            temp = String.Empty;
                            break;
                        case 6:
                            Console.Write("Street:");
                            temp = Console.ReadLine();
                            controllerInstance.order.ClientData.Address.Street = temp;
                            temp = String.Empty;
                            break;
                        case 7:
                            Console.Write("Building Number:");
                            temp = Console.ReadLine();
                            controllerInstance.order.ClientData.Address.BuildingNumber = Convert.ToInt32(temp);
                            temp = String.Empty;
                            break;
                        case 8:
                            Console.Write("Name:");
                            temp = Console.ReadLine();
                            controllerInstance.order.ShopData.Name = temp;
                            temp = String.Empty;
                            break;
                        case 9:
                            Console.Write("City:");
                            temp = Console.ReadLine();
                            controllerInstance.order.ShopData.Address.City = temp;
                            temp = String.Empty;
                            break;
                        case 10:
                            Console.Write("Street:");
                            temp = Console.ReadLine();
                            controllerInstance.order.ShopData.Address.Street = temp;
                            temp = String.Empty;
                            break;
                        case 11:
                            Console.Write("Building Number:");
                            temp = Console.ReadLine();
                            controllerInstance.order.ShopData.Address.BuildingNumber = Convert.ToInt32(temp);
                            temp = String.Empty;
                            break;
                    }

                    controllerInstance.Update();

                    Console.WriteLine();
                    Console.WriteLine();
                    Navigation();
                    break;
            }

        }

      


        

     

   
    }
}
