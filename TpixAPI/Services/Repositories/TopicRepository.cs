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

        public async Task<List<Topic>> GetAllTopicsForCategoryById(int categoryId)
        {
            var topicsWithMember = _context.Category.Where(x => x.Id == categoryId)
                .SelectMany(category => category.Topic)
                .Select(x => new Topic()
                {
                    Id = x.Id,
                    Title = x.Title,
                    ImgUrl = x.ImgUrl,
                    MainBody = x.MainBody,
                    CreatedAt = x.CreatedAt,
                    EditedAt = x.EditedAt, 
                    FkCategoryId = x.FkCategoryId,
                    FkCreatedBy = x.FkCreatedBy,
                    FkCreatedByNavigation = new Member()
                    {
                        Id = x.FkCreatedByNavigation.Id,
                        Username = x.FkCreatedByNavigation.Username,
                        Email = x.FkCreatedByNavigation.Email
                    }
                });
            return await topicsWithMember.ToListAsync();
            //var matchingTopics = _context.Category
            //        .Where(c => c.Id == categoryId)
            //    .SelectMany(category => category.Topic)
            //    .OrderBy(topic => topic.CreatedAt)
            //    .ToListAsync();
            //return await matchingTopics;
        }
        public Task<Topic> GetTopicById(int topicId)
        {
            var returnTopic = _context.Topic.Where(t => t.Id == topicId).Include(p => p.Post)
                .Include(m => m.FkCreatedByNavigation).Select(x => new Topic()
                {
                    Id = x.Id,
                    Title = x.Title,
                    ImgUrl = x.ImgUrl,
                    MainBody = x.MainBody,
                    CreatedAt = x.CreatedAt,
                    EditedAt = x.EditedAt,
                    FkCategoryId = x.FkCategoryId,
                    FkCreatedBy = x.FkCreatedBy,
                    Post = x.Post.Select(post => new Post()
                    {
                        CreatedAt = post.CreatedAt,
                        EditedAt = post.EditedAt,
                        Id = post.Id,
                        FkParentTopicId = post.FkParentTopicId,
                        FkCreatedBy = post.FkCreatedBy,
                        FkCreatedByNavigation = new Member()
                        {
                            Id = post.FkCreatedByNavigation.Id,
                            Username = post.FkCreatedByNavigation.Username,
                            Email = post.FkCreatedByNavigation.Email
                        },
                        MainBody = post.MainBody
                    }),
                    FkCreatedByNavigation = new Member()
                    {
                        Id = x.FkCreatedByNavigation.Id,
                        Username = x.FkCreatedByNavigation.Username,
                        Email = x.FkCreatedByNavigation.Email
                    }
                });
            return returnTopic.FirstAsync();
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
