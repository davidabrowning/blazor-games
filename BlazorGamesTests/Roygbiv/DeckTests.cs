using BlazorGames.Models.Roygbiv;
using Xunit;

namespace BlazorGamesTests.Roygbiv
{
    public class DeckTests
    {
        [Fact]
        public void New_Deck_Has_60_Cards()
        {
            Deck d1 = new();
            Assert.Equal(60, d1.Count);
        }
    }
}
