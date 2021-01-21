using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CinemaProject.Models;

namespace CinemaProject.Dtos
{
    public class MovieDto : ApiController
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public byte GenreId { get; set; }

        [Required]
        [StringLength(500)]
        public string Plot { get; set; }

        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "Please choose file to upload.")]
        public string file { get; set; }
        public DateTime DateAdded { get; set; }

        public DateTime ReleaseDate { get; set; }
        [Required]
        public bool HasAnAgeLimitation { get; set; }
    }
}
