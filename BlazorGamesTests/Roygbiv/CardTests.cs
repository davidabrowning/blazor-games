using BlazorGames.Models.Roygbiv;
using Xunit;

namespace BlazorGamesTests.Roygbiv
{
    public class CardTests
    {
        [Fact]
        public void EqualCardsAreEqual()
        {
            Card c1 = new Card(7);
            Card c2 = new Card(7);
            Assert.Equal(c1, c2);
        }

        [Fact]
        public void UnequalCardsAreNotEqual()
        {
            Card c1 = new Card(7);
            Card c2 = new Card(8);
            Assert.NotEqual(c1, c2);
        }

        [Fact]
        public void CardWithParameter33HasValue33()
        {
            Card c1 = new Card(33);
            Assert.Equal(33, c1.Value);
        }
    }
}
