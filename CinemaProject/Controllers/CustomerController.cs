using CinemaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using CinemaProject.ViewModel;

namespace CinemaProject.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer()
            };

            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer
                };

                return View("CustomerForm", viewModel);
            }
            if(customer.CustomerUserId == "")
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.CustomerUserId == customer.CustomerUserId);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

        public ViewResult Index()
        {
            var customers = _context.Customers.ToList();

            return View(customers); 
        }

        public ActionResult Details(string id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerUserId == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(string id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerUserId == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer
            };

            return View("CustomerForm", viewModel);
        }
    }
}