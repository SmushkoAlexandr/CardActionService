using CardActionService.Models;

namespace CardActionService.Services.CardState
{
    public class DefaultCardState : ICardState
    {
        public List<CardAction> GetAllowedActions(CardDetails cardDetails)
        {
            return new List<CardAction>();
        }
    }
}
