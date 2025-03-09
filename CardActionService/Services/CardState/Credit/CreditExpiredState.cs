using CardActionService.Models;

namespace CardActionService.Services.CardState.Credit
{
    public class CreditExpiredState : ICardState
    {
        public List<CardAction> GetAllowedActions(CardDetails card)
        {
            var actions = new List<CardAction>
            {
                CardAction.ACTION3,
                CardAction.ACTION4,
                CardAction.ACTION5,
                CardAction.ACTION9
            };

            return actions;
        }
    }
}
