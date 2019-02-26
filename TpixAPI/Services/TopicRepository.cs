using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpixAPI.Models;

namespace TpixAPI.Services
{
    public class TopicRepository : ITopicRepository
    {
        private TpixContext _context;

        public TopicRepository(TpixContext context)
        {
            _context = context;
        }
        public void AddTopic(Topic topic)
        {
            topic.DatePosted = DateTime.UtcNow;
            _context.Topic.Add(topic);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
