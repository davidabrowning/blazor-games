using BlazorGames.GameLogic.Roygbiv;
using BlazorGames.Models.Roygbiv;
using Xunit;

namespace BlazorGamesTests.Roygbiv
{
    public class GameManagerTests
    {
        private readonly GameManager _gameManagerSinglePlayer;
        private readonly GameManager _gameManagerThreePlayer;

        public GameManagerTests()
        {
            _gameManagerSinglePlayer = new GameManager();
            _gameManagerSinglePlayer.AddPlayer("Player 1");
            _gameManagerThreePlayer = new GameManager();
            _gameManagerThreePlayer.AddPlayer("Player 1");
            _gameManagerThreePlayer.AddPlayer("Player 2");
            _gameManagerThreePlayer.AddPlayer("Player 3");

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

        [Fact]
        public void RevealDrawPileRevealsAndSelectsDrawPile()
        {
            _gameManagerSinglePlayer.DealCards();
            _gameManagerSinglePlayer.RevealDrawPile();
            Assert.True(_gameManagerSinglePlayer.DrawPileIsRevealed);
            Assert.True(_gameManagerSinglePlayer.DrawPileIsSelected);
        }

        [Fact]
        public void FirstPlayerDefaultsToPlayerOne()
        {
            Player p1 = new Player("P1");
            Player p2 = new Player("P2");
            Player p3 = new Player("P3");
            GameManager gameManager = new();
            gameManager.Players.Add(p1);
            gameManager.Players.Add(p2);
            gameManager.Players.Add(p3);
            Assert.Equal(p1, gameManager.ActivePlayer);
        }
    }
}
