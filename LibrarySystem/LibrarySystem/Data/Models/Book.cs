using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Data.Models
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int Copies { get; set; }
        // Transactions
    }
}
