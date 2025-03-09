using CardActionService.Models;
using CardActionService.Services.CardState.Credit;
using CardActionService.Services.CardState.Debit;
using CardActionService.Services.CardState.Prepaid;

namespace CardActionService.Services.CardState
{
    public class CardStateFactory
    {
        #region State and Status mappings
        private static readonly Dictionary<CardStatus, ICardState> CreditStates =
            new Dictionary<CardStatus, ICardState>
            {
                { CardStatus.Blocked,    new CreditBlockedState() },
                { CardStatus.Closed,     new CreditClosedState() },
                { CardStatus.Active,     new CreditActiveState() },
                { CardStatus.Expired,    new CreditExpiredState() },
                { CardStatus.Inactive,   new CreditInactiveState() },
                { CardStatus.Ordered,    new CreditOrderedState() },
                { CardStatus.Restricted, new CreditRestrictedState() }
            };

        private static readonly Dictionary<CardStatus, ICardState> PrepaidStates =
            new Dictionary<CardStatus, ICardState>
            {
                { CardStatus.Blocked,    new PrepaidBlockedState() },
                { CardStatus.Closed,     new PrepaidClosedState() },
                { CardStatus.Active,     new PrepaidActiveState() },
                { CardStatus.Expired,    new PrepaidExpiredState() },
                { CardStatus.Inactive,   new PrepaidInactiveState() },
                { CardStatus.Ordered,    new PrepaidOrderedState() },
                { CardStatus.Restricted, new PrepaidRestrictedState() }
            };

        private static readonly Dictionary<CardStatus, ICardState> DebitStates =
            new Dictionary<CardStatus, ICardState>
            {
                { CardStatus.Blocked,    new DebitBlockedState() },
                { CardStatus.Closed,     new DebitClosedState() },
                { CardStatus.Active,     new DebitActiveState() },
                { CardStatus.Expired,    new DebitExpiredState() },
                { CardStatus.Inactive,   new DebitInactiveState() },
                { CardStatus.Ordered,    new DebitOrderedState() },
                { CardStatus.Restricted, new DebitRestrictedState() }
            };

        private static readonly Dictionary<CardType, Dictionary<CardStatus, ICardState>> CardTypeMappings =
            new Dictionary<CardType, Dictionary<CardStatus, ICardState>>
            {
                { CardType.Credit,  CreditStates },
                { CardType.Prepaid, PrepaidStates },
                { CardType.Debit,   DebitStates }
            };
        #endregion

        public static ICardState CreateState(CardDetails cardDetails)
        {
            if (CardTypeMappings.TryGetValue(cardDetails.CardType, out var statusMap))
            {
                if (statusMap.TryGetValue(cardDetails.CardStatus, out var cardState))                
                    return cardState;                
            }
            return new DefaultCardState();
        }
    }
}
