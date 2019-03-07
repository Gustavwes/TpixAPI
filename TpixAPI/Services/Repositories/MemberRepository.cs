using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TpixAPI.Data;
using TpixAPI.Models;
using TpixAPI.Models.Database;
using TpixAPI.Models.Requests;

namespace TpixAPI.Services.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly TpixContext _context;
        public MemberRepository(TpixContext context)
        {
            _context = context;
        }
        public Member CreateMember(MemberRequest member)
        {
            var newMember = new Member() {Email = member.Email, Username = member.Username, SignedUpAt = DateTime.UtcNow};
            _context.Member.Add(newMember);
            _context.SaveChanges();
            return newMember;
        }
        public async Task<bool> EditMember(MemberRequest member)
        {
            var entity =  await _context.Member.FindAsync(member.Id);
            if (entity != null)
            {
                entity.Username = member.Username;
                entity.Email = member.Email;
                _context.Member.Update(entity);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public async Task<List<Member>> GetAllMembers() //will need some kind of pagination here skip/take etc.
        {
            return await _context.Member.ToListAsync();
        }
        public Task<Member> GetMember(int id)
        {
            return _context.Member.FindAsync(id);
        }

        public async Task<Member> RemoveMemberById(int id)
        {   
            var member = await _context.Member.FindAsync(id);
            if (member == null)
            {
                return new Member();
            }

            _context.Member.Remove(member);
            await _context.SaveChangesAsync();

            return member;
        }

        public List<Member> SearchMembers(MemberRequest member)
        {
            return _context.Member.Where(m => m.Username.ToLower().Contains((member.Username ?? "").ToLower()) && m.Email.ToLower().Contains((member.Email ?? "").ToLower()))
                .ToList();
        }

        public void UpdateMemberGuid(MemberRequest member)
        {
            var entity = _context.Member.Find(member.Id);
            if (entity != null)
            {
                entity.IdentGuid = member.IdentGuid;
                _context.Member.Update(entity);
                _context.SaveChanges();
            }
        }
    }
}
