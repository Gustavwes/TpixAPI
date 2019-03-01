using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TpixAPI.Models;
using TpixAPI.Services;

namespace TpixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;

        public MembersController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }


        //// GET: api/Members
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Member>>> GetMember()
        //{
        //    return await _context.Member.ToListAsync();
        //}

        // GET: api/Members/5
        [HttpGet("{id}")]
        public ActionResult<Member> GetMemberById(int id)
        {
            var member = _memberRepository.GetMember(id);
            if (member == null)
            {
                return NotFound();
            }

            return member;
        }

        // GET: api/Members
        public ActionResult<List<Member>> SearchMembers(Member member) //send object with username and/or email
        {
            return _memberRepository.SearchMembers(member);
        }

        //// PUT: api/Members
        [HttpPut]
        public async Task<IActionResult> EditMember(Member member)
        {
            await _memberRepository.EditMember(member);

            return NoContent();
        }

        // POST: api/Members
        [HttpPost]
        public ActionResult<Member> AddMember(Member member)
        {
            _memberRepository.CreateMember(member);

            return CreatedAtAction("GetMember", new { id = member.Id }, member);
        }

        //// DELETE: api/Members/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Member>> DeleteMember(int id)
        {
            var result = await _memberRepository.RemoveMemberById(id);

            return result;
        }

        //private bool MemberExists(int id)
        //{
        //    return _context.Member.Any(e => e.Id == id);
        //}
    }
}
