using LibrarySystem.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Services
{
    public interface IMembersService
    {
        void Add(LibraryMember member);

        Task<LibraryMember> FindMember(int id);

        Task<List<LibraryMember>> SearchMembers(string searchString);

        string RandomString();
    }
}
