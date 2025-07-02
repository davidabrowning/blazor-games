namespace BlazorGames.Models.Roygbiv
{
    public class DiscardPile
    {
        public Stack<Card> Cards { get; } = new();
        public Card? TopCard { get { return Cards.FirstOrDefault(); } }
    }
}
