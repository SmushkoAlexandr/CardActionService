using CardActionService.Models;

namespace CardActionService.Services
{
    public interface ICardService
    {
        Task<CardAllowedActions?> GetCardDetails(string userId, string cardNumber);
    }
}
