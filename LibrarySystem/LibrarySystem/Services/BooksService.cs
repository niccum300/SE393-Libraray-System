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

        public async Task<List<Book>> SearchTitle(string searchString)
        {

            using (ApplicationDbContext dbContext = _db.CreateDbContext())
            {
                return await dbContext.Books.Where(m => (m.Title.ToLower()).Contains(searchString.ToLower())).OrderBy(s => s.Title).ToListAsync();
            }
        }

        public List<Book> GetMembersBooks(LibraryMember libraryMember)
        {
            List<BookTransaction> transactions = new List<BookTransaction>();
            using (ApplicationDbContext dbContext = _db.CreateDbContext())
            {
               transactions = dbContext.Transactions.Where(b => b.LibraryMemberId == libraryMember.Id).ToList();
            }

            List<Book> books = new List<Book>();
            using (ApplicationDbContext dbContext = _db.CreateDbContext())
            {
                foreach (var T in transactions)
                {
                    books.Add(dbContext.Books.Where(b => b.Id == T.BookId).FirstOrDefault());
                }
            }
            return books;
        }

        public Book FindByISBN(string ISBN)
        {
            using (ApplicationDbContext dbContext = _db.CreateDbContext())
            {
                return dbContext.Books.Where(b => b.ISBN == ISBN).FirstOrDefault();
            }
        }
    }
}
