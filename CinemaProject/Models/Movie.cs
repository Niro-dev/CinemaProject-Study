using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace CinemaProject.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Movie Plot")]
        public string Plot { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Upload Poster")]
        [Required(ErrorMessage = "Please choose file to upload.")]
        public string file { get; set; }
        public DateTime DateAdded { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public bool HasAnAgeLimitation { get; set; }
    }
}