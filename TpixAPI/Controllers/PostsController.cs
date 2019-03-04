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
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostsController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public ActionResult<Post> GetPostById([FromRoute]int id)
        {
            var post = _postRepository.GetPostById(id);
            return post;
        }

        // GET: api/posts/GetPostsForTopic/{topicid}
        [HttpGet("GetPostsForTopic/{topicid}")]
        public ActionResult<IEnumerable<Post>> GetAllPostsForTopic([FromRoute]int topicId)
        {
            return _postRepository.GetAllPostsForTopicById(topicId);
        }

        // PUT: api/Posts/
        [HttpPut]
        public async Task<bool> EditPost([FromBody]PostRequest post)
        {
            return await _postRepository.EditPost(post);
        }

        // POST: api/Posts
        [HttpPost]
        public ActionResult<Post> AddPost([FromBody]PostRequest post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _postRepository.AddPost(post);

            return CreatedAtAction("GetPostById", new { id = post.Id }, post);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Post>> DeletePost([FromRoute]int id)
        {
            var post = await _postRepository.RemovePostById(id);

            return post;
        }


    }
}
