using System.Threading.Tasks;

namespace BlazorGames.GameLogic.BattleWordle
{
    public class WordGenerator
    {
        private readonly HttpClient _httpClient;
        private readonly WordEvaluator _wordEvaluator;
        private List<string>? _wordList;
        public WordGenerator(HttpClient httpClient, WordEvaluator wordEvaluator)
        {
            _httpClient = httpClient;
            _wordEvaluator = wordEvaluator;
        }
        public async Task<string> Go()
        {
            if (_wordList == null)
            {
                _wordList = new();
                _wordList.Add("BLEND");
                _wordList.Add("PLANK");
                _wordList.Add("SPENT");
                _wordList.Add("ALOHA");
                _wordList.Add("SPORK");
                _wordList.Add("STINK");
                _wordList.Add("CHASE");
                _wordList.Add("PASTA");
                _wordList.Add("PASTE");
                _wordList.Add("TENET");
                _wordList.Add("ARGUE");
                _wordList.Add("EASES");
            }
            while (true)
            {
                Random random = new Random();
                int Index = random.Next(0, _wordList.Count);
                string word = _wordList[Index];
                if (await _wordEvaluator.Evaluate(word))
                {
                    return word;
                }
            }
        }
    }
}
