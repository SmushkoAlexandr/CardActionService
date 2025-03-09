using CardActionService.Services.CardState;

namespace CardActionService.Models
{
    public class Card
    {
        private CardDetails _details;
        private ICardState _state;

        public Card(CardDetails details)
        {
            _details = details;
            _state = CardStateFactory.CreateState(details);
        }

        public List<CardAction> GetAllowedActions()
        {
            return _state.GetAllowedActions(_details);
        }
    }
}
