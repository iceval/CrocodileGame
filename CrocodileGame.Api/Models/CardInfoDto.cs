using System.Collections.Generic;

namespace CrocodileGame.Api.Models
{
    public class CardInfoDto
    {
        public int Id { get; set; }
        public ICollection<TopicDto> Topics { get; set; }
        public string Word { get; set; }
    }
}
