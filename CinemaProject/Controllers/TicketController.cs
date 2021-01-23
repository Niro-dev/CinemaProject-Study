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
using Microsoft.AspNet.Identity;

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

        [AllowAnonymous]
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
            //ticket.Date = DateTime.ParseExact(ticket.Date.ToString(), "MM/dd/yyyy HH:mm:ss", null);
            ticket.CustomerUserId = User.Identity.GetUserId();

            _context.Tickets.Add(ticket);

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


        public ActionResult ChangeSeat(DateTime date, byte hallId, short seat)
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

            ViewBag.seat = seat;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult ChangeSave(Ticket ticket, short seat)
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

            var oldTicketInDb = _context.Tickets.Find(seat, ticket.Date, ticket.HallId);
            _context.Tickets.Remove(oldTicketInDb);

            ticket.CreationTime = DateTime.Now;
            ticket.CustomerUserId = User.Identity.GetUserId();

            _context.Tickets.Add(ticket);

            _context.SaveChanges();

            return RedirectToAction("Index", "Cart");
        }


        public ActionResult RemoveTicketFromCart(short seat, DateTime? date, byte hall)
        {
            var ticketInDb = _context.Tickets
                .Find(seat,date,hall);

            if (ticketInDb == null)
                return HttpNotFound();

            _context.Tickets.Remove(ticketInDb);
            _context.SaveChanges();
            return RedirectToAction("Index", "Cart");
        }

        public ActionResult RemoveAllFromCart(string userId)
        {
            var ticketInDb = _context.Tickets
                .Where(t=> !t.Paid && t.CustomerUserId.Equals(userId));

            foreach (var ticket in ticketInDb)
            {
                _context.Tickets.Remove(ticket);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Cart");
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult DeleteAllUserTickets(string userId)
        {
            var ticketInDb = _context.Tickets
                .Where(t => t.Paid && t.CustomerUserId.Equals(userId));

            foreach (var ticket in ticketInDb)
            {
                _context.Tickets.Remove(ticket);
            }
            _context.SaveChanges();


            return RedirectToAction("Details", "Customer",new { id = userId });
        }

    }
}