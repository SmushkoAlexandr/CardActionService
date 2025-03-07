using CardActionService.Services;

namespace CardActionService.Test
{
    [TestFixture]
    public class CardServiceTests
    {
        private CardService _cardService;

        [SetUp]
        public void Setup()
        {
            _cardService = new CardService();
        }

        [Test]
        public async Task GetCardDetails_ValidUserAndValidCardNumber_ReturnsCardDetails()
        {
            var userId = "User1";
            var cardNumber = "Card11";

            var result = await _cardService.GetCardDetails(userId, cardNumber);

            Assert.NotNull(result, "Expected card details to be returned for valid user and valid card number.");
            Assert.AreEqual(cardNumber, result.CardNumber, "Card numbers should match the input.");
        }
    }
}