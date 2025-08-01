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
        public int GuessResultRevealCountdownTicker = 0;
        public List<GuessResult> GuessResults { get; private set; } = new();
        public GamePhase CurrentGamePhase { get; private set; } = GamePhase.PlayerSelection;

        public GameManager(WordEvaluator wordEvaluator, UIManager uiManager)
        {
            _wordEvaluator = wordEvaluator;
            _uiManager = uiManager;
        }

        public void StartGame(int numPlayers)
        {
            if (numPlayers == 1)
            {
                AnswerWord = "SPORK";
                CurrentGamePhase = GamePhase.Guessing;
            }
            if (numPlayers == 2)
            {
                CurrentGamePhase = GamePhase.WordSelection;
            }
        }

        public void EndGame()
        {
            AnswerWord = string.Empty;
            GuessWord = string.Empty;
            GuessResults = new();
            CurrentGamePhase = GamePhase.PlayerSelection;
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

        public void HandleClearClick()
        {
            if (CurrentGamePhase == GamePhase.WordSelection)
            {
                AnswerWord = string.Empty;
            }

            if (CurrentGamePhase == GamePhase.Guessing)
            {
                GuessWord = string.Empty;
            }
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

            GuessResults.Add(GuessEvaluator.Evaluate(GuessWord, AnswerWord));

            GuessWord = string.Empty;

            if (GuessResults.Last().GuessedWord == AnswerWord)
            {
                CurrentGamePhase = GamePhase.GameOver;
            }

            if (GuessResults.Count == MaxGuesses)
            {
                CurrentGamePhase = GamePhase.GameOver;
            }
        }
    }
}
