using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using CrocodileGame.Domain.Models;
using CrocodileGame.Domain.Abstractions;
using CrocodileGame.Api.ResourceModels;
using CrocodileGame.Api.Models;
using AutoMapper;

namespace CrocodileGame.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _topicService;
        private readonly IMapper _mapper;

        public TopicController(ITopicService topicService, IMapper mapper)
        {
            _topicService = topicService;
            _mapper = mapper;
        }

        [HttpGet("topics")]
        public ActionResult<List<TopicInfoDto>> GetTopics()
        {
            return _topicService.GetTopics().Select(t => _mapper.Map<TopicInfoDto>(t)).ToList();
        }

        [HttpGet("topics/{topicId:int}")]
        public ActionResult<TopicInfoDto> GetTopicById(int topicId)
        {
            return _mapper.Map<TopicInfoDto>(_topicService.GetTopicById(topicId));
        }

        [HttpPost("topics")]
        public ActionResult Add(TopicRequest addTopicRequest)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _topicService.Add(new Topic
                    {
                        Name = addTopicRequest.Name,
                    });

                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                
            }

            return BadRequest(ModelState);
        }

        [HttpPut("topics/{topicId:int}")]
        public ActionResult<Topic> Update(int topicId, TopicRequest updateTopicRequest)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _topicService.Update(topicId, new Topic
                    {
                        Name = updateTopicRequest.Name,
                    });

                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }

            return BadRequest(ModelState);
        }

        [HttpDelete("topics/{topicId:int}")]
        public ActionResult<bool> Delete(int topicId)
        {
            try
            {
                bool result = _topicService.Delete(topicId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
