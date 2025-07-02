using BlazorGames.GameLogic.Roygbiv;
using BlazorGames.Models.Roygbiv;

namespace BlazorGames.Pages.Games
{
    public partial class Roygbiv
    {
        private readonly GameManager _gameManager;

        public IEnumerable<Player> Players { get { return _gameManager.Players; } }
        public Card? DrawPileTopCard { get { return _gameManager.DrawPile.TopCard; } }

        public Roygbiv(GameManager gameManager)
        {
            _gameManager = gameManager;
            _gameManager.AddPlayer("Player 1");
            _gameManager.AddPlayer("Player 2");
        }

        public void DealCards()
        {
            _gameManager.DealCards();
        }
    }
}
