using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Vidley.Models;
using Vidley.ViewModels;

namespace Vidley.Controllers
{
    public class RentalsController : Controller
    {
        public ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult New()
        {
            return View();
        }

        //public ActionResult Return()
        //{
        //    var viewModel = new ReturnMovieViewModel();
        //    return View(viewModel);
        //}

       
        //[ValidateAntiForgeryToken]
        //public ActionResult Returned(ReturnMovieViewModel movie)
        //{
        //    if(!ModelState.IsValid)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.BadRequest);
                
        //    }

            

        //    try
        //    {
        //        var movieInDB = _context.Movies.Single(m => m.Name == movie.Name);
        //        if (movieInDB.NumberAvailable >= movieInDB.NumberInStock)
        //        {
        //            throw new HttpResponseException(HttpStatusCode.BadRequest);
        //        }
        //        movieInDB.NumberAvailable++;
        //        _context.SaveChanges();
        //    }
            

        //    catch(Exception e)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }
            
           

        //    return RedirectToAction("Return", "Rentals");
        //}
    }

}