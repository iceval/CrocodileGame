using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrocodileGame.Api.ResourceModels
{
    public class TopicRequest
    {
        [Required]
        public string Name { get; set; }

    }
}
