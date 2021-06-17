using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movie
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            // return View(movie);
            return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
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
        public ActionResult ByReleaseDate(int year, int month) {
            return Content(year+"/"+month);
        }
    }
}