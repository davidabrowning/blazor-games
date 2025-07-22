using BlazorGames.Models.BattleWordle;
using Xunit;

namespace BlazorGamesTests.BattleWordle
{
    public class GuessResultTests
    {
        [Fact]
        public void GuessResultHasIntendedNumberOfLetters()
        {
            GuessResult result = new("HAT");
            Assert.Equal(3, result.GuessedWord.Length);
        }

        [Fact]
        public void GuessResultIsCorrectIfAllLettersAreCorrect()
        {
            GuessResult guessResult = new("A");
            guessResult.LetterResults[0] = LetterResult.CorrectLocation;
            Assert.True(guessResult.IsCorrect());
        }

        [Fact]
        public void GuessResultIsIncorrectIfAllLettersIncorrect()
        {
            GuessResult guessResult = new("TO");
            guessResult.LetterResults[0] = LetterResult.IncorrectLetter;
            guessResult.LetterResults[1] = LetterResult.IncorrectLetter;
            Assert.False(guessResult.IsCorrect());
        }
    }
}
