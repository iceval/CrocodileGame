using CrocodileGame.Domain.Models;
using System.Collections.Generic;

namespace CrocodileGame.Domain.Abstractions
{
    public interface ITopicService
    {
        List<Topic> GetTopics();
        Topic GetTopicById(int topicId);
        void Add(Topic topic);
        Topic Update(int topicId, Topic topic);
        bool Delete(int topicId);
    }
}