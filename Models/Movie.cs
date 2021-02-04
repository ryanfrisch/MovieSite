using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieSite.Models
{
    public class Movie
    {
        [Required(ErrorMessage ="You need to enter a Category!")]
        public string Category { get; set; }
        [Required(ErrorMessage = "You need to enter a Title!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "You need to enter a Year!")]
        public int? Year { get; set; }
        [Required(ErrorMessage = "You need to enter a Director!")]
        public string Director { get; set; }
        [Required(ErrorMessage = "You need to enter a Rating!")]
        public string Rating { get; set; }

        public bool? Edited { get; set; }
        public string Lent_To { get; set; }
        [MaxLength(120)]
        public string Notes { get; set; }

    }
}
