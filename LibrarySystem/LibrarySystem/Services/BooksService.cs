using LibrarySystem.Data;
using LibrarySystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Services
{
    public class BooksService : IBooksService
    {
        readonly IDbContextFactory<ApplicationDbContext> _db;

        public BooksService(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _db = contextFactory;
        }

        public void Create(Book book)
        {
            using (var conn = _db.CreateDbContext())
            {
                conn.Books.Add(book);
                conn.SaveChanges();
            }
        }

        public void Update(Book book)
        {
            using (var conn = _db.CreateDbContext())
            {
                conn.Entry(book).State = EntityState.Modified;
                conn.SaveChanges();
            }
        }

        public void Delete(Book book)
        {
            using (var conn = _db.CreateDbContext())
            {
                conn.Entry(book).State = EntityState.Deleted;
                conn.SaveChanges();
            }
        }
    }
}
