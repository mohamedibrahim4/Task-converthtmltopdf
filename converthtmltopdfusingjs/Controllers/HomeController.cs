using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using converthtmltopdfusingjs.Models;

namespace converthtmltopdfusingjs.Controllers
{
    public class HomeController : Controller
    {
        northwindEntities DB = new northwindEntities();
        public ActionResult Index()
        {

            return View(DB.Customers.Take(10).ToList());
        }

        public ActionResult order(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var order = DB.Orders.Where(a => a.CustomerID == id).ToList();
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }
    }
}