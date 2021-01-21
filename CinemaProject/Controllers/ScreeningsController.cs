using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinemaProject.Models;
using CinemaProject.ViewModel;

namespace CinemaProject.Controllers
{
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

            _context.Screenings.Add(screening);

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


        // GET: Screenings
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}