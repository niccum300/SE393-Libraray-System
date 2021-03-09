using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Data.Models
{
    public class Book : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(13)]
        public string ISBN { get; set; }

        [Required]
        public int Copies { get; set; }

        public int CopiesLeft { get; set; }
    }
}
