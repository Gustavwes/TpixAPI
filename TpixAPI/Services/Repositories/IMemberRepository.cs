using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpixAPI.Models;
using TpixAPI.Models.Database;
using TpixAPI.Models.Requests;

namespace TpixAPI.Services.Repositories
{
    public interface IMemberRepository
    {
        Member CreateMember(MemberRequest member);
        Task<bool> EditMember(MemberRequest member);
        Task<Member> GetMember(int id);
        Task<List<Member>> GetAllMembers();
        Task<Member> RemoveMemberById(int id);
        List<Member> SearchMembers(MemberRequest member);
        void UpdateMemberGuid(MemberRequest member);
    }
}
