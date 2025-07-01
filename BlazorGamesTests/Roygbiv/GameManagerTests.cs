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
            numCardsInPlay += gameManager._drawPile.Cards.Count;
            numCardsInPlay += gameManager._discardPile.Cards.Count;
            Assert.Equal(Deck.MaxSize, numCardsInPlay);
        }
    }
}
