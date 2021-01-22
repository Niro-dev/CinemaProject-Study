using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CinemaProject.Models
{
    public class Ticket
    {
        [Key]
        [Column(Order = 1)]
        public short SeatNumber { get; set; }


        public Screening Screening { get; set; }

        [Key]
        [ForeignKey("Screening")]
        [Column(Order = 2)]
        public DateTime? Date { get; set; }


        [Key]
        [ForeignKey("Screening")]
        [Column(Order = 3)]
        public byte HallId { get; set; }

        
        public string CustomerUserId { get; set; }

        [ForeignKey("CustomerUserId")]
        public Customer Customer { get; set; }

        public DateTime? CreationTime { get; set; }

        public bool Paid { get; set; }
    }
}