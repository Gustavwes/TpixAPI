using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpixAPI.Models;

namespace TpixAPI.Services
{
    public interface IMemberRepository
    {
        void CreateMember(Member member);
        Member GetMember(int id);
        Task<bool> EditMember(Member member);
        Task<Member> RemoveMemberById(int id);
        List<Member> SearchMembers(Member member);
    }
}
