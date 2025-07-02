namespace BlazorGames.Models.Roygbiv
{
    public class Hand
    {
        public List<Card> Cards { get; } = new();

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
    }
}
