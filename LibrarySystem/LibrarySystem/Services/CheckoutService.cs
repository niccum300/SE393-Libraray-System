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
        private readonly IBooksService _booksService;
        private readonly ITransactionService _transactionService;

        public CheckoutService(IDbContextFactory<ApplicationDbContext> db, IBooksService booksService,
            ITransactionService transactionService)
        {
            _db = db;
            _booksService = booksService;
            _transactionService = transactionService;
        }

        public int CopiesLeft(Book book)
        {
            var b = _booksService.FindByISBN(book.ISBN);

            if (b != null)
            {
                return b.CopiesLeft;
            }
            else
            {
                return -1;
            }
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
                    DueDate = dateTime.AddDays(14),
                };

                b.CopiesLeft -= 1;

                _booksService.Update(b);

                Add(transaction);
            }

        }

        public void CheckInBooks(List<Book> books, LibraryMember libraryMember)
        {

            foreach (Book b in books)
            {
                _transactionService.Delete(b, libraryMember);

                b.CopiesLeft += 1;
                if (b.CopiesLeft <= b.Copies)
                {
                    _booksService.Update(b);
                }
                
            }

        }

        public int CopiesCheckedOut(LibraryMember libraryMember)
        {
            int count = 0;
            using (var conn = _db.CreateDbContext())
            {

                count = conn.Transactions.Where(t => t.LibraryMemberId == libraryMember.Id).Count();
            }

            return count;
        }
    }
}
