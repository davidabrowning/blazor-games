using BlazorGames.GameLogic.Roygbiv;
using BlazorGames.Models.Roygbiv;

namespace BlazorGames.Pages.Games
{
    public partial class Roygbiv
    {
        private readonly GameManager _gameManager;

        public IEnumerable<Player> Players { get { return _gameManager.Players; } }

        public Roygbiv(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public void DealCards()
        {
            _gameManager.DealCards();
        }
    }
}
