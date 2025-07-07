using BlazorGames.GameLogic.Roygbiv;
using BlazorGames.Models.Roygbiv;

namespace BlazorGames.Pages.Games
{
    public partial class Roygbiv
    {
        private readonly GameManager _gameManager;
        private readonly UIManager _uiManager;

        public IEnumerable<Player> Players { get { return _gameManager.Players; } }
        public Card? DrawPileTopCard { get { return _gameManager.DrawPile.TopCard; } }
        public Card? DiscardPileTopCard { get { return _gameManager.DiscardPile.TopCard; } }
        public bool GameInProgress { get { return _gameManager.IsGameInProgress; } }
        public bool DrawPileIsRevealed { get { return _uiManager.DrawPileIsRevealed; } }
        public bool DrawPileIsSelected { get { return _uiManager.DrawPileIsSelected; } }
        public bool DiscardPileIsSelected { get { return _uiManager.DiscardPileIsSelected; } }
        public Player ActivePlayer { get {  return _gameManager.ActivePlayer; } }

        public Roygbiv(GameManager gameManager, UIManager uiManager)
        {
            _gameManager = gameManager;
            _gameManager.AddPlayer("Player 1");
            _gameManager.AddPlayer("Player 2");

            _uiManager = uiManager;
        }

        public void DealCards()
        {
            _gameManager.DealCards();
        }

        public void RevealDrawPile()
        {
            _uiManager.RevealDrawPile();
        }

        public void SelectDiscardPile()
        {
            _uiManager.SelectDiscardPile();
        }

        public void HandleHandCardClick(Player player, Card card)
        {
            _gameManager.HandleHandCardClick(player, card);
        }
    }
}
