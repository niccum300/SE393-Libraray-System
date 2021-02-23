using LibrarySystem.Data.Models;

namespace LibrarySystem.Services
{
    public interface IBooksService
    {
        void Create(Book book);

        void Update(Book book);

        void Delete(Book book);
    }
}
