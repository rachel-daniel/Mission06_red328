using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_red328.Models
{
    public class AddMovie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        // Foregin Key Relationship
        [Required(ErrorMessage = "Category Required")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }


        [Required(ErrorMessage = "Title Required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Year Required")]
        public string Year { get; set; }

        [Required(ErrorMessage = "Director Required")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Rating Required")]
        public string Rating { get; set; }

        public bool Edited { get; set; }

        public string LentTo { get; set; }

        [MaxLength(25)]
        public string Notes { get; set; }
    }
}
