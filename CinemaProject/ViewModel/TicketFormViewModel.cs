using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CinemaProject.Models;

namespace CinemaProject.ViewModel
{
    public class TicketFormViewModel
    {
        public IEnumerable<Ticket> TicketsList { get; set; }
        public Screening Screening { get; set; }
        public Ticket Ticket { get; set; }
    }
}