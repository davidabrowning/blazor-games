namespace BlazorGames.Models.Roygbiv
{
    public class Deck
    {
        private List<Card> _cards = new();

        public int Count { get { return _cards.Count; } }

        public Deck()
        {
            for (int i = 1; i <= 60; i++)
            {
                _cards.Add(new Card(i));
            }
        }
    }
}
