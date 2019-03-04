﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpixAPI.Models;
using TpixAPI.Models.Requests;

namespace TpixAPI.Services
{
    public interface ITopicRepository
    {
        void AddTopic(TopicRequest topic);
        Task<bool> EditTopic(TopicRequest topic);
        //List<Post> GetAllPostsForTopicById(int topicId); //should be moved to posts repository
        List<Topic> GetAllTopicsForCategoryById(int id);
        Topic GetTopicById(int id);
        Task<Topic> RemoveTopicById(int id);
        bool Save();
    }
}