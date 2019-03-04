using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TpixAPI.Models;
using TpixAPI.Models.Requests;
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
        [HttpGet]
        public ActionResult<List<Member>> GetAllMembers()
        {
            return _memberRepository.GetAllMembers();
        }

        // GET: api/Members/5
        [HttpGet("{id}")]
        public ActionResult<Member> GetMemberById([FromRoute]int id)
        {
            var member = _memberRepository.GetMember(id);
            if (member == null)
            {
                return NotFound();
            }

            return member;
        }

        // GET: api/Members
        [HttpGet("SearchMembers/")]
        public ActionResult<List<Member>> SearchMembers([FromBody]MemberRequest member) //send object with username and/or email
        {
            //should be made to a SearchMemberRequest object in the future
            return _memberRepository.SearchMembers(member);
        }

        //// PUT: api/Members
        [HttpPut]
        public async Task<ActionResult<bool>> EditMember([FromBody]MemberRequest member)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return await _memberRepository.EditMember(member); 
        }

        // POST: api/Members
        [HttpPost]
        public ActionResult<MemberRequest> AddMember([FromBody]MemberRequest member)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _memberRepository.CreateMember(member);

            return member;
        }

        //// DELETE: api/Members/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Member>> DeleteMember([FromRoute]int id)
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
