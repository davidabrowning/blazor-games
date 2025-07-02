using BlazorGames.GameLogic.Roygbiv;
using BlazorGames.Models.Roygbiv;
using Xunit;

namespace BlazorGamesTests.Roygbiv
{
    public class GameManagerTests
    {
        private readonly GameManager _gameManagerSinglePlayer;

        public GameManagerTests()
        {
            _gameManagerSinglePlayer = new GameManager();
            _gameManagerSinglePlayer.AddPlayer("Player 1");
        }

        [Fact]
        public void PlayersHaveCorrectNumberOfCardsAfterOneDeal()
        {
            _gameManagerSinglePlayer.DealCards();
            Assert.Equal(GameManager.MaxHandSize, _gameManagerSinglePlayer.Players.First().Hand.Cards.Count);
        }

        [Fact]
        public void PlayersHaveCorrectNumberOfCardsEvenAfterMultipleDeals()
        {
            _gameManagerSinglePlayer.DealCards();
            _gameManagerSinglePlayer.DealCards();
            Assert.Equal(GameManager.MaxHandSize, _gameManagerSinglePlayer.Players.First().Hand.Cards.Count);
        }

        [Fact]
        public void HandCountsPlusDrawPileCountPlusDiscardPileCountEqualsDeckSize()
        {
            _gameManagerSinglePlayer.DealCards();
            int numCardsInPlay = 0;
            foreach (Player player in _gameManagerSinglePlayer.Players)
            {
                numCardsInPlay += player.Hand.Cards.Count;
            }
            numCardsInPlay += _gameManagerSinglePlayer.DrawPile.Cards.Count;
            numCardsInPlay += _gameManagerSinglePlayer.DiscardPile.Cards.Count;
            Assert.Equal(Deck.MaxSize, numCardsInPlay);
        }

        [Fact]
        public void IsGameStartedStartsAsFalse()
        {
            Assert.False(_gameManagerSinglePlayer.IsMatchStarted);
        }

        [Fact]
        public void IsGameStartedIsTrueAfterDealingCards()
        {
            _gameManagerSinglePlayer.DealCards();
            Assert.True(_gameManagerSinglePlayer.IsMatchStarted);
        }

        [Fact]
        public void IsGameOverIsFalseWhenPlayersHandsAreUnsorted()
        {
            Player p1 = _gameManagerSinglePlayer.Players.First();
            p1.Hand.Cards.Add(new Card(3));
            p1.Hand.Cards.Add(new Card(1));
            p1.Hand.Cards.Add(new Card(8));
            Assert.False(_gameManagerSinglePlayer.IsGameOver());
        }

        [Fact]
        public void IsGameOverIsTrueWhenPlayersHandIsSorted()
        {
            Player p1 = _gameManagerSinglePlayer.Players.First();
            p1.Hand.Cards.Add(new Card(1));
            p1.Hand.Cards.Add(new Card(3));
            p1.Hand.Cards.Add(new Card(8));
            Assert.True(_gameManagerSinglePlayer.IsGameOver());
        }
    }
}
