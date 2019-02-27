﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TpixAPI.Models;

namespace TpixAPI.Services
{
    public class TopicRepository : ITopicRepository
    {
        private readonly TpixContext _context;

        public TopicRepository(TpixContext context)
        {
            _context = context;
        }
        public void AddTopic(Topic topic)
        {
            topic.DatePosted = DateTime.UtcNow;
            _context.Topic.Add(topic);
            _context.SaveChanges();
        }

        //public List<Post> GetAllPostsForTopicById(int topicId)
        //{
        //    return _context.Topic.Where(x => x.Id == topicId)
        //        .SelectMany(topic => topic.Post)
        //        .OrderBy(post => post.DatePosted)
        //        .ToList();
        //}

        public Topic GetTopicById(int id)
        {
            return _context.Topic.Find(id);
        }
        public async Task<Topic> RemoveTopicById(int id)
        {
            var topic = await _context.Topic.FindAsync(id);
            if (topic == null)
            {
                return new Topic();
            }

            _context.Topic.Remove(topic);
            await _context.SaveChangesAsync();

            return topic;

        }

        public async Task<bool> EditTopic(Topic topic)
        {
            var entity = await _context.Topic.FindAsync(topic.Id);
            if (entity != null)
            {
                entity.ImageUrl = topic.ImageUrl;
                entity.Title = topic.Title;
                entity.CategoryId = topic.CategoryId;
                _context.Topic.Update(topic);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public List<Topic> GetAllTopicsForCategoryById(int id)
        {
            var matchingTopics = _context.Category
                    .Where(c => c.Id == id)
                .SelectMany(category => category.Topic)
                .OrderBy(topic => topic.DatePosted)
                .ToList();
            return matchingTopics;
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
