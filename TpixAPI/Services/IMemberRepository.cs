﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpixAPI.Models;
using TpixAPI.Models.Requests;

namespace TpixAPI.Services
{
    public interface IMemberRepository
    {
        void CreateMember(MemberRequest member);
        Member GetMember(int id);
        List<Member> GetAllMembers();
        Task<bool> EditMember(MemberRequest member);
        Task<Member> RemoveMemberById(int id);
        List<Member> SearchMembers(MemberRequest member);
    }
}
