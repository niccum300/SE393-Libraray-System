using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Data.Models
{
    public class LibraryMember : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int CardNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        [MaxLength(10)]
        [Required]
        public string PhoneNumber { get; set; }
    }
}
