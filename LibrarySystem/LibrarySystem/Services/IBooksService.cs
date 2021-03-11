using LibrarySystem.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Services
{
    public interface IBooksService
    {
        void Create(Book book);

        void Update(Book book);

        void Delete(Book book);

        Task<List<Book>> SearchTitle(string searchString);

        List<Book> GetMembersBooks(LibraryMember libraryMember);

        Book FindByISBN(string ISBN);
    }
}
