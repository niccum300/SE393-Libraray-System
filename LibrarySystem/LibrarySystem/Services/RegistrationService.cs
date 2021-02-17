using LibrarySystem.Data;
using LibrarySystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Services
{
    public class RegistrationService : IRegistrationService
    {
        readonly IDbContextFactory<ApplicationDbContext> _db;
        public RegistrationService(IDbContextFactory<ApplicationDbContext> db)
        {
            _db = db;
        }

        public void Add(LibraryMember member)
        {
            using (ApplicationDbContext dbContext = _db.CreateDbContext())
            {
                dbContext.LibraryMembers.Add(member);
                dbContext.SaveChanges();
            }
        }

    }
}
