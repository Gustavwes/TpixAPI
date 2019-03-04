using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public void CreateMember(MemberRequest member)
        {
            _context.Member.Add(new Member(){Email = member.Email, Username = member.Username});
            _context.SaveChanges();
        }

        public List<Member> GetAllMembers() //will need some kind of pagination here skip/take etc.
        {
            return _context.Member.ToList();
        }
        public Member GetMember(int id)
        {
            return _context.Member.Find(id);
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
    }
}
