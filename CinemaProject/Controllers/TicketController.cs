using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.IO;
using System.Web.Mvc;
using CinemaProject.Models;
using CinemaProject.ViewModel;
using System.Globalization;

namespace CinemaProject.Controllers
{
    public class TicketController : Controller
    {
        private ApplicationDbContext _context;

        public TicketController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult ChooseSeat(DateTime date, byte hallId)
        {
            var movieScreen = _context.Screenings
                .Include(s => s.Movie)
                .SingleOrDefault(s => s.Date == date && s.HallId == hallId);

            var TicketsInDb = _context.Tickets
                .Where(t => t.HallId == hallId && t.Date == date)
                .ToList();

            if (movieScreen == null)
            {
                return HttpNotFound();
            }

            var viewModel = new TicketFormViewModel
            {
                TicketsList = TicketsInDb,
                Ticket = new Ticket(),
                Screening = movieScreen
            };


            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new TicketFormViewModel
                {
                    Screening = ticket.Screening,
                    Ticket = new Ticket()
                };

                return View("ChooseSeat", viewModel);
            }

            ticket.CreationTime = DateTime.Now;
            ticket.Date = DateTime.ParseExact(ticket.Date.ToString(), "MM/dd/yyyy HH:mm:ss", null);

            _context.Tickets.Add(ticket);

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        // GET: Seat
        public ActionResult Index()
        {
            return View();
        }
    }
}