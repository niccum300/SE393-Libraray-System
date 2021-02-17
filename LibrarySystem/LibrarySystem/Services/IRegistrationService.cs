using LibrarySystem.Data.Models;
using System.Threading.Tasks;

namespace LibrarySystem.Services
{
    public interface IRegistrationService
    {
        void Add(LibraryMember member);

        Task<LibraryMember> FindMember(int id);

        string RandomString();
    }
}
