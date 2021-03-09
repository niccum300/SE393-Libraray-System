using LibrarySystem.Data;
using LibrarySystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Services
{
    public class TransactionService : ITransactionService
    {
        readonly IDbContextFactory<ApplicationDbContext> _db;

        public TransactionService(IDbContextFactory<ApplicationDbContext> db)
        {
            _db = db;
        }
     
        public void Create(BookTransaction transaction)
        {
            using (var conn = _db.CreateDbContext())
            {
                conn.Entry(transaction).State = EntityState.Added;
                conn.SaveChanges();
            }
        }

        public void Update(BookTransaction transaction)
        {
            using (var conn = _db.CreateDbContext())
            {
                conn.Entry(transaction).State = EntityState.Modified;
                conn.SaveChanges();
            }
        }

        public void Delete(Book book, LibraryMember libraryMember)
        {
            BookTransaction transaction = new BookTransaction();
            using (var conn = _db.CreateDbContext())
            {
                transaction = conn.Transactions.Where(t => t.LibraryMemberId == libraryMember.Id && t.BookId == book.Id).FirstOrDefault();

                if (transaction != null)
                {
                    conn.Entry(transaction).State = EntityState.Deleted;
                    conn.SaveChanges();
                }
            }
        }
    }

}
