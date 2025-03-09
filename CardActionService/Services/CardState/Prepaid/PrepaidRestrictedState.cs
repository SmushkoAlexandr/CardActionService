using CardActionService.Models;

namespace CardActionService.Services.CardState.Prepaid
{
    public class PrepaidRestrictedState : ICardState
    {
        public List<CardAction> GetAllowedActions(CardDetails card)
        {
            var actions = new List<CardAction>
            {
                CardAction.ACTION3,
                CardAction.ACTION4,
                CardAction.ACTION9
            };

            return actions;
        }
    }
}
