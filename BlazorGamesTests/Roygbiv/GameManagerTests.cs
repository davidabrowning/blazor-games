using BlazorGames.GameLogic.Roygbiv;
using BlazorGames.Models.Roygbiv;
using Xunit;

namespace BlazorGamesTests.Roygbiv
{
    public class GameManagerTests
    {
        private readonly GameManager _gameManager;
        private readonly UIManager _uiManager;

        public GameManagerTests()
        {
            _uiManager = new();
            _gameManager = new(_uiManager);
        }

        private void CreateGame(int numPlayers)
        {
            for (int i = 0; i < numPlayers; i++)
            {
                _gameManager.AddPlayer("Player " + i);
            }
        }

        [Fact]
        public void PlayersHaveCorrectNumberOfCardsAfterOneDeal()
        {
            CreateGame(1);
            _gameManager.DealCards();
            Assert.Equal(GameManager.MaxHandSize, _gameManager.Players.First().Hand.Cards.Count);
        }

        [Fact]
        public void PlayersHaveCorrectNumberOfCardsEvenAfterMultipleDeals()
        {
            CreateGame(1);
            _gameManager.DealCards();
            _gameManager.DealCards();
            Assert.Equal(GameManager.MaxHandSize, _gameManager.Players.First().Hand.Cards.Count);
        }

        [Fact]
        public void HandCountsPlusDrawPileCountPlusDiscardPileCountEqualsDeckSize()
        {
            CreateGame(1);
            _gameManager.DealCards();
            int numCardsInPlay = 0;
            foreach (Player player in _gameManager.Players)
            {
                numCardsInPlay += player.Hand.Cards.Count;
            }
            numCardsInPlay += _gameManager.DrawPile.Cards.Count;
            numCardsInPlay += _gameManager.DiscardPile.Cards.Count;
            Assert.Equal(Deck.MaxSize, numCardsInPlay);
        }

        [Fact]
        public void IsGameStartedStartsAsFalse()
        {
            CreateGame(1);
            Assert.False(_gameManager.IsMatchStarted);
        }

        [Fact]
        public void IsGameStartedIsTrueAfterDealingCards()
        {
            CreateGame(1);
            _gameManager.DealCards();
            Assert.True(_gameManager.IsMatchStarted);
        }

        [Fact]
        public void IsGameOverIsFalseWhenPlayersHandsAreUnsorted()
        {
            CreateGame(1);
            Player p1 = _gameManager.Players.First();
            p1.Hand.Cards.Add(new Card(3));
            p1.Hand.Cards.Add(new Card(1));
            p1.Hand.Cards.Add(new Card(8));
            Assert.False(_gameManager.IsGameOver());
        }

        [Fact]
        public void IsGameOverIsTrueWhenPlayersHandIsSorted()
        {
            CreateGame(1);
            Player p1 = _gameManager.Players.First();
            p1.Hand.Cards.Add(new Card(1));
            p1.Hand.Cards.Add(new Card(3));
            p1.Hand.Cards.Add(new Card(8));
            Assert.True(_gameManager.IsGameOver());
        }

        [Fact]
        public void FirstPlayerDefaultsToPlayerOne()
        {
            CreateGame(3);
            Player p1 = _gameManager.Players.First();
            Assert.Equal(p1, _gameManager.ActivePlayer);
        }

        [Fact]
        public void TurnCounterIncrementsAfterHandClick()
        {
            CreateGame(1);
            _gameManager.DealCards();
            Player targetPlayer = _gameManager.Players.First();
            Card targetCard = targetPlayer.Hand.Cards.First();
            int initialTurnCounter = _gameManager.TurnCounter;
            _uiManager.RevealDrawPile();
            _gameManager.HandleHandCardClick(targetPlayer, targetCard);
            int finalTurnCounter = _gameManager.TurnCounter;
            Assert.Equal(initialTurnCounter + 1, finalTurnCounter);
        }
    }
}
