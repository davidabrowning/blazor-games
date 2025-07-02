using BlazorGames.GameLogic.Roygbiv;
using BlazorGames.Models.Roygbiv;
using Xunit;

namespace BlazorGamesTests.Roygbiv
{
    public class GameManagerTests
    {
        [Fact]
        public void PlayersHaveCorrectNumberOfCardsAfterOneDeal()
        {
            GameManager gameManager = new();
            gameManager.DealCards();
            Assert.Equal(GameManager.MaxHandSize, gameManager.Players.First().Hand.Cards.Count);
        }

        [Fact]
        public void PlayersHaveCorrectNumberOfCardsEvenAfterMultipleDeals()
        {
            GameManager gameManager = new();
            gameManager.DealCards();
            gameManager.DealCards();
            Assert.Equal(GameManager.MaxHandSize, gameManager.Players.First().Hand.Cards.Count);
        }

        [Fact]
        public void HandCountsPlusDrawPileCountPlusDiscardPileCountEqualsDeckSize()
        {
            GameManager gameManager = new();
            gameManager.DealCards();
            int numCardsInPlay = 0;
            foreach (Player player in gameManager.Players)
            {
                numCardsInPlay += player.Hand.Cards.Count;
            }
            numCardsInPlay += gameManager.DrawPile.Cards.Count;
            numCardsInPlay += gameManager.DiscardPile.Cards.Count;
            Assert.Equal(Deck.MaxSize, numCardsInPlay);
        }

        [Fact]
        public void IsGameStartedStartsAsFalse()
        {
            GameManager gameManager = new();
            Assert.False(gameManager.IsMatchStarted);
        }

        [Fact]
        public void IsGameStartedIsTrueAfterDealingCards()
        {
            GameManager gameManager = new();
            gameManager.DealCards();
            Assert.True(gameManager.IsMatchStarted);
        }
    }
}
