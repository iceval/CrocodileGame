using System.Collections.Generic;

namespace CrocodileGame.Domain.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Card> Cards { get; set; }
    }
}