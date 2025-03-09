using CardActionService.Models;
using CardActionService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CardActionService.Controllers;

[ApiController]
[Route("api")]
public class CardActionController : ControllerBase
{
    private readonly ICardService _cardService;


    public CardActionController(ICardService cardService)
    {
        _cardService = cardService;
    }    

    [HttpGet(Name = "GetCardAllowedActions")]
    [ProducesResponseType(typeof(BaseResponse<CardAllowedActions>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<BaseResponse<CardAllowedActions>>> Get(CardRequest request) 
    {
        var response = await _cardService.GetCardDetails(request);

        if (!response.Success)
        {
            var errorResponse = new BaseResponse<CardAllowedActions>
            {
                Success = false,
                Message = response.Message,
                Data = null
            };

            if (response.Message == "Card details not found.")
                return NotFound(errorResponse);
            else
                return BadRequest(errorResponse);
        }

        return Ok(response);
    }
}
