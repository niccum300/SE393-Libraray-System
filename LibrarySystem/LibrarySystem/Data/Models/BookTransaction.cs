using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Data.Models
{
    public class BookTransaction
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public int LibraryMemberId { get; set; }

        public DateTime CheckoutDate { get; set; }

        public DateTime DueDate { get; set; }
    }
}
