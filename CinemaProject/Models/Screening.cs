using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CinemaProject.Models
{
    public class Screening
    {
        [Key]
        [Column(Order = 1)]
        public DateTime? Date { get; set; }

        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }

        [Required]
        public int MovieId { get; set; }
        
        
        [ForeignKey("HallId")]
        public Hall Hall { get; set; }

        [Key]
        [Column(Order = 2)]
        [Required]
        [Display(Name = "Hall")]
        public byte HallId { get; set; }

        [Required]
        public short Price { get; set; }

    }
}