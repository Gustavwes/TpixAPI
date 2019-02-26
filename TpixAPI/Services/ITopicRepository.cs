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
        bool Save();
    }
}
