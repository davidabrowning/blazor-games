namespace BlazorGames.Models.BattleWordle
{
    public class GuessResult
    {
        public List<LetterResult> LetterResults { get; set; }
        public int WordLength { get {  return LetterResults.Count; } }
        public GuessResult(int numLetters)
        {
            LetterResults = new();
            for (int i = 0; i < numLetters; i++)
            {
                LetterResults.Add(LetterResult.NotEvaluated);
            }
        }
        public bool IsCorrect()
        {
            int numCorrectLetters = LetterResults.Count(lr => lr.Equals(LetterResult.CorrectLocation));
            return numCorrectLetters == WordLength;
        }
    }
}
