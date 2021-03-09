using LibrarySystem.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Services
{
    public interface IMembersService
    {
        void Add(LibraryMember member);

        void Update(LibraryMember member);

        void Delete(LibraryMember member);

        Task<LibraryMember> FindMember(int id);

        LibraryMember FindMember(string cardNumber);

        Task<List<LibraryMember>> SearchMembers(string searchString);

        string RandomString();
    }
}
