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
    [Authorize(Roles = RoleName.Admin)]
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

        public ActionResult Index()
        {

            var viewModel = new CustomerFormViewModel
            {
                Customers = _context.Customers.ToList(),
                Customer = ""
            };

            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        public ActionResult Save(string Customer)
        {
            return RedirectToAction("Details", new { id = Customer });
        }

        //public ViewResult Index()
        //{
        //    var customers = _context.Customers.ToList();

        //    return View(customers); 
        //}

        public ActionResult Details(string id)
        {
            var tickets = _context.Tickets
                .Where(t => t.CustomerUserId.Equals(id))
                .Include(s => s.Screening)
                .Include(m => m.Screening.Movie)
                .ToList();

            return View("Details",tickets);
        }

        //public ActionResult Edit(string id)
        //{
        //    var customer = _context.Customers.SingleOrDefault(c => c.CustomerUserId == id);

        //    if (customer == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    //var viewModel = new CustomerFormViewModel
        //    //{
        //    //    Customer = customer
        //    //};

        //    return View("CustomerForm");
        //}
    }
}