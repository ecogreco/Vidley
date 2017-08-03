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
        private ApplicationDbContext _context; //the _context variable is the object that calls the database

       public MoviesController() //constructor class for the CustomerController and assigns the _context ApplicationDbContext
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing) //nessescary method for the database object
        {
            _context.Dispose();
        }

        [Authorize(Roles =RoleName.CanManageMovies)]
        public ActionResult New() //creates new movie
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel() //the CustomerFormViewModel is suppose to be an object that includes a single customer but a list of membership types 
            {
                Genres = genres,     
            };

            return View("MovieForm",viewModel);
        }

        public ActionResult Edit(int id)
        {
            
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if( movie == null)
            {
                return HttpNotFound();
            }

            var ViewModel = new MovieFormViewModel(movie) //the CustomerFormViewModel is suppose to be an object that includes a movie from the database and a list of Genres
            {
                Genres = _context.Genres.ToList(),              
            };

            return View("MovieForm", ViewModel);
        }

        [HttpPost] //nessescary property for an action
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if(!ModelState.IsValid) // If there is no input or valid input from the user
            {
                var viewModel = new MovieFormViewModel(movie) //this method is for a pre existing movie
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel); // passes in the view model and brings the customer form 
            }

            if(movie.Id==0) // the Id == 0 indicates that there is no customer in the database selected and therefore a new customer is being added 
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDB = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDB.Name = movie.Name;
                movieInDB.ReleaseDate = movie.ReleaseDate;
                movieInDB.GenreId = movie.GenreId;
                movieInDB.NumberInStock = movie.NumberInStock;

            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies"); //the redirect method returns the user to the index page
        }

        public ActionResult Index()
        { 
            if(User.IsInRole(RoleName.CanManageMovies))
            {
                return View("List");
            }

            return View("ReadOnlyList");

        }

        public ActionResult Details(int id)
        {
            var movies = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            return View(movies);
        }





        //Irrelevant Code
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
