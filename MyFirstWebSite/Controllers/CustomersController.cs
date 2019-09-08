using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using MyFirstWebSite.Models;

namespace MyFirstWebSite.Controllers
{
    public class CustomersController : Controller
    {
        private static List<Customers> customersList = null;

        // GET: Customers
        [HttpGet]
        public ActionResult Index()
        {
            if (HttpContext.Cache["CustomerDatas"] == null)
            {
                customersList = new Customers().GenerateCustomers();
                HttpContext.Cache.Insert("CustomerDatas", customersList, null, Cache.NoAbsoluteExpiration, TimeSpan.FromHours(1));
            }
            else
            {
                customersList = HttpContext.Cache["CustomerDatas"] as List<Customers>;
            }

            return View(customersList);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Customers _customers)
        {
            if (HttpContext.Cache["CustomerDatas"] != null)
            {
                customersList = HttpContext.Cache["CustomerDatas"] as List<Customers>;
                _customers.Id = Guid.NewGuid().ToString();
                customersList.Add(_customers);

                HttpContext.Cache.Insert("CustomerDatas", customersList, null, Cache.NoAbsoluteExpiration, TimeSpan.FromHours(1));
            }

            return RedirectToAction("Index", "Customers");
        }

        [HttpGet]
        public ActionResult Update(string id)
        {
            Customers customer = null;

            if (HttpContext.Cache["CustomerDatas"] != null)
            {
                customersList = HttpContext.Cache["CustomerDatas"] as List<Customers>;

                customer = customersList.First(i => i.Id == id);
            }

            return View(customer);
        }

        [HttpPost]
        public ActionResult Update(Customers _customers)
        {
            Customers customer = null;

            if (HttpContext.Cache["CustomerDatas"] != null)
            {
                customersList = HttpContext.Cache["CustomerDatas"] as List<Customers>;

                customer = customersList.First(i => i.Id == _customers.Id);
                customer.Name = _customers.Name;
                customer.Surname = _customers.Surname;
                customer.Phone = _customers.Phone;

                HttpContext.Cache.Insert("CustomerDatas", customersList, null, Cache.NoAbsoluteExpiration, TimeSpan.FromHours(1));
            }

            return RedirectToAction("Index", "Customers");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            Customers customer = null;

            if (HttpContext.Cache["CustomerDatas"] != null)
            {
                customersList = HttpContext.Cache["CustomerDatas"] as List<Customers>;

                customer = customersList.First(i => i.Id == id);

                customersList.Remove(customer);

                HttpContext.Cache.Insert("CustomerDatas", customersList, null, Cache.NoAbsoluteExpiration, TimeSpan.FromHours(1));
            }

            return RedirectToAction("Index", "Customers");
        }
    }
}