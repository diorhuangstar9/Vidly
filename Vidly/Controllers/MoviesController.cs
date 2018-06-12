using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
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

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!"};
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
            //return new ViewResult();
            //ViewData["Movie"] = movie;

            return View(viewModel);
            //return RedirectToAction("Index", "Home", new { page=1, sortBy = "name"});
        }

        public ActionResult New()
        {
            var Genres = _context.Genres.ToList();
            var newMovieViewModel = new MovieFormViewModel()
            {
                Genres = Genres,
            };
            return View("MovieForm", newMovieViewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;

            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();
            var model = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList(),
            };
            return View("MovieForm", model);
        }

        // movies
        //public ActionResult Index(int? pageIndex, string sortBy)
        public ActionResult Index()
        {
//            if (!pageIndex.HasValue)
//                pageIndex = 1;
//            if (string.IsNullOrEmpty(sortBy))
//                sortBy = "Name";
//            return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Detail(int id)
        {
            var detail = _context.Movies.Include(c => c.Genre).SingleOrDefault(
                c => c.Id == id);
            if (detail == null)
            {
                return HttpNotFound();
            }
            return View(detail);
        }
    }
}