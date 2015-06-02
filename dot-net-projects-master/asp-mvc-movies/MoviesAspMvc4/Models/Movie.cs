using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MoviesAspMvc4.Models
{  
    public class Movie
    {
        public int ID { get; set; }
        
        [Required]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}")]
        public DateTime ReleaseDate { get; set; }
        
        [Required]
        public string Genre { get; set; }
        
        [Range(1,100)]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Price { get; set; }

        [StringLength(5)]
        public string Rating { get; set; }
    }

    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}