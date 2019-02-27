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
        Task<bool> EditTopic(Topic topic);
        List<Post> GetAllPostsForTopicById(int topicId); //should be moved to posts repository
        List<Topic> GetAllTopicsForCategoryById(int id);
        Topic GetTopicById(int id);
        Task<Topic> RemoveTopicById(int id);
        bool Save();
    }
}
