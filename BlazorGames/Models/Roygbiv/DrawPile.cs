namespace BlazorGames.Models.Roygbiv
{
    public class DrawPile
    {
        public List<Card> Cards { get; } = new();
        public Card? TopCard { get { return Cards.FirstOrDefault(); } }
    }
}
