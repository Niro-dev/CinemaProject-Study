using CinemaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaProject.ViewModel
{
    public class CartViewModel
    {
        public IEnumerable<Ticket> Tickets { get; set; }


    }
}