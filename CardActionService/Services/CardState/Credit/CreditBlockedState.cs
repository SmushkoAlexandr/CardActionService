using CardActionService.Models;

namespace CardActionService.Services.CardState.Credit
{
    public class CreditBlockedState : ICardState
    {
        public List<CardAction> GetAllowedActions(CardDetails card)
        {
            var actions = new List<CardAction>
            {
                CardAction.ACTION3,
                CardAction.ACTION4,
                CardAction.ACTION5,
                CardAction.ACTION8,
                CardAction.ACTION9
            };

            if (card.IsPinSet)
            {
                actions.Add(CardAction.ACTION6);
                actions.Add(CardAction.ACTION7);
            }

            return actions;
        }
    }
}
