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
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostsController(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        // GET: api/posts/GetPostsForTopic/{topicid}
        [HttpGet("GetPostsForTopic/{topicid}")]
        public async Task<ActionResult<List<PostRequest>>> GetAllPostsForTopic([FromRoute]int topicId)
        {
            //var test = _mapper.Map<List<PostRequest>>(await _postRepository.GetAllPostsForTopicById(topicId));
            //return test;
            return _mapper.Map<List<PostRequest>>(await _postRepository.GetAllPostsForTopicById(topicId));
        }
        
        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostRequest>> GetPostById([FromRoute]int id)
        {
            var post = await _postRepository.GetPostById(id);
            return _mapper.Map<PostRequest>(post);
        }


        // PUT: api/Posts/
        [HttpPut]
        public async Task<bool> EditPost([FromBody]PostRequest post)
        {
            return await _postRepository.EditPost(post);
        }

        // POST: api/Posts
        [HttpPost]
        public ActionResult<PostRequest> AddPost([FromBody]PostRequest post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _postRepository.AddPost(post);

            return CreatedAtAction("GetPostById", new { id = post.Id }, post);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PostRequest>> DeletePost([FromRoute]int id)
        {
            var post = await _postRepository.RemovePostById(id);

            return _mapper.Map<PostRequest>(post);
        }


    }
}
