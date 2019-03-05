using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpixAPI.Models;
using TpixAPI.Models.Database;
using TpixAPI.Models.Requests;

namespace TpixAPI.Services.Repositories
{
    public interface ITopicRepository
    {
        void AddTopic(TopicRequest topic);
        Task<bool> EditTopic(TopicRequest topic);
        //List<Post> GetAllPostsForTopicById(int topicId); //should be moved to posts repository
        Task<List<Topic>> GetAllTopicsForCategoryById(int id);
        Task<Topic> GetTopicById(int id);
        Task<Topic> RemoveTopicById(int id);
        bool Save();
    }
}
