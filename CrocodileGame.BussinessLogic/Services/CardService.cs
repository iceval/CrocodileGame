using CrocodileGame.Domain.Abstractions;
using CrocodileGame.Domain.Models;
using System;
using System.Collections.Generic;

namespace CrocodileGame.BussinessLogic.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository)
        {   
            _cardRepository = cardRepository;
        }

        public List<Card> GetCards()
        {
            return _cardRepository.GetCards();
        }

        public Card GetCardById(int cardId)
        {
            return _cardRepository.GetCardById(cardId);
        }

        public void Add(int topicId, Card card)
        {
            if (card == null)
                throw new ArgumentNullException("Не задана карта, при добавлеии");

            _cardRepository.Add(topicId, card);
        }

        public Card Update(int cardId, Card card)
        {
            if (card == null)
                throw new ArgumentNullException("Не задана карта, при изименении");

            return _cardRepository.Update(cardId, card);
        }

        public bool Delete(int topicId, int cardId)
        {
            return _cardRepository.Delete(topicId, cardId);
        }        
    }
}
