using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpixAPI.Models;

namespace TpixAPI.Services
{
    public class PostRepository : IPostRepository
    {
        public void AddPost(Post post)
        {
            throw new NotImplementedException();
        }

        public void EditPost(Post post)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetAllPostsForTopicById(int topicId)
        {
            throw new NotImplementedException();
        }

        public void GetPostById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetPostsByQuery(string postQuery)
        {
            throw new NotImplementedException();
        }

        public void RemovePostById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
