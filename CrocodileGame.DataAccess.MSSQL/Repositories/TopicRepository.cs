using System;
using System.Collections.Generic;
using System.Linq;
using CrocodileGame.Domain.Models;
using CrocodileGame.Domain.Abstractions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace CrocodileGame.DataAccess.PostgreSQL.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly CrocodileGameContext _context;
        private readonly IMapper _mapper;

        public TopicRepository(CrocodileGameContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Topic> GetTopics()
        {
            var topicEntities = _context.Topics
                .Include(t => t.CardTopics)
                .ThenInclude(ct => ct.Card)
                .ToList();


            if (topicEntities == null)
                return null;

            //List<Topic> list = new List<Topic>();
            //foreach (var topicEntity in topicEntities)
            //{
            //    list.Add(new Topic
            //    {
            //        Id = topicEntity.Id,
            //        Name = topicEntity.Name,
            //        Cards = topicEntity.CardTopics.Select(ct => new Card { Id = ct.CardId, Word = ct.Card.Word }).ToList()
            //    });
            //}
            //return list;

            return topicEntities.Select(topicEntity => _mapper.Map<Topic>(topicEntity)).ToList();
        }

        public Topic GetTopicById(int topicId)
        {
            var topicEntities = _context.Topics
                .Include(t => t.CardTopics)
                .ThenInclude(ct => ct.Card)
                .ToList();

            if (topicEntities == null)
                return null; 

            Entities.Topic topicEntity = topicEntities.FirstOrDefault(x => x.Id == topicId);

            return _mapper.Map<Topic>(topicEntity);
        }

        public void Add(Topic topic)
        {
            var topicEntitiy = _context.Topics.FirstOrDefault(t => t.Name.Equals(topic.Name));

            if (topicEntitiy is not null)
                return;

                topicEntitiy = _mapper.Map<Entities.Topic>(topic);
                _context.Topics.Add(topicEntitiy);

            _context.SaveChanges();
        }

        public Topic Update(int topicId, Topic topic)
        {
            var topicEntitiy = _mapper.Map<Entities.Topic>(topic);
            topicEntitiy.Id = topicId;

            _context.Topics.Update(topicEntitiy);
            _context.SaveChanges();

            return topic;
        }


        public bool Delete(int topicId)
        {
            var topicEntitiy = _context.Topics.FirstOrDefault(t => t.Id == topicId);

            _context.Cards
                .Include(c => c.CardTopics)
                .Where(c => c.CardTopics.All(ct => ct.TopicId == topicId))
                .ToList()
                .ForEach(c => _context.Cards.Remove(c));


            _context.Topics.Remove(topicEntitiy);
            
            
            _context.SaveChanges();

            return true;
        }

    }
}
