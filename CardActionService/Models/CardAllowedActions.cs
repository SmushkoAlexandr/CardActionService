using System.Text.Json.Serialization;

namespace CardActionService.Models
{
    public class CardAllowedActions
    {
        public required string CardNumber { get; set; }
        public required List<CardAction> AllowedActions { get; set; }
    }
}
