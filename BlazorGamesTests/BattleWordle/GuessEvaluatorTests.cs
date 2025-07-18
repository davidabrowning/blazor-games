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
        public void FirstCorrectLocationIsCorrectEvenIfLetterGuessedTwice()
        {
            GuessResult guessResult = GuessEvaluator.Evaluate("ALOHA", "ALIBI");
            Assert.Equal(LetterResult.CorrectLocation, guessResult.LetterResults[0]);
        }

        [Fact]
        public void CorrectLocationIsCorrectEvenIfLetterGuessedTwiceAndIncorrectGuessComesFirst()
        {
            GuessResult guessResult = GuessEvaluator.Evaluate("ALOHA", "FLORA");
            Assert.Equal(LetterResult.CorrectLocation, guessResult.LetterResults[4]);
        }

        [Fact]
        public void IncorrectLocationIsMissingIfFirstInstanceOfLetterIsCorrect()
        {
            GuessResult guessResult = GuessEvaluator.Evaluate("ALOHA", "ALIBI");
            Assert.Equal(LetterResult.IncorrectLetter, guessResult.LetterResults[4]);
        }

        [Fact]
        public void FirstIncorrectLocationIsIncorrectIfOnlyOneInstanceOfLetterInAnswer()
        {
            GuessResult guessResult = GuessEvaluator.Evaluate("ALOHA", "START");
            Assert.Equal(LetterResult.IncorrectLocation, guessResult.LetterResults[0]);
        }

        [Fact]
        public void SecondIncorrectLocationIsMissingIfOnlyOneInstanceOfLetterInAnswer()
        {
            GuessResult guessResult = GuessEvaluator.Evaluate("ALOHA", "START");
            Assert.Equal(LetterResult.IncorrectLetter, guessResult.LetterResults[4]);
        }

        [Fact]
        public void CorrectlyEvaluateAlohaAgainstStart()
        {
            GuessResult guessResult = GuessEvaluator.Evaluate("ALOHA", "START");
            Assert.Equal(LetterResult.IncorrectLocation, guessResult.LetterResults[0]);
            Assert.Equal(LetterResult.IncorrectLetter, guessResult.LetterResults[1]);
            Assert.Equal(LetterResult.IncorrectLetter, guessResult.LetterResults[2]);
            Assert.Equal(LetterResult.IncorrectLetter, guessResult.LetterResults[3]);
            Assert.Equal(LetterResult.IncorrectLetter, guessResult.LetterResults[4]);
        }

        [Fact]
        public void CorrectlyEvaluateStartAgainstPetty()
        {
            GuessResult guessResult = GuessEvaluator.Evaluate("START", "PETTY");
            Assert.Equal(LetterResult.IncorrectLetter, guessResult.LetterResults[0]);
            Assert.Equal(LetterResult.IncorrectLocation, guessResult.LetterResults[1]);
            Assert.Equal(LetterResult.IncorrectLetter, guessResult.LetterResults[2]);
            Assert.Equal(LetterResult.IncorrectLetter, guessResult.LetterResults[3]);
            Assert.Equal(LetterResult.IncorrectLocation, guessResult.LetterResults[4]);
        }

        [Fact]
        public void CorrectlyEvaluateStartAgainstRusty()
        {
            GuessResult guessResult = GuessEvaluator.Evaluate("START", "RUSTY");
            Assert.Equal(LetterResult.IncorrectLocation, guessResult.LetterResults[0]);
            Assert.Equal(LetterResult.IncorrectLocation, guessResult.LetterResults[1]);
            Assert.Equal(LetterResult.IncorrectLetter, guessResult.LetterResults[2]);
            Assert.Equal(LetterResult.IncorrectLocation, guessResult.LetterResults[3]);
            Assert.Equal(LetterResult.IncorrectLetter, guessResult.LetterResults[4]);
        }

        [Fact]
        public void CorrectlyEvaluateStartAgainstStart()
        {
            GuessResult guessResult = GuessEvaluator.Evaluate("START", "START");
            Assert.Equal(LetterResult.CorrectLocation, guessResult.LetterResults[0]);
            Assert.Equal(LetterResult.CorrectLocation, guessResult.LetterResults[1]);
            Assert.Equal(LetterResult.CorrectLocation, guessResult.LetterResults[2]);
            Assert.Equal(LetterResult.CorrectLocation, guessResult.LetterResults[3]);
            Assert.Equal(LetterResult.CorrectLocation, guessResult.LetterResults[4]);
        }
    }
}
