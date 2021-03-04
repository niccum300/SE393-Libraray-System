﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Data.Models
{
    public class KioskList
    {
        public int Id { get; set; }
        public int LibraryMemberId { get; set; }
        public LibraryMember LibraryMember { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

    }
}
