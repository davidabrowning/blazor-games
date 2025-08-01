using BlazorGames.GameLogic.BattleWordle;
using Xunit;

namespace BlazorGamesTests.BattleWordle
{
    public class WordGeneratorTests
    {
        [Fact]
        public async Task GeneratedWordIsFiveLettersLong()
        {
            HttpClient httpClient = new();
            WordEvaluator wordEvaluator = new(httpClient);
            WordGenerator wordGenerator = new(httpClient, wordEvaluator);
            string word = await wordGenerator.Go();
            Assert.Equal(5, word.Length);
        }
    }
}
