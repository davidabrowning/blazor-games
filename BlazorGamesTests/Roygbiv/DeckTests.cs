using BlazorGames.Models.Roygbiv;
using Xunit;

namespace BlazorGamesTests.Roygbiv
{
    public class DeckTests
    {
        [Fact]
        public void NewDeckHas60Cards()
        {
            Deck deck = new();
            Assert.Equal(60, deck.Count);
        }

        [Fact]
        public void DrawReturnsOneCard()
        {
            Deck deck = new();
            Assert.IsType<Card>(deck.Draw());
        }
    }
}
