using Microsoft.AspNetCore.Mvc;

namespace CardActionService.Controllers;

[ApiController]
[Route("[controller]")]
public class CardActionController : ControllerBase
{
    private readonly ILogger<CardActionController> _logger;

    public CardActionController(ILogger<CardActionController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "actions")]
    public async Task<IActionResult> Get()
    {
    }
}
