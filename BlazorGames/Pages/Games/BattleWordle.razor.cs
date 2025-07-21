using BlazorGames.GameLogic.BattleWordle;

namespace BlazorGames.Pages.Games
{
    public partial class BattleWordle
    {
        private readonly WordEvaluator _wordEvaluator;
        public string AnswerWord { get; set; } = string.Empty;

        public BattleWordle(WordEvaluator wordEvaluator)
        {
               _wordEvaluator = wordEvaluator;
        }

        private void OnKeyboardLetterClicked(char letter)
        {
            AddLetterToAnswerWord(letter);
        }

        private void AddLetterToAnswerWord(char letter)
        {
            if (AnswerWord.Length == 5)
            {
                AnswerWord = AnswerWord.Substring(1);
            }
            AnswerWord = $"{AnswerWord}{letter}";
        }

        private async Task TryStartGame()
        {
            if (await _wordEvaluator.Evaluate(AnswerWord))
            {
                
            }
            else
            {
                AnswerWord = string.Empty;
            }
        }
    }
}
