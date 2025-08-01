using BlazorGames.GameLogic.BattleWordle;
using Xunit;

namespace BlazorGamesTests.BattleWordle.IntegrationTests
{
    public class WordGeneratorAndEvaluatorTests
    {
        [Fact]
        public async Task GeneratedWordIsLegitimate()
        {
            HttpClient httpClient = new();
            WordEvaluator wordEvaluator = new(httpClient);
            WordGenerator wordGenerator = new(httpClient, wordEvaluator);
            string word = await wordGenerator.Go();
            bool isLegit = await wordEvaluator.Evaluate(word);
            Assert.True(isLegit);
        }
    }
}
