using CardActionService.Reposirories;

namespace CardActionService.Test
{
    [TestFixture]
    public class CardRepositoryTests
    {
        private CardActionRepository _cardRepo;

        [SetUp]
        public void Setup()
        {
            _cardRepo = new CardActionRepository();
        }

        [Test]
        public async Task GetCardDetails_ValidUserAndValidCardNumber_ReturnsCardDetails()
        {
            var userId = "User1";
            var cardNumber = "Card11";

            var result = await _cardRepo.GetCardDetails(userId, cardNumber);

            Assert.NotNull(result, "Expected card details to be returned for valid user and valid card number.");
            Assert.AreEqual(cardNumber, result.CardNumber, "Card numbers should match the input.");
        }

        [Test]
        public async Task GetCardDetails_InvalidUserAndInvalidCardNumber_ReturnsCardDetails()
        {
            var userId = "test";
            var cardNumber = "test";

            var result = await _cardRepo.GetCardDetails(userId, cardNumber);

            Assert.IsNull(result, "Expected null value.");
        }
    }
}