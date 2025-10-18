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
                string baseUrl = "https://freedictionaryapi.com/api/v1/entries/en/";
                string fullUrl = baseUrl + word.ToLower();
                HttpResponseMessage response = await _httpClient.GetAsync(fullUrl);

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
