using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TpixAPI.Data;
using TpixAPI.Models;
using TpixAPI.Models.Database;
using TpixAPI.Models.Requests;

namespace TpixAPI.Services.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly TpixContext _context;

        public TopicRepository(TpixContext context)
        {
            _context = context;
        }
        public void AddTopic(TopicRequest topic)
        {
            _context.Topic.Add(new Topic()
            {
                CreatedAt = DateTime.UtcNow,
                FkCreatedBy = topic.FkCreatedBy,
                FkCategoryId = topic.FkCategoryId,
                ImgUrl = topic.ImgUrl,
                MainBody = topic.MainBody,
                Title = topic.Title
            });
            _context.SaveChangesAsync();
        }

        public async Task<bool> EditTopic(TopicRequest topic)
        {
            var entity = await _context.Topic.FindAsync(topic.Id);
            if (entity != null)
            {
                entity.EditedAt = DateTime.UtcNow;
                entity.FkCategoryId = topic.FkCategoryId;
                entity.ImgUrl = topic.ImgUrl;
                entity.MainBody = topic.MainBody;
                entity.Title = topic.Title;
                var returnState = _context.Topic.Update(entity).State;
                _context.SaveChanges();
                
                return returnState == EntityState.Modified; //on success it returns true, else false
            }

            return false;
        }

        public async Task<List<Topic>> GetAllTopicsForCategoryById(int id)
        {
            var matchingTopics = _context.Category
                    .Where(c => c.Id == id)
                .SelectMany(category => category.Topic)
                .OrderBy(topic => topic.CreatedAt)
                .ToListAsync();
            return await matchingTopics;
        }
        public Task<Topic> GetTopicById(int id)
        {
            return _context.Topic.FindAsync(id);
        }
        public async Task<Topic> RemoveTopicById(int id)
        {
            var topic = await _context.Topic.FindAsync(id);
            if (topic == null)
            {
                return new Topic();
            }

            _context.Topic.Remove(topic);
            _context.SaveChanges(); //currently we can't delete topics if they have posts "beneath" them, need to sort this out properly first... perhaps extend
            //this method to delete all posts below it and then do this?

            return topic;

        }


        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
