using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrocodileGame.DataAccess.PostgreSQL.Entities
{
    public class CardTopic
    {
        [Key]
        public int Id { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}
