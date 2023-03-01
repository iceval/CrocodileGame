using System;
using System.Collections.Generic;
using System.Linq;
using CrocodileGame.Domain.Models;
using CrocodileGame.Domain.Abstractions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace CrocodileGame.DataAccess.PostgreSQL.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly CrocodileGameContext _context;
        private readonly IMapper _mapper;

        public CardRepository (CrocodileGameContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Card> GetCards()
        {
            var cardEntities = _context.Cards
                .Include(c => c.CardTopics)
                .ThenInclude(ct => ct.Topic)
                .ToList();
            

            if (cardEntities == null)
                return null;

            return cardEntities.Select(cardEntity => _mapper.Map<Card>(cardEntity)).ToList();
        }

        public Card GetCardById(int cardId)
        {
            var cardEntities = _context.Cards
                .Include(c => c.CardTopics)
                .ThenInclude(ct => ct.Topic)
                .ToList();

            if (cardEntities == null)
                return null;

            Entities.Card cardEntity = cardEntities.FirstOrDefault(x => x.Id == cardId);

            return _mapper.Map<Card>(cardEntity);
        }

        public void Add(int topicId, Card card)
        {
            var cardEntity = _context.Cards.FirstOrDefault(c => c.Word.Equals(card.Word));

            if (cardEntity is null) 
            {
                cardEntity = _mapper.Map<Entities.Card>(card);
                _context.Cards.Add(cardEntity);
            }

            var cardTopic = _context.CardTopics.FirstOrDefault(ct => ct.Card.Id == cardEntity.Id && ct.TopicId == topicId);

            if (cardTopic is null) 
            {
                cardTopic = new Entities.CardTopic
                {
                    CardId = cardEntity.Id,
                    Card = cardEntity,
                    TopicId = topicId,
                    Topic = _context.Topics.FirstOrDefault(x => x.Id == topicId)
                };

                _context.CardTopics.Add(cardTopic);
            }

            _context.SaveChanges();
        }

        public Card Update(int cardId, Card card)
        {
            var cardEntity = _mapper.Map<Entities.Card>(card);
            cardEntity.Id = cardId;

            _context.Cards.Update(cardEntity);
            _context.SaveChanges();

            return card;
        }


        public bool Delete(int topicId, int cardId)
        {
            var cardTopics = _context.CardTopics.Where(ct => ct.CardId == cardId).ToList();
            var cardTopic = cardTopics.FirstOrDefault(ct => (ct.TopicId == topicId));

            _context.CardTopics.Remove(cardTopic);
            cardTopics.Remove(cardTopic);

            if (!cardTopics.Any()) 
            {
                var card = _context.Cards.FirstOrDefault(c => c.Id == cardId);
                _context.Cards.Remove(card);
            }

            _context.SaveChanges();

            return true;
        }
    }
}
