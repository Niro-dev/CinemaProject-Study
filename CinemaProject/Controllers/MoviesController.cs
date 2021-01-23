using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.IO;
using System.Web.Mvc;
using CinemaProject.Models;
using CinemaProject.ViewModel;

namespace CinemaProject.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        public ViewResult OrderByGenre(string genre)
        {
            var movies = _context.Movies.Include(m => m.Genre).Where(m=>m.Genre.Name.Equals(genre)).ToList();

            return View("Index",movies);
        }

        public ViewResult OrderByPopularity()
        {
            // getting movies id by the same order as in db into movieIdList
            var movieIdList = _context.Movies
                .Select(movie => movie.Id)
                .ToList();

            
            // filling the tuples by : 1 - the number of screenings of a movie 2- the id of this movie
            var tupleList = movieIdList
                .Select(movie => new Tuple<int, int>(_context.Screenings.Count(s => s.MovieId == movie), movie))
                .ToList();


            // sorting the tuples by the number of screenings
            tupleList.Sort((a, b) => b.Item1.CompareTo(a.Item1));

            // creating new list of movies that sorted by popularity
            var moviesSortedByPopularity = tupleList.Select(movie => _context.Movies
                    .Include(m => m.Genre)
                    .Single(m => m.Id == movie.Item2))
                .ToList();

            return View("Index", moviesSortedByPopularity);
        }


        public ViewResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie(),
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies
                .Include(m => m.Genre)
                .SingleOrDefault(m => m.Id == id);


            if (movie == null)
            {
                return HttpNotFound();
            }

            var screen = _context.Screenings
                .Where(s => s.MovieId == id && s.Date > DateTime.Now)
                .ToList();

            var viewModel = new MovieDetailsFormViewModel
            {
                Movie = movie,
                Screenings = screen
            };


            return View(viewModel);
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };

            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(HttpPostedFileBase file,Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                if (file != null)
                {
                    string path = Path.Combine(Server.MapPath("~/UploadedFiles"), Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    movie.file = Path.GetFileName(file.FileName);

                }
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.Plot = movie.Plot;
                movieInDb.HasAnAgeLimitation = movie.HasAnAgeLimitation;
                if (file != null)
                {
                    string path = Path.Combine(Server.MapPath("~/UploadedFiles"), Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    movie.file = path;
                }
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}