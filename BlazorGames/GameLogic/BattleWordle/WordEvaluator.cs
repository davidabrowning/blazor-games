using System.Threading.Tasks;

namespace BlazorGames.GameLogic.BattleWordle
{
    public class WordEvaluator
    {
        private readonly HttpClient _httpClient;
        public WordEvaluator(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> Evaluate(string word)
        {
            try
            {
                string url = $"https://api.dictionaryapi.dev/api/v2/entries/en/{word.ToLower()}";
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
