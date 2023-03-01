using CrocodileGame.Domain.Models;
using System.Collections.Generic;

namespace CrocodileGame.Domain.Abstractions
{
    public interface ICardService
    {
        List<Card> GetCards();
        Card GetCardById(int cardId);
        void Add(int topicId, Card card);
        Card Update(int cardId, Card card);
        bool Delete(int topicId, int cardId);
    }
}
