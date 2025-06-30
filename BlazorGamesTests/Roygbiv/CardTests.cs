using BlazorGames.Models.Roygbiv;
using Xunit;

namespace BlazorGamesTests.Roygbiv
{
    public class CardTests
    {
        [Fact]
        public void Equal_Cards_Are_Equal()
        {
            Card c1 = new Card(7);
            Card c2 = new Card(7);
            Assert.Equal(c1, c2);
        }

        [Fact]
        public void Unequal_Cards_Are_Not_Equal()
        {
            Card c1 = new Card(7);
            Card c2 = new Card(8);
            Assert.NotEqual(c1, c2);
        }

        [Fact]
        public void Card_With_Parameter_33_Has_Value_Of_33()
        {
            Card c1 = new Card(33);
            Assert.Equal(33, c1.Value);
        }
    }
}
