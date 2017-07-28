using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidley.Models;
using Vidley.ViewModels;
using System.Data.Entity;

namespace Vidley.Controllers
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

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movies = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            return View(movies);
        }


        //public List<Movie> getMovies()
        //{
        //    var mList = new List<Movie>
        //    {
        //        new Movie{Id = 1,Name="Shrek!"},
        //        new Movie{Id = 2,Name = "Wall-E"}
        //    };

        //    return mList;
        //}



        //// GET: Movies/Random
        //public ActionResult Random()
        //{
        //    var mList = getMovies();
        //    var movieList = new MovieListViewModel { MovieList = mList };

        //    return View(movieList);
        //}

        //public ActionResult Random()
        //{
        //    var movie = new Movie() { Name = "Shrek!" };
        //    var customers = new List<Customer>
        //    {
        //        new Customer{ Name = "Customer1"},
        //        new Customer{ Name = "Customer2"}
        //    };
        //    var viewModel = new RandomMovieViewModel
        //    {
        //        Movie = movie,
        //        Customers = customers
        //    };

        //    return View(viewModel);
        //}



        //public ActionResult Index()
        //{

        //    var movieList = new List<Movie>
        //    {
        //        new Movie{Id = 1,Name="Shrek!"},
        //        new Movie{Id = 2,Name = "Wall-E"}
        //    };


        //    return View(movieList);
        //}

    }

}


        //[Route("movies/released/{year}/{month:regex(\\d{2}): range(1,12)}")]
        //public ActionResult ByReleaseYear(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}

    //    public ActionResult Edit(int id)
    //    {
    //        return Content("id =" + id);
    //    }

    //    public ActionResult Index(int? pageIndex, string sortyBy)
    //    {
    //        if (!pageIndex.HasValue)
    //        {
    //            pageIndex = 1;
    //        }
    //        if(String.IsNullOrWhiteSpace(sortyBy))
    //        {
    //            sortyBy = "Name";
    //        }

    //        return Content(String.Format("pageIndex={0}&sortyBy={1}", pageIndex, sortyBy));
    //    }

    //    public ActionResult ByReleaseDate(int year, int month)
    //    {
    //        return Content(year + "/" + month);
    //    }
            

    //}
