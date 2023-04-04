using CrocodileGame.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrocodileGame.Domain.Abstractions
{
    public interface ITopicRepository
    {
        List<Topic> GetTopics();
        Topic GetTopicById(int topicId);
        void Add(Topic topic);
        Topic Update(int topicId, Topic topic);
        bool Delete(int topicId);
    }
}
