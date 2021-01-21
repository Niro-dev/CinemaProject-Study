using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CinemaProject.Models;

namespace CinemaProject.ViewModel
{
    public class ScreeningFormViewModel
    {
        public IEnumerable<Movie> Movie { get; set; }
        public IEnumerable<Hall> Halls { get; set; }
        public Screening Screening { get; set; }
    }
}