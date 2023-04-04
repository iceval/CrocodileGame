using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using CrocodileGame.Domain.Models;
using CrocodileGame.Domain.Abstractions;
using CrocodileGame.Api.ResourceModels;
using CrocodileGame.Api.Models;
using AutoMapper;

namespace CrocodileGame.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;
        private readonly IMapper _mapper;

        public CardController(ICardService cardService, IMapper mapper)
        {
            _cardService = cardService;
            _mapper = mapper;
        }

        [HttpGet("cards")]
        public ActionResult<List<CardInfoDto>> GetCards()
        {
            return _cardService.GetCards().Select(c => _mapper.Map<CardInfoDto>(c)).ToList();
        }

        [HttpGet("cards/{cardId:int}")]
        public ActionResult<CardInfoDto> GetCardById(int cardId)
        {
            return _mapper.Map<CardInfoDto>(_cardService.GetCardById(cardId));
        }

        [HttpPost("topics/{topicId:int}/cards")]
        public IActionResult Add(int topicId, CardRequest addCardRequest)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _cardService.Add(topicId, new Card
                    {
                        Word = addCardRequest.Word,
                    });

                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                
            }

            return BadRequest(ModelState);
        }

        [HttpPut("cards/{cardId:int}")]
        public ActionResult<Card> Update(int cardId, CardRequest updateCardRequest)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var card = _cardService.Update(cardId, new Card
                    {
                        Word = updateCardRequest.Word,
                    });

                    return Ok(card);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }

            return BadRequest(ModelState);
        }

        [HttpDelete("topics/{topicId:int}/cards/{cardId:int}")]
        public ActionResult<bool> Delete(int topicId, int cardId)
        {
            try
            {
                bool result = _cardService.Delete(topicId, cardId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
