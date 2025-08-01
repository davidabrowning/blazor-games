namespace BlazorGames.Models.BattleWordle
{
    public class GuessResult
    {
        public string GuessedWord { get; set; }
        public List<LetterResult> LetterResults { get; set; } = new();
        public bool HasBeenRevealedToPlayer { get; set; } = false;
        public GuessResult(string guessedWord)
        {
            GuessedWord = guessedWord;
            foreach (char letter in guessedWord)
            {
                LetterResults.Add(LetterResult.NotEvaluated);
            }
        }
        public bool IsCorrect()
        {
            return !LetterResults.Any(lr => lr != LetterResult.CorrectLocation);
        }
    }
}
