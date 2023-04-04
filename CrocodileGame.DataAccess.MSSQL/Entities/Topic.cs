using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrocodileGame.DataAccess.PostgreSQL.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class Topic
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CardTopic> CardTopics { get; set; } = new List<CardTopic>();
    }
}
