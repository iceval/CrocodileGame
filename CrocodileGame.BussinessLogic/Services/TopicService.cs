using CrocodileGame.Domain.Abstractions;
using CrocodileGame.Domain.Models;
using System;
using System.Collections.Generic;

namespace CrocodileGame.BussinessLogic.Services
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _topicRepository;

        public TopicService(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public List<Topic> GetTopics()
        {
            return _topicRepository.GetTopics();
        }

        public Topic GetTopicById(int topicId)
        {
            return _topicRepository.GetTopicById(topicId);
        }

        public void Add(Topic topic)
        {
            if (topic == null)
                throw new ArgumentNullException("Не задана карта, при добавлеии");

            _topicRepository.Add(topic);
        }

        public Topic Update(int topicId, Topic topic)
        {
            if (topic == null)
                throw new ArgumentNullException("Не задана карта, при изименении");

            return _topicRepository.Update(topicId, topic);
        }

        public bool Delete(int topicId)
        {
            return _topicRepository.Delete(topicId);
        }        
    }
}
