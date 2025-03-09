using CardActionService.Models;
using CardActionService.Reposirories;

namespace CardActionService.Services
{
    public class CardService: ICardService
    {
        private readonly ICardActionRepository _cardRepo;
        public CardService(ICardActionRepository cardRepo) 
        {
            _cardRepo = cardRepo;
        }

        public async Task<CardAllowedActions?> GetCardDetails(string userId, string cardNumber)
        {
            try
            {
                var cardDetails = await _cardRepo.GetCardDetails(userId, cardNumber);

                if (cardDetails == null)
                    return null;

                var card = new Card(cardDetails);

                return new CardAllowedActions { CardNumber = cardDetails.CardNumber, AllowedActions = card.GetAllowedActions() };
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving card details.", ex);
            }
        }
    }
}
