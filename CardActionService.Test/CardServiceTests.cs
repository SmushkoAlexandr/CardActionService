using CardActionService.Models;
using CardActionService.Reposirories;
using CardActionService.Services;
using Moq;

namespace CardActionService.Test
{
    [TestFixture]
    public class CardServiceTests
    {
        private CardService _cardService;
        private Mock<ICardActionRepository> _mockCardRepo;

        [SetUp]
        public void Setup()
        {
            _mockCardRepo = new Mock<ICardActionRepository>();
            _cardService = new CardService(_mockCardRepo.Object);
        }

        [Test]
        public async Task GetCardDetails_Prepaid_Closed_Actions()
        {
            var request = new CardRequest { UserId = "User1", CardNumber = "Card11" };
            _mockCardRepo
                .Setup(repo => repo.GetCardDetails(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(new CardDetails ("test", CardType.Prepaid, CardStatus.Closed, true));
            var result = await _cardService.GetCardDetails(request);

            var expectedActions = new List<CardAction> { CardAction.ACTION3, CardAction.ACTION4, CardAction.ACTION9 }; //order sensitive

            Assert.That(expectedActions, Is.EqualTo(result.Data.AllowedActions), "Card actions should match expected actions.");
        }

        [Test]
        public async Task GetCardDetails_Credit_Blocked_Actions()
        {
            var request = new CardRequest { UserId = "User1", CardNumber = "Card11" };
            _mockCardRepo
                .Setup(repo => repo.GetCardDetails(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(new CardDetails("test", CardType.Credit, CardStatus.Blocked, true));
            var result = await _cardService.GetCardDetails(request);

            var expectedActionsWithPin = new List<CardAction>  //order sensitive
            { 
                CardAction.ACTION3, 
                CardAction.ACTION4,
                CardAction.ACTION5,
                CardAction.ACTION8,
                CardAction.ACTION9,
                CardAction.ACTION6,
                CardAction.ACTION7
            };
            Assert.That(expectedActionsWithPin, Is.EqualTo(result.Data.AllowedActions), "Card actions should match expected actions.");


            _mockCardRepo
                .Setup(repo => repo.GetCardDetails(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(new CardDetails("test", CardType.Credit, CardStatus.Blocked, false));
            result = await _cardService.GetCardDetails(request);

            var expectedActionsWithoutPin = new List<CardAction> //order sensitive
            {
                CardAction.ACTION3,
                CardAction.ACTION4,
                CardAction.ACTION5,
                CardAction.ACTION8,
                CardAction.ACTION9
            };
            Assert.That(expectedActionsWithoutPin, Is.EqualTo(result.Data.AllowedActions), "Card actions should match expected actions.");
        }
    }
}
