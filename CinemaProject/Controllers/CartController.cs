using CinemaProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace CinemaProject.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext _context;

        public CartController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Cart
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var tickets = _context.Tickets
                .Where(t => t.CustomerUserId.Equals(userId) && !t.Paid)
                .Include(s => s.Screening)
                .Include(m=>m.Screening.Movie)
                .ToList();
            var sum = 0;

            foreach (var ticket in tickets)
            {
                sum = sum + ticket.Screening.Price;
            }

            ViewBag.lastPrice = sum;
            ViewBag.userName = _context.Customers.Single(u => u.CustomerUserId == userId).Name;

            return View(tickets);
        }
    }
}