namespace BlazorGames.Models.Roygbiv
{
    public class Deck
    {
        public const int MaxSize = 60;

        public List<Card> Cards { get; set; } = new();

        public int Count { get { return Cards.Count; } }

        public Deck()
        {
            for (int i = 1; i <= MaxSize; i++)
            {
                Cards.Add(new Card(i));
            }
        }

        public Card DrawTopCard()
        {
            Card drawnCard = Cards.First();
            Cards.Remove(drawnCard);
            return drawnCard;
        }

        public void Shuffle()
        {
            Cards = Cards.OrderBy(c => Guid.NewGuid()).ToList();
        }
    }
}
