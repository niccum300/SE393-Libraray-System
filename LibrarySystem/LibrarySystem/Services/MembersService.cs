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
        
        public void Update(LibraryMember member)
        {
            using (ApplicationDbContext dbContext = _db.CreateDbContext())
            {
                dbContext.Entry(member).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }

        public void Delete(LibraryMember member)
        {
            using (ApplicationDbContext dbContext = _db.CreateDbContext())
            {
                dbContext.Entry(member).State = EntityState.Deleted;
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

        public LibraryMember GetMember(int id)
        {
            LibraryMember member = new LibraryMember();
            using (ApplicationDbContext dbContext = _db.CreateDbContext())
            {
                member = dbContext.LibraryMembers.Where(member => member.Id == id).FirstOrDefault();
                dbContext.SaveChanges();
            }

            return member;
        }

        public LibraryMember FindMember(string cardNumber)
        {
            LibraryMember libraryMember;
            using (ApplicationDbContext dbContext = _db.CreateDbContext())
            {
                libraryMember = dbContext.LibraryMembers.Where(m => m.CardNumber == cardNumber).FirstOrDefault();
            }

            return libraryMember;
        }

        public async Task<List<LibraryMember>> SearchMembers(string searchString)
        {

            using (ApplicationDbContext dbContext = _db.CreateDbContext())
            {
                return await dbContext.LibraryMembers.Where(m => (m.FirstName.ToLower() + " " + m.LastName.ToLower()).Contains(searchString.ToLower())).OrderBy(s => s.LastName).ToListAsync();
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
