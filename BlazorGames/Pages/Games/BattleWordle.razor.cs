namespace BlazorGames.Pages.Games
{
    public partial class BattleWordle
    {
        public string AnswerWord { get; set; } = string.Empty;

        private void OnKeyboardLetterClicked(char letter)
        {
            AddLetterToAnswerWord(letter);
        }

        public void AddLetterToAnswerWord(char letter)
        {
            AnswerWord = $"{AnswerWord}{letter}";
        }
    }
}
