using System.Collections.Generic;

namespace CrocodileGame.Api.Models
{
    public class TopicInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CardDto> Cards { get; set; }
    }
}
