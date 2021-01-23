using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CinemaProject.Models;

namespace CinemaProject.ViewModel
{
    public class CustomerFormViewModel
    {
        public string Customer { get; set; }

        public IEnumerable<Customer> Customers { get; set; }
    }
}