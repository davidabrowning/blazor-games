using BlazorGames.Models.Roygbiv;
using Xunit;

namespace BlazorGamesTests.Roygbiv
{
    public class CardTests
    {
        [Fact]
        public void Equal_Cards_Are_Equal()
        {
            Card c1 = new Card() { Value = 7 };
            Card c2 = new Card() { Value = 7 };
            Assert.Equal(c1, c2);
        }

        [Fact]
        public void Unequal_Cards_Are_Not_Equal()
        {
            Card c1 = new Card() { Value = 7 };
            Card c2 = new Card() { Value = 8 };
            Assert.NotEqual(c1, c2);
        }
    }
}
