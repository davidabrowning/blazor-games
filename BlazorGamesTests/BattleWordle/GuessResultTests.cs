using BlazorGames.Models.BattleWordle;
using Xunit;

namespace BlazorGamesTests.BattleWordle
{
    public class GuessResultTests
    {
        [Fact]
        public void GuessResultHasIntendedNumberOfLetters()
        {
            GuessResult result = new(3);
            Assert.Equal(3, result.WordLength);
        }

        [Fact]
        public void GuessResultIsCorrectIfAllLettersAreCorrect()
        {
            GuessResult guessResult = new(1);
            guessResult.LetterResults[0] = LetterResult.CorrectLocation;
            Assert.True(guessResult.IsCorrect());
        }

        [Fact]
        public void GuessResultIsIncorrectIfAllLettersIncorrect()
        {
            GuessResult guessResult = new(2);
            guessResult.LetterResults[0] = LetterResult.IncorrectLetter;
            guessResult.LetterResults[1] = LetterResult.IncorrectLetter;
            Assert.False(guessResult.IsCorrect());
        }
    }
}
