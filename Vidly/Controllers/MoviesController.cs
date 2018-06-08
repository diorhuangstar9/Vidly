using System;
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
            var movies = new List<Movie>
            {
                //new Movie { Id = 1, Name = "Revengers"},
                //new Movie { Id = 2, Name = "Spider"},
            };

            return View(movies);
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}