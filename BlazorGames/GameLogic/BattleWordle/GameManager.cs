using BlazorGames.Models.BattleWordle;

namespace BlazorGames.GameLogic.BattleWordle
{
    public class GameManager
    {
        private readonly WordEvaluator _wordEvaluator;
        private readonly UIManager _uiManager;

        public readonly int MaxGuesses = 5;

        public string AnswerWord { get; set; } = string.Empty;
        public string GuessWord { get; set; } = string.Empty;
        public List<string> Guesses { get; private set; } = new();
        public GamePhase CurrentGamePhase { get; private set; } = GamePhase.WordSelection;

        public GameManager(WordEvaluator wordEvaluator)
        {
            _wordEvaluator = wordEvaluator;
        }

        public void HandleLetterClick(char letter)
        {
            if (CurrentGamePhase == GamePhase.WordSelection)
            {
                AddLetterToAnswerWord(letter);
            }

            if (CurrentGamePhase == GamePhase.Guessing)
            {
                AddLetterToGuessWord(letter);
            }
        }

        public void AddLetterToAnswerWord(char letter)
        {
            if (AnswerWord.Length == 5)
            {
                AnswerWord = AnswerWord.Substring(1);
            }
            AnswerWord = $"{AnswerWord}{letter}";
        }

        private void AddLetterToGuessWord(char letter)
        {
            if (GuessWord.Length == 5)
            {
                GuessWord = GuessWord.Substring(1);
            }
            GuessWord = $"{GuessWord}{letter}";
        }

        public async Task HandleSubmitClick()
        {
            if (CurrentGamePhase == GamePhase.WordSelection)
            {
                await HandleSubmitClickDuringWordSelectionPhase();
            }

            if (CurrentGamePhase == GamePhase.Guessing)
            {
                await HandleSubmitClickDuringGuessingPhase();
            }
        }

        private async Task HandleSubmitClickDuringWordSelectionPhase()
        {
            if (AnswerWord.Length != 5)
            {
                AnswerWord = string.Empty;
                return;
            }

            if (!await _wordEvaluator.Evaluate(AnswerWord))
            {
                AnswerWord = string.Empty;
                return;
            }

            CurrentGamePhase = GamePhase.Guessing;
        }

        private async Task HandleSubmitClickDuringGuessingPhase()
        {
            if (GuessWord.Length != 5)
            {
                GuessWord = string.Empty;
                return;
            }

            if (!await _wordEvaluator.Evaluate(GuessWord))
            {
                GuessWord = string.Empty;
                return;
            }

            Guesses.Add(GuessWord);
            GuessWord = string.Empty;

            if (Guesses.Last() == AnswerWord)
            {
                CurrentGamePhase = GamePhase.GameOver;
            }

            if (Guesses.Count == MaxGuesses)
            {
                CurrentGamePhase = GamePhase.GameOver;
            }
        }
    }
}
