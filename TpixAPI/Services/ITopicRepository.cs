using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpixAPI.Models;

namespace TpixAPI.Services
{
    public interface ITopicRepository
    {
        void AddTopic(Topic topic);
        Topic GetTopicById(int id);
        List<Post> GetAllPostsForTopicById(int topicId); //should be moved to posts repository
        Task<Topic> RemoveTopicById(int id);
        Task<bool> EditTopic(Topic topic);
        List<Topic> GetAllTopicsForCategoryById(int id);
        bool Save();
    }
}
