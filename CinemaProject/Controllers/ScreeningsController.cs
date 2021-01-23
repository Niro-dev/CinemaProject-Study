using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinemaProject.Models;
using CinemaProject.ViewModel;
using System.Data.Entity;

namespace CinemaProject.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class ScreeningsController : Controller
    {
        private ApplicationDbContext _context;

        public ScreeningsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ViewResult New()
        {
            var halls = _context.Halls.ToList();
            var movies = _context.Movies.ToList();

            var viewModel = new ScreeningFormViewModel
            {
                Movie = movies,
                Halls = halls,
                Screening = new Screening()
            };

            return View("ScreeningForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Screening screening)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ScreeningFormViewModel
                {
                    Screening = screening,
                    Halls = _context.Halls.ToList(),
                    Movie = _context.Movies.ToList()
                };

                return View("ScreeningForm", viewModel);
            }

            if (_context.Screenings.Find(screening.Date, screening.HallId) != null)
            {
                return View("Error");
            }

            _context.Screenings.Add(screening);

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


        public ActionResult Edit(DateTime? date, byte hallId)
        {
            var screen = _context.Screenings.Find(date,hallId);

            if (screen == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ScreeningFormViewModel
            {
                Movie = _context.Movies.ToList(),
                Halls = _context.Halls.ToList(),
                Screening = screen
            };

            Session["date"] = date;
            Session["hallId"] = hallId;
            return View("ScreeningFormEdit", viewModel);
        }

        [HttpPost]
        public ActionResult SaveEdit(Screening screening)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ScreeningFormViewModel
                {
                    Screening = screening,
                    Halls = _context.Halls.ToList(),
                    Movie = _context.Movies.ToList()
                };

                return View("ScreeningForm", viewModel);
            }


            if (_context.Screenings.Find(screening.Date,screening.HallId) != null)
            {
                return View("Error");
            }

            var oldScreenInDb = _context.Screenings.Find(Session["date"], Session["hallId"]);
            _context.Screenings.Remove(oldScreenInDb);
            _context.Screenings.Add(screening);

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


        public ActionResult RemoveScreen(DateTime? date, byte hallId)
        {
            var screen = _context.Screenings.Find(date, hallId);

            if (screen == null)
            {
                return HttpNotFound();
            }

            _context.Screenings.Remove(screen);
            _context.SaveChanges();

            return Redirect(Request.UrlReferrer.ToString());
        }

        //GET: Screenings
        public ActionResult Index()
        {
            var screensInDb = _context.Screenings
                .Include(m => m.Movie)
                .Include(g=>g.Movie.Genre)
                .OrderBy(d=>d.Date)
                .ToList();

            return View(screensInDb);
        }
    }
}