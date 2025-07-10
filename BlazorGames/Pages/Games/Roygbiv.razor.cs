using BlazorGames.GameLogic.Roygbiv;
using BlazorGames.Models.Roygbiv;

namespace BlazorGames.Pages.Games
{
    public partial class Roygbiv
    {
        private readonly GameManager _gameManager;
        private readonly UIManager _uiManager;

        public bool ViewingInstructions { get; set; } = true;
        public IEnumerable<Player> Players { get { return _gameManager.Players; } }
        public Card? DrawPileTopCard { get { return _gameManager.DrawPile.TopCard; } }
        public Card? DiscardPileTopCard { get { return _gameManager.DiscardPile.TopCard; } }
        public bool GameInProgress { get { return _gameManager.IsGameInProgress; } }
        public bool InitialSwapsInProgress { get { return _gameManager.InitialSwapsInProgress; } }
        public bool DrawPileIsRevealed { get { return _uiManager.DrawPileIsRevealed; } }
        public bool DrawPileIsSelected { get { return _uiManager.DrawPileIsSelected; } }
        public bool DiscardPileIsSelected { get { return _uiManager.DiscardPileIsSelected; } }
        public Player ActivePlayer { get {  return _gameManager.ActivePlayer; } }
        public Card? ActiveSwapCard { get { return _gameManager.ActiveSwapCard; } }

        public Roygbiv(GameManager gameManager, UIManager uiManager)
        {
            _gameManager = gameManager;
            _uiManager = uiManager;
        }

        public void EndGame()
        {
            _gameManager.EndGame();
        }

        public void StartGame(int numPlayers)
        {
            _gameManager.StartGame(numPlayers);
        }

        public void RevealDrawPile()
        {
            _gameManager.HandleDrawPileClick();
        }

        public void SelectDiscardPile()
        {
            _gameManager.HandleDiscardPileClick();
        }

        public void HandleHandCardClick(Player player, Card card)
        {
            _gameManager.HandleHandCardClick(player, card);
        }

        public void ToggleInstructions()
        {
            ViewingInstructions = !ViewingInstructions;
        }
    }
}
