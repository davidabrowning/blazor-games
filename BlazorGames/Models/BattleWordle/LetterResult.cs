namespace BlazorGames.Models.BattleWordle
{
    public enum LetterResult
    {
        NotEvaluated = 0,
        CorrectLocation = 1,
        IncorrectLocation = 2,
        IncorrectLetter = 3,
    }
}
