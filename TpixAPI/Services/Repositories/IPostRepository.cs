using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpixAPI.Models;
using TpixAPI.Models.Database;
using TpixAPI.Models.Requests;

namespace TpixAPI.Services.Repositories
{
    public interface IPostRepository
    {
        void AddPost(PostRequest post);
        Task<bool> EditPost(PostRequest post);
        Task<List<Post>> GetAllPostsForTopicById(int topicId);
        Task<Post> GetPostById(int id);
        Task<List<Post>> GetPostsByQuery(string postQuery);
        Task<Post> RemovePostById(int id);

    }
}
