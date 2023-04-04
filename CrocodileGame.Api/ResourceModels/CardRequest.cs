using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrocodileGame.Api.ResourceModels
{
    public class CardRequest
    {
        [Required]
        public string Word { get; set; }

    }
}
