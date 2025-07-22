using BlazorGames.Models.BattleWordle;

namespace BlazorGames.GameLogic.BattleWordle
{
    public class GuessEvaluator
    {
        public static GuessResult Evaluate(string guess, string answer)
        {
            GuessResult guessResult = new(guess);

            CheckForCorrectLetters(guessResult, guess, answer);
            CheckForMissingLetters(guessResult, guess, answer);
            CheckForIncorrectLocations(guessResult, guess, answer);

            return guessResult;
        }

        private static void CheckForCorrectLetters(GuessResult guessResult, string guess, string answer)
        {
            for (int i = 0; i < guessResult.GuessedWord.Length; i++)
            {
                if (guess[i] == answer[i])
                {
                    guessResult.LetterResults[i] = LetterResult.CorrectLocation;
                }
            }
        }

        private static void CheckForMissingLetters(GuessResult guessResult, string guess, string answer)
        {
            for (int i = 0; i < guessResult.GuessedWord.Length; i++)
            {
                if (!answer.Contains(guess[i]))
                {
                    guessResult.LetterResults[i] = LetterResult.IncorrectLetter;
                }
            }
        }

        private static void CheckForIncorrectLocations(GuessResult guessResult, string guess, string answer)
        {
            for (int i = 0; i < guessResult.GuessedWord.Length; i++)
            {
                char guessedLetter = guess[i];
                int instancesOfThisLetterInAnswer = answer.Count(letter => letter == guessedLetter);
                int correctInstancesOfThisLetter = CalculateCorrectInstancesOfLetter(guessedLetter, guess, answer);
                int previousIncorrectInstancesOfThisLetter = CalculatePreviousIncorrectInstancesOfLetter(i, guessedLetter, guess, answer);

                if (guessedLetter == answer[i])
                {
                    continue;
                }

                if (!answer.Contains(guessedLetter)) {
                    continue;
                }

                if (instancesOfThisLetterInAnswer > correctInstancesOfThisLetter + previousIncorrectInstancesOfThisLetter)
                {
                    guessResult.LetterResults[i] = LetterResult.IncorrectLocation;
                }
                else
                {
                    guessResult.LetterResults[i] = LetterResult.IncorrectLetter;
                }
                
            }
        }

        private static int CalculateCorrectInstancesOfLetter(char letter, string guessedWord, string answerWord)
        {
            int correctInstancesOfLetter = 0;
            for (int i = 0; i < answerWord.Length; i++)
            {
                if (letter ==  answerWord[i] && guessedWord[i] == answerWord[i])
                {
                    correctInstancesOfLetter++;
                }
            }
            return correctInstancesOfLetter;
        }

        private static int CalculatePreviousIncorrectInstancesOfLetter(int index, char letter, string guessedWord, string answerWord)
        {
            int previousIncorrectInstancesOfLetter = 0;
            for (int i = 0; i < index; i++)
            {
                if (letter != answerWord[i] && letter == guessedWord[i])
                {
                    previousIncorrectInstancesOfLetter++;
                }
            }
            return previousIncorrectInstancesOfLetter;
        }
    }
}
