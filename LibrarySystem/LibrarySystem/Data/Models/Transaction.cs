using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Data.Models
{
    public class Transaction
    {
        [Required]
        public Book Book { get; set; }

        [Required]
        public User User { get; set; }
    }
}
