using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidley.Models;

namespace Vidley.ViewModels
{
    public class ReturnMovieViewModel
    {
        public int Id;
        [Required]
        public string Name;

        public ReturnMovieViewModel()
        {

        }

        public ReturnMovieViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
        }
    }
}