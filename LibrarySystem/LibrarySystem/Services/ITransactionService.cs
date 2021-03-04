using LibrarySystem.Data.Models;

namespace LibrarySystem.Services
{
    public interface ITransactionService
    {
        void Create(BookTransaction transaction);

        void Update(BookTransaction transaction);

        void Delete(BookTransaction transaction);
    }

}
