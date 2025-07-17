using BlazorGames.Models.BattleWordle;

namespace BlazorGames.GameLogic.BattleWordle
{
    public class GuessEvaluator
    {
        public static GuessResult Evaluate(string guess, string answer)
        {
            GuessResult guessResult = new(answer.Length);

            CheckForCorrectLetters(guessResult, guess, answer);
            CheckForMissingLetters(guessResult, guess, answer);
            CheckForIncorrectLocations(guessResult, guess, answer);

            return guessResult;
        }

        private static void CheckForCorrectLetters(GuessResult guessResult, string guess, string answer)
        {
            for (int i = 0; i < guessResult.WordLength; i++)
            {
                if (guess[i] == answer[i])
                {
                    guessResult.LetterResults[i] = LetterResult.CorrectLocation;
                }
            }
        }

        private static void CheckForMissingLetters(GuessResult guessResult, string guess, string answer)
        {
            for (int i = 0; i < guessResult.WordLength; i++)
            {
                if (!answer.Contains(guess[i]))
                {
                    guessResult.LetterResults[i] = LetterResult.IncorrectLetter;
                }
            }
        }

        private static void CheckForIncorrectLocations(GuessResult guessResult, string guess, string answer)
        {
            for (int i = 0; i < guessResult.WordLength; i++)
            {
                char guessedLetter = guess[i];
                if (guessedLetter != answer[i] && answer.Contains(guessedLetter))
                {
                    guessResult.LetterResults[i] = LetterResult.IncorrectLocation;
                }
            }
        }
    }
}
