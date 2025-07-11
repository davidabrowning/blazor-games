namespace BlazorGames.Models.Roygbiv
{
    public class Hand
    {
        public List<Card> Cards { get; } = new();
        public bool HasSwapped { get; private set; } = false;

        public bool IsSorted()
        {
            int previousValue = Cards.First().Value;
            foreach (Card card in Cards)
            {
                if (card.Value < previousValue)
                {
                    return false;
                }
                previousValue = card.Value;
            }
            return true;
        }

        public void Replace(Card targetCard, Card newCard)
        {
            int index = Cards.IndexOf(targetCard);
            Cards[index] = newCard;
        }

        public void Swap(Card card1, Card card2)
        {
            if (!Cards.Contains(card1) || !Cards.Contains(card2))
            {
                return;
            }

            int card1Position = Cards.IndexOf(card1);
            int card2Position = Cards.IndexOf(card2);

            Cards[card1Position] = card2;
            Cards[card2Position] = card1;

            HasSwapped = true;
        }
    }
}
