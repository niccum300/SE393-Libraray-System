﻿using LibrarySystem.Data;
using LibrarySystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Services
{
    public class MembersService : IMembersService
    {
        readonly IDbContextFactory<ApplicationDbContext> _db;
        public MembersService(IDbContextFactory<ApplicationDbContext> db)
        {
            _db = db;
        }

        public void Add(LibraryMember member)
        {

            using (ApplicationDbContext dbContext = _db.CreateDbContext())
            {
                dbContext.LibraryMembers.Add(member);
                dbContext.SaveChanges();
            }
        }

        public async Task<LibraryMember> FindMember(int id)
        {
            LibraryMember member = new LibraryMember();
            using (ApplicationDbContext dbContext = _db.CreateDbContext())
            {
                member = await dbContext.LibraryMembers.Where(member => member.Id == id).FirstOrDefaultAsync();
                dbContext.SaveChanges();
            }

            return member;
        }

        public async Task<List<LibraryMember>> SearchMembers(string searchString)
        {

            using (ApplicationDbContext dbContext = _db.CreateDbContext())
            {
                return await dbContext.LibraryMembers.Where(m => m.FirstName.ToLower().Contains(searchString.ToLower())).ToListAsync();
            }
        }

        public string RandomString()
        {
            int length = 5;

            Random random = new Random();

            const string chars = "123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}