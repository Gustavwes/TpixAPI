using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpixAPI.Models;

namespace TpixAPI.Services
{
    public class PostRepository : IPostRepository
    {
        private readonly TpixContext _context;

        public PostRepository(TpixContext context)
        {
            _context = context;
        }
        public void AddPost(Post post)
        {
            post.CreatedAt = DateTime.UtcNow;
            _context.Post.Add(post);
            _context.SaveChanges();
        }

        public async Task<bool> EditPost(Post post)
        {
            var entity = await _context.Post.FindAsync(post.Id);
            if (entity != null)
            {
                //should probably add a date for "Date Modified" to make it clearer when showing post
                entity.MainBody = post.MainBody;
                entity.FkParentTopicId = post.FkParentTopicId;
                _context.Post.Update(entity);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public List<Post> GetAllPostsForTopicById(int topicId)
        {
            return _context.Topic.Where(x => x.Id == topicId)
                .SelectMany(topic => topic.Post)
                .OrderBy(post => post.CreatedAt)
                .ToList();
        }

        public Post GetPostById(int id)
        {
            return _context.Post.Find(id);
        }

        public List<Post> GetPostsByQuery(string postQuery)
        {
            return _context.Post.Where(post => post.MainBody.Contains(postQuery)).ToList();
        }

        public async Task<Post> RemovePostById(int id)
        {
            var post = await _context.Post.FindAsync(id);
            if (post == null)
            {
                return new Post();
            }
            _context.Post.Remove(post);
            await _context.SaveChangesAsync();
            //return post for confirmation to user
            return post;
        }
    }
}
