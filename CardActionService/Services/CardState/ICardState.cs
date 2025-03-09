using CardActionService.Models;

namespace CardActionService.Services.CardState
{
    public interface ICardState
    {
        List<CardAction> GetAllowedActions(CardDetails card);
    }
}
