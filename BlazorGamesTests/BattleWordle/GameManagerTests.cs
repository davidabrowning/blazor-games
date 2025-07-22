using BlazorGames.GameLogic.BattleWordle;
using BlazorGames.Models.BattleWordle;
using Xunit;

namespace BlazorGamesTests.BattleWordle
{
    public class GameManagerTests
    {
        private readonly GameManager _gameManager;
        public GameManagerTests()
        {
            HttpClient httpClient = new();
            WordEvaluator wordEvaluator = new(httpClient);
            _gameManager = new(wordEvaluator);
        }

        [Fact]
        public void GuessingHasStartedIsInitiallyFalse()
        {
            Assert.False(_gameManager.CurrentGamePhase == GamePhase.Guessing);
        }

        [Fact]
        public async Task GuessingHasStartedIsTrueAfterValidAnswerWordIsSubmitted()
        {
            _gameManager.AnswerWord = "START";
            await _gameManager.HandleSubmitClick();
            Assert.True(_gameManager.CurrentGamePhase == GamePhase.Guessing);
        }
    }
}
