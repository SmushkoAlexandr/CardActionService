using CardActionService.Models;

namespace CardActionService.Services
{
    public interface ICardService
    {
        Task<BaseResponse<CardAllowedActions>> GetCardDetails(CardRequest request);
    }
}
