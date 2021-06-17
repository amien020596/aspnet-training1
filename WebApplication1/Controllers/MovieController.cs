using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movie
        public ActionResult Random()
        {
            var movies = new Movie() { Name = "Shrek!" };
            var customers = new List <Customer> { 
                new Customer {Name = "Amien Kurniawan"},
                new Customer {Name = "Amri Luthfi"}
            };
            var viewModel = new RandomMovieViewModel {
                Movie = movies,
                Customers = customers
            };
            return View(viewModel);
        }
        public ActionResult Edit(int id) {
            return Content("id=" + id); 
        }
        // to make optional parameter using int?
        public ActionResult Index(int? page, string sortBy) {
            if (!page.HasValue)
            {
                page= 1;
            }
            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }
            return Content(String.Format("pageIndex={0}&sortBy={1}", page,sortBy));

        }
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month) {
            return Content(year+"/"+month);
        }
    }
}