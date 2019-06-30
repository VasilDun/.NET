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

namespace Demo1.Classes
{
    public class Controller
    {
        public Order order;
   
        public Dictionary<int, string> OrdersList = new Dictionary<int, string>();

        private static readonly UnitOfWork UnitOfWorkInstance = new UnitOfWork();

        public Controller()
        {
            OrdersList = UnitOfWorkInstance.GetOrders().ToDictionary(order => order.Id,
                    order => $"{order.ClientData.FirstName} {order.ClientData.LastName}");
        }


        public void SaveOrder()
        {
            try
            {
                UnitOfWorkInstance.Orders.Insert(order);

                UnitOfWorkInstance.Save();
                Util.Info("Cargo Delivery", "An order was saved successfully!");
                OrdersList = UnitOfWorkInstance.GetOrders().ToDictionary(order => order.Id,
                   order => $"{order.ClientData.FirstName} {order.ClientData.LastName}");
            }
            catch(Exception exc)
            {

                Util.Error("Order saving error", exc.Message);
            }
        }

        public void DeleteOrder(int id)
        {
            try
            {        
                UnitOfWorkInstance.DeleteOrder(id);
                UnitOfWorkInstance.Save();            
                var orders = UnitOfWorkInstance.GetOrders().ToDictionary(order => order.Id,
                    order => $"{order.ClientData.FirstName} {order.ClientData.LastName}");
                if (orders.Count > 1)
                {
                    OrdersList = orders;
                }            
            }
            catch(Exception exc)
            {             
                Util.Error("Order deleting error", exc.ToString());
            }
        }
        public Order  FindByID(int id)
        {
            return UnitOfWorkInstance.Orders.GetById(id);

        }
        public void Update()
        {
            UnitOfWorkInstance.Orders.Update(order);
            UnitOfWorkInstance.Save();

                    OrdersList = UnitOfWorkInstance.GetOrders().ToDictionary(order => order.Id,
                 order => $"{order.ClientData.FirstName} {order.ClientData.LastName}");
        }
    }
}
