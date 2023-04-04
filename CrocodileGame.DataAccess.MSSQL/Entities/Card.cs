using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CrocodileGame.DataAccess.PostgreSQL.Entities
{
    [Index(nameof(Word), IsUnique = true)]
    public class Card
    {
        [Key]
        public int Id { get; set; }
        public string Word { get; set; }
        public List<CardTopic> CardTopics { get; set; } = new List<CardTopic>();
    }
}
