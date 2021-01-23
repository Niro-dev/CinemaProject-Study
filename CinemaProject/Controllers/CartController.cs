using CinemaProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
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
            var sum = tickets.Aggregate(0, (current, ticket) => current + ticket.Screening.Price);

            Session["lastPrice"] = sum;
            ViewBag.userName = _context.Customers.Single(u => u.CustomerUserId == userId).Name;

            return View(tickets);
        }

        public ActionResult Success()
        {
            var userId = User.Identity.GetUserId();
            var ticket = _context.Tickets
                .Where(t => t.CustomerUserId.Equals(userId) && !t.Paid);

            foreach (var ticket1 in ticket)
            {
                ticket1.Paid = true;
            }

            _context.SaveChanges();

            using (var mail = new MailMessage())
            {
                mail.From = new MailAddress("projectcinema159@gmail.com");
                mail.To.Add(User.Identity.GetUserName());
                mail.Subject = "test";
                mail.Body = "test";
                mail.IsBodyHtml = true;

                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new System.Net.NetworkCredential("projectcinema159", "test1qaz@WSX");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}