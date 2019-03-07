using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TpixAPI.Models;
using TpixAPI.Models.Requests;
using TpixAPI.Services;
using TpixAPI.Services.Repositories;

namespace TpixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public MembersController(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }


        //// GET: api/Members
        [HttpGet]
        public async Task<ActionResult<List<MemberRequest>>> GetAllMembers()
        {
            var returnedMembers = await _memberRepository.GetAllMembers();
            return _mapper.Map<List<MemberRequest>>(returnedMembers);
        }

        // GET: api/Members/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MemberRequest>> GetMemberById([FromRoute]int id)
        {
            var member = await _memberRepository.GetMember(id);
            if (member == null)
            {
                return NotFound();
            }

            return _mapper.Map<MemberRequest>(member);
        }

        // GET: api/Members
        [HttpGet("SearchMembers/")]
        public ActionResult<List<MemberRequest>> SearchMembers([FromBody]MemberRequest member) //send object with username and/or email
        {
            var result = _memberRepository.SearchMembers(member);
            var returnList = _mapper.Map<List<MemberRequest>>(result);
            //should be made to a SearchMemberRequest object in the future
            return returnList;
        }

        // PUT: api/Members
        [HttpPut]
        public async Task<ActionResult<bool>> EditMember([FromBody]MemberRequest member)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return await _memberRepository.EditMember(member); 
        }

        // PUT: api/Members/UpdateMemberGuid
        [HttpPut("UpdateMemberGuid/")]
        public void UpdateMemberGuid([FromBody]MemberRequest member)
        {
            _memberRepository.UpdateMemberGuid(member);
        } 

        // POST: api/Members
        [HttpPost]
        public ActionResult<MemberRequest> AddMember([FromBody]MemberRequest member)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var newMember =_memberRepository.CreateMember(member);
            return _mapper.Map<MemberRequest>(newMember);
        }


        // DELETE: api/Members/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MemberRequest>> DeleteMember([FromRoute]int id)
        {
            var result = await _memberRepository.RemoveMemberById(id);
            
            return _mapper.Map<MemberRequest>(result);
        }

        //private bool MemberExists(int id)
        //{
        //    return _context.Member.Any(e => e.Id == id);
        //}
    }
}
