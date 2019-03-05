using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TpixAPI.Data;
using TpixAPI.Models;
using TpixAPI.Models.Database;
using TpixAPI.Models.Requests;

namespace TpixAPI.Services.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly TpixContext _context;

        public PostRepository(TpixContext context)
        {
            _context = context;
        }
        public void AddPost(PostRequest post)
        {
            _context.Post.Add(new Post() { CreatedAt = DateTime.UtcNow, FkCreatedBy = post.FkCreatedBy, FkParentTopicId = post.FkParentTopicId, MainBody = post.MainBody });
            _context.SaveChanges();
        }

        public async Task<bool> EditPost(PostRequest post)
        {
            var entity = await _context.Post.FindAsync(post.Id);
            if (entity != null)
            {
                entity.EditedAt = DateTime.UtcNow;
                entity.FkParentTopicId = post.FkParentTopicId == 0 ? entity.FkParentTopicId : post.FkParentTopicId;
                entity.MainBody = post.MainBody == String.Empty ? entity.MainBody : post.MainBody;
                _context.Post.Update(entity);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public Task<List<Post>> GetAllPostsForTopicById(int topicId)
        {
            return _context.Topic.Where(x => x.Id == topicId)
                .SelectMany(topic => topic.Post)
                .OrderBy(post => post.CreatedAt)
                .ToListAsync();
        }

        public Task<Post> GetPostById(int id)
        {
            return _context.Post.FindAsync(id);
        }

        public Task<List<Post>> GetPostsByQuery(string postQuery)
        {
            return _context.Post.Where(post => post.MainBody.Contains(postQuery)).ToListAsync();
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
