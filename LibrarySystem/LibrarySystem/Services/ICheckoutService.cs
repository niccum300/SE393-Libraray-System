using LibrarySystem.Data.Models;
using System.Collections.Generic;

namespace LibrarySystem.Services
{
    public interface ICheckoutService
    {
        void CheckoutBook(List<Book> books, LibraryMember libraryMember);

        void CheckInBooks(List<Book> books, LibraryMember libraryMember);

        void Add(BookTransaction transaction);

        int CopiesLeft(Book book);
    }
}
