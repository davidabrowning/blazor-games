namespace BlazorGames.Models.Roygbiv
{
    public class Hand
    {
        private List<Card> _cards = new();

        public void Add(Card card)
        {
            _cards.Add(card);
        }

        public bool IsSorted()
        {
            int previousValue = _cards.First().Value;
            foreach (Card card in _cards)
            {
                if (card.Value < previousValue)
                {
                    return false;
                }
                previousValue = card.Value;
            }
            return true;
        }
    }
}
