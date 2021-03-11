using LibrarySystem.Data.Models;
using System.Collections.Generic;

namespace LibrarySystem.Services
{
    public interface ICheckoutService
    {
        void CheckoutBook(List<Book> books, LibraryMember libraryMember);

        void CheckInBooks(List<Book> books, LibraryMember libraryMember);

        void CheckInBook(Book book, LibraryMember libraryMember);

        int CopiesCheckedOut(LibraryMember libraryMember);

        public List<BookTransaction> Transactions(LibraryMember libraryMember);

        void Add(BookTransaction transaction);

        int CopiesLeft(Book book);
    }
}
