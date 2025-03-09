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

        public async Task<BaseResponse<CardAllowedActions>> GetCardDetails(CardRequest request)
        {
            try
            {
                var cardDetails = await _cardRepo.GetCardDetails(request.UserId, request.CardNumber);

                if (cardDetails == null)
                    return BaseResponse<CardAllowedActions>.ErrorResponse("Card details not found.");

                var card = new Card(cardDetails);

                var result = new CardAllowedActions
                {
                    CardNumber = cardDetails.CardNumber,
                    AllowedActions = card.GetAllowedActions()
                };

                return BaseResponse<CardAllowedActions>.SuccessResponse(result);
            }
            catch (Exception ex)
            {
                return BaseResponse<CardAllowedActions>.ErrorResponse("An error occurred while retrieving card details.");
            }
        }
    }
}
