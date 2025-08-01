namespace BlazorGames.Models.BattleWordle
{
    public enum GamePhase
    {
        NotStarted = 0,
        PlayerSelection = 1,
        WordSelection = 2,
        Guessing = 3,
        GameOver = 4,
    }
}
