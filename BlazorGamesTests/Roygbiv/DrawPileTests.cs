using BlazorGames.Models.Roygbiv;
using Xunit;

namespace BlazorGamesTests.Roygbiv
{
    public class DrawPileTests
    {
        private readonly DrawPile _drawPile;
        public DrawPileTests()
        {
            _drawPile = new();
            Deck deck = new Deck();
            deck.Shuffle();
            while (deck.Count > 0)
            {
                _drawPile.Cards.Add(deck.DrawTopCard());
            }
        }

        [Fact]
        public void DrawTopCardReducesDrawPileSizeByOne()
        {
            int initialSize = _drawPile.Cards.Count;
            _drawPile.DrawTopCard();
            int finalSize = _drawPile.Cards.Count;
            Assert.Equal(initialSize - 1, finalSize);
        }
    }
}
