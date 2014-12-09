using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using S00126107.Models;
using PagedList;
    
namespace S00126107.Controllers
{
    public class HomeController : Controller
    {
        private MoviesDb db = new MoviesDb();

        // GET: Home
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, string genreFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            if (sortOrder == null) sortOrder = "descTitle";
            ViewBag.titleOrder = (sortOrder == "ascTitle") ? "descTitle" : "ascTitle";
            ViewBag.dateOrder = (sortOrder == "ascDate") ? "descDate" : "ascDate";
            ViewBag.ratingOrder = (sortOrder == "ascRating") ? "descRating" : "ascRating";


            //if (searchString != null)
            //{
            //    page = 1;
            //}
            //else
            //{
            //    searchString = currentFilter;
            //}

            //ViewBag.CurrentFilter = searchString;

            IQueryable<Movie> movies = db.Movies;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString.ToUpper()));
            }

            //if (!String.IsNullOrEmpty(genreFilter))
            //{
            //    movies = movies.Where(g => g.Genre.Title.Contains(genreFilter.ToUpper()));
            //}

            switch (sortOrder)
            {
                case "descRating":
                    ViewBag.ratingOrder = "ascRating";
                    movies = movies.OrderBy(m => m.Rating);
                    break;
                case "descDate":
                    ViewBag.dateOrder = "ascDate";
                    movies = movies.OrderBy(m => m.ReleaseDate);
                    break;
                case "descTitle":
                    ViewBag.titleOrder = "ascTitle";
                    movies = movies.OrderBy(m => m.Title);
                    break;
                case "ascRating":
                    ViewBag.ratingOrder = "descRating";
                    movies = movies.OrderByDescending(m => m.Rating);
                    break;
                case "ascDate":
                    ViewBag.dateOrder = "descDate";
                    movies = movies.OrderByDescending(m => m.ReleaseDate);
                    break;
                case "ascTitle":
                    ViewBag.titleOrder = "descTitle";
                    movies = movies.OrderByDescending(m => m.Title);
                    break;
            }

            //int pageSize = 3;
            //int pageNumber = (page ?? 1);
            //return View(movies.ToPagedList(pageNumber, pageSize));
            return View(movies.ToList());
        }

        // filter by genre
        //public JsonResult Autocomplete(string search)
        //{
          
        //}

        // Get MovieCast
        public PartialViewResult GetMovieCast(int id)
        {
            var cast = db.Casts.Where(c => c.MovieId == id);
            return PartialView("_Cast", cast);
        }

        // GET: Home/Details/5
        public PartialViewResult Details(int? id)
        {
            Movie movie = db.Movies.Find(id);
            return PartialView("_Details", movie);
        }

        // GET: Home/Create
        public PartialViewResult Create()
        {
            return PartialView("_Create");
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieId,Title,ReleaseDate,Rating,Certificate,Runtime,Language,ImageUrl")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Home/Edit/5

        public PartialViewResult Edit(int? id)
        {
            Movie movie = db.Movies.Find(id);
            return PartialView("_Edit", movie);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieId,Title,ReleaseDate,Rating,Certificate,Runtime,Language,ImageUrl")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Home/Delete/5
        public PartialViewResult Delete(int? id)
        {
            Movie movie = db.Movies.Find(id);
            return PartialView("_Delete", movie);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
