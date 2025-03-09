using CardActionService.Models;

namespace CardActionService.Reposirories
{
    public interface ICardActionRepository
    {
        Task<CardDetails?> GetCardDetails(string userId, string cardNumber);
    }
}
