﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TpixAPI.Models;
using TpixAPI.Models.Requests;
using TpixAPI.Services;

namespace TpixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IMapper _mapper;
        public TopicController(ITopicRepository topicRepository, IMapper mapper)
        {
            _topicRepository = topicRepository;
            _mapper = mapper;
        }


        // GET api/topic/5
        [HttpGet("{id}")]
        public TopicRequest GetTopic([FromRoute]int id)
        {
            return _mapper.Map<TopicRequest>(_topicRepository.GetTopicById(id));
        }

        // GET: api/posts/GetPostsForTopic/{topicid}
        [HttpGet("GetTopicsForCategory/{categoryid}")]
        public ActionResult<IEnumerable<TopicRequest>> GetAllPostsForTopic([FromRoute]int categoryid)
        {
            return _mapper.Map<List<TopicRequest>>(_topicRepository.GetAllTopicsForCategoryById(categoryid));
        }

        //POST api/topic
        [HttpPost]
        public void PostTopic([FromBody]TopicRequest topic)
        {
            _topicRepository.AddTopic(topic);
            _topicRepository.Save();
        }

        //PUT api/topic
        [HttpPut]
        public Task<bool> EditTopic([FromBody]TopicRequest topic)
        {
            return _topicRepository.EditTopic(topic);
        }

        //Delete api/topic/5
        [HttpDelete("{id}")]
        public TopicRequest DeleteTopic([FromRoute]int id)
        {
            //returns deleted topic for confirmation message
            return _mapper.Map<TopicRequest>(_topicRepository.RemoveTopicById(id));
        }

    }
}