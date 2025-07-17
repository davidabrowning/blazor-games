using BlazorGames.GameLogic.BattleWordle;
using BlazorGames.Models.BattleWordle;
using Xunit;

namespace BlazorGamesTests.BattleWordle
{
    public class GuessEvaluatorTests
    {
        [Fact]
        public void GuessIsCorrectIfWordsMatch()
        {
            GuessResult guessResult = GuessEvaluator.Evaluate("SWORD", "SWORD");
            Assert.True(guessResult.IsCorrect());
        }

        [Fact]
        public void GuessIsIncorrectIfWordsDontMatch()
        {
            GuessResult guessResult = GuessEvaluator.Evaluate("SWORD", "BLANK");
            Assert.False(guessResult.IsCorrect());
        }

        [Fact]
        public void FirstLetterIsCorrectLocationIfFirstLettersMatch()
        {
            GuessResult guessResult = GuessEvaluator.Evaluate("ALOHA", "ALIBI");
            Assert.Equal(LetterResult.CorrectLocation, guessResult.LetterResults[0]);
        }

        [Fact]
        public void FirstLetterIsIncorrectIfFirstIsntInWord()
        {
            GuessResult guessResult = GuessEvaluator.Evaluate("ALOHA", "BLURB");
            Assert.Equal(LetterResult.IncorrectLetter, guessResult.LetterResults[0]);
        }

        [Fact]
        public void FirstLetterIsIncorrectLocationIfInIncorrectLocation()
        {
            GuessResult guessResult = GuessEvaluator.Evaluate("SPARK", "BLUSH");
            Assert.Equal(LetterResult.IncorrectLocation, guessResult.LetterResults[0]);
        }

        [Fact]
        public void SecondIncorrectLocationIsMissingIfFirstInstanceOfLetterIsCorrect()
        {
            GuessResult guessResult = GuessEvaluator.Evaluate("ALOHA", "ALIBI");
            Assert.Equal(LetterResult.CorrectLocation, guessResult.LetterResults[0]);
            Assert.Equal(LetterResult.IncorrectLetter, guessResult.LetterResults[4]);
        }
    }
}
