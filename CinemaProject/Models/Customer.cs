using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CinemaProject.Models
{
    public class Customer
    {
        [Key]
        [Column(Order = 1)]
        public string CustomerUserId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime? Birthdate { get; set; }

    }
}