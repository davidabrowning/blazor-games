using BlazorGames.GameLogic.BattleWordle;
using Xunit;

namespace BlazorGamesTests.BattleWordle
{
    public class WordEvaluatorTests
    {

        [Fact]
        public async Task StartIsAWord()
        {
            HttpClient httpClient = new();
            WordEvaluator wordEvaluator = new(httpClient);
            Assert.True(await wordEvaluator.Evaluate("START"));
        }

        [Fact]
        public async Task ABCDEIsNotAWord()
        {
            HttpClient httpClient = new();
            WordEvaluator wordEvaluator = new(httpClient);
            Assert.False(await wordEvaluator.Evaluate("ABCDE"));
        }
    }
}
