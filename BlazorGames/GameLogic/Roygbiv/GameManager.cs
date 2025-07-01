using BlazorGames.Models.Roygbiv;

namespace BlazorGames.GameLogic.Roygbiv
{
    public class GameManager
    {
        public const int MaxHandSize = 10;

        public Deck _deck { get; } = new();
        public DrawPile _drawPile { get; } = new();
        public DiscardPile _discardPile { get;  } = new();

        public List<Player> Players { get; } = new() { new Player("Player 1"), new Player("Player 2") };

        public void DealCards()
        {
            foreach (Player player in Players)
            {
                for (int i = 0; i < MaxHandSize; i++)
                {
                    if (player.Hand.Cards.Count >= MaxHandSize)
                    {
                        continue;
                    }
                    Card card = _deck.Draw();
                    player.Hand.Add(card);
                }
            }
            while (_deck.Count > 0)
            {
                Card card = _deck.Draw();
                _drawPile.Cards.Add(card);
            }
        }
        
    }
}
