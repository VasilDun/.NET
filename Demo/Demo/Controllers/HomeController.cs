using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Serialization.Formatters.Binary;
using Repository;
using Entity.Models;
using PagedList;
using System.IO;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
    
        private UnitOfWork unitOfWorkInstance = new UnitOfWork();

        private IEnumerable<Order> OrdersList = new List<Order>();

        public ActionResult Index()
        {
            OrdersList = unitOfWorkInstance.GetOrders();
            return View(OrdersList);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {           
            return View();
        }

     

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post(Order order)
        {          
            if (ModelState.IsValid)
            {
                unitOfWorkInstance.Orders.Insert(order);
                unitOfWorkInstance.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit_Get(int id)
        {
            OrdersList = unitOfWorkInstance.GetOrders();
            Order order = OrdersList.Single(ord=>ord.Id == id);
            return View(order);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(Order order)
        {


            //Order order;

           // order = unitOfWorkInstance.Orders.GetById(id);

            if (ModelState.IsValid)
            {
                unitOfWorkInstance.Orders.Update(order);
                unitOfWorkInstance.Save();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        
        public ActionResult Delete(int id)
        {
            unitOfWorkInstance.DeleteOrder(id);
            unitOfWorkInstance.Save();

            return RedirectToAction("Index");
        }
    }
}