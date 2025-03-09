using CardActionService.Models;
using CardActionService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CardActionService.Controllers;

[ApiController]
[Route("api")]
public class CardActionController : ControllerBase
{
    private readonly ILogger<CardActionController> _logger;
    private readonly ICardService _cardService;


    public CardActionController(ILogger<CardActionController> logger, ICardService cardService)
    {
        _logger = logger;
        _cardService = cardService;
    }

    [HttpGet(Name = "GetCardAllowedActions")]
    public async Task<CardAllowedActions?> Get(string userId, string cardNumber)
    {
        return await _cardService.GetCardDetails(userId, cardNumber);
    }
}
