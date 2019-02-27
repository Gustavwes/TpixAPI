using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpixAPI.Models;

namespace TpixAPI.Services
{
    public interface IPostRepository
    {
        void AddPost(Post post);
        Task<bool> EditPost(Post post);
        List<Post> GetAllPostsForTopicById(int topicId);
        Post GetPostById(int id);
        List<Post> GetPostsByQuery(string postQuery);
        Task<Post> RemovePostById(int id);

    }
}
