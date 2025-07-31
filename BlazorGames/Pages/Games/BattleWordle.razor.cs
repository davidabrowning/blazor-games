using BlazorGames.GameLogic.BattleWordle;
using BlazorGames.Models.BattleWordle;

namespace BlazorGames.Pages.Games
{
    public partial class BattleWordle
    {
        private readonly GameManager _gameManager;
        public int MaxGuesses { get { return _gameManager.MaxGuesses; } }
        public string AnswerWord { get { return _gameManager.AnswerWord; } }
        public string GuessWord { get { return _gameManager.GuessWord; } }
        public List<GuessResult> GuessResults { get { return _gameManager.GuessResults; } }
        public GamePhase CurrentGamePhase { get { return _gameManager.CurrentGamePhase; } }
        public bool ShowInstructions { get; set; } = true;

        public BattleWordle(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        private void OnKeyboardLetterClicked(char letter)
        {
            _gameManager.HandleLetterClick(letter);
        }

        private void HandleClearClick()
        {
            _gameManager.HandleClearClick();
        }

        private async Task HandleSubmitClick()
        {
            await _gameManager.HandleSubmitClick();
        }

        private void ToggleInstructions()
        {
            ShowInstructions = !ShowInstructions;
        }

        private void EndGame()
        {
            _gameManager.EndGame();
        }
    }
}
