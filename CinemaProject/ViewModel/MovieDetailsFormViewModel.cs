using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CinemaProject.Models;

namespace CinemaProject.ViewModel
{
    public class MovieDetailsFormViewModel
    {
        public IEnumerable<Screening> Screenings { get; set; }
        public Movie Movie { get; set; }
    }
}