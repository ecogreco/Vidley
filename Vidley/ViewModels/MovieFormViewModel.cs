using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidley.Models;

namespace Vidley.ViewModels
{
    public class MovieFormViewModel // View model to pass into the movie form 
    {
        //breaking apart the movie object so there won't be pre-determined values in the input fields, using only the nessescary fields
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }


        [Required]
        [Display(Name = "Genre Type")]
        public byte? GenreId { get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Number in Stock")]
        public int? NumberInStock { get; set; }



        public IEnumerable<Genre> Genres { get; set; }
        public string Title {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public MovieFormViewModel() // constructor method for a new movie 
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie) //constructor method for a pre existing movie, the "movie" object is in reference to the movie in the database 
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }

    }
}