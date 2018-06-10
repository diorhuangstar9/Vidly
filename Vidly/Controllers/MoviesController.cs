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

        public ActionResult Edit(int moveiId)
        {
            return Content("id=" + moveiId);
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