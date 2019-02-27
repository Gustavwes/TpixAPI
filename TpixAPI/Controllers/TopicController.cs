using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TpixAPI.Models;
using TpixAPI.Services;

namespace TpixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicRepository _topicRepository;
        public TopicController(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }


        // GET api/topic/5
        [HttpGet("{id}")]
        public Topic GetTopic(int id)
        {
            return _topicRepository.GetTopicById(id);
        }

        //POST api/topic
        [HttpPost]
        public void PostTopic([FromBody]Topic topic)
        {
            _topicRepository.AddTopic(topic);
            _topicRepository.Save();
        }

        //PUT api/topic
        [HttpPut]
        public Task<bool> EditTopic(Topic topic)
        {
            return _topicRepository.EditTopic(topic);
        }

        //Delete api/topic/5
        [HttpDelete("{id}")]
        public Task<Topic> DeleteTopic(int id)
        {
            //returns deleted topic for confirmation message
            return _topicRepository.RemoveTopicById(id);
        }

    }
}