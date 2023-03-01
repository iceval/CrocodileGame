using System.Collections.Generic;

namespace CrocodileGame.Domain.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public ICollection<Topic> Topics { get; set; }
    }
}
