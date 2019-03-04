﻿using System;
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

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public ActionResult<PostRequest> GetPostById([FromRoute]int id)
        {
            var post = _postRepository.GetPostById(id);
            return _mapper.Map<PostRequest>(post);
        }

        // GET: api/posts/GetPostsForTopic/{topicid}
        [HttpGet("GetPostsForTopic/{topicid}")]
        public ActionResult<List<PostRequest>> GetAllPostsForTopic([FromRoute]int topicId)
        {
            return _mapper.Map<List<PostRequest>>(_postRepository.GetAllPostsForTopicById(topicId));
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
