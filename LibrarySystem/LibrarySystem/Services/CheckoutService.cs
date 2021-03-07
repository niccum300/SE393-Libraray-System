using LibrarySystem.Data;
using LibrarySystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _db;

        public CheckoutService(IDbContextFactory<ApplicationDbContext> db)
        {
            _db = db;
        }

        public void Add(BookTransaction transaction)
        {
            using (var conn = _db.CreateDbContext())
            {
                conn.Entry(transaction).State = EntityState.Added;
                conn.SaveChanges();
            }
        }

        public void CheckoutBook(List<Book> books, LibraryMember libraryMember)
        {

            DateTime dateTime = DateTime.Now;
            foreach (Book b in books)
            {
                BookTransaction transaction = new BookTransaction
                {
                    BookId = b.Id,
                    LibraryMemberId = libraryMember.Id,
                    CheckoutDate = dateTime,
                    DueDate = dateTime.AddDays(14)
                };

                Add(transaction);
            }

        }
    }

    public interface ICheckoutService
    {
        void CheckoutBook(List<Book> books, LibraryMember libraryMember);

        void Add(BookTransaction transaction);
    }
}
