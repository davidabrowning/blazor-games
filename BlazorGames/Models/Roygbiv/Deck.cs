namespace BlazorGames.Models.Roygbiv
{
    public class Deck
    {
        public const int MaxSize = 60;

        private List<Card> _cards = new();

        public int Count { get { return _cards.Count; } }

        public Deck()
        {
            for (int i = 1; i <= MaxSize; i++)
            {
                _cards.Add(new Card(i));
            }
        }

        public Card DrawTopCard()
        {
            Card drawnCard = _cards.First();
            _cards.Remove(drawnCard);
            return drawnCard;
        }

        public void Shuffle()
        {
            _cards = _cards.OrderBy(c => Guid.NewGuid()).ToList();
        }
    }
}
