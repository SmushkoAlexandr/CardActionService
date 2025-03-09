using CardActionService.Models;

namespace CardActionService.Services.CardState.Prepaid
{
    public class PrepaidInactiveState : ICardState
    {
        public List<CardAction> GetAllowedActions(CardDetails card)
        {
            var actions = new List<CardAction>
            {
                CardAction.ACTION2,
                CardAction.ACTION3,
                CardAction.ACTION4,
                CardAction.ACTION8,
                CardAction.ACTION9,
                CardAction.ACTION10,
                CardAction.ACTION11,
                CardAction.ACTION12,
                CardAction.ACTION13
            };

            if (card.IsPinSet)
                actions.Add(CardAction.ACTION6);
            else
                actions.Add(CardAction.ACTION7);

            return actions;
        }
    }
}
