using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private List<Customer> customers = new List<Customer>
        {
            new Customer {Id = 1, Name = "Dior"},
            new Customer {Id = 2, Name = "Kaden"},
            new Customer {Id = 3, Name = "Jerry"},
        };

        // GET: Customers
        public ActionResult Index()
        {
            return View(customers);
        }

        public ActionResult Detail(int id)
        {
            var detail = customers.Find(c => c.Id == id);
            return View(detail);
        }
    }
}