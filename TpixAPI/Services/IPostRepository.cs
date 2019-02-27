using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpixAPI.Models;

namespace TpixAPI.Services
{
    interface IPostRepository
    {
        void AddPost(Post post);
        void EditPost(Post post);
        List<Post> GetAllPostsForTopicById(int topicId);
        void GetPostById(int id);
        List<Post> GetPostsByQuery(string postQuery);
        void RemovePostById(int id);

    }
}
