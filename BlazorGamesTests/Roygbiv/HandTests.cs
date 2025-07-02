using BlazorGames.Models.Roygbiv;
using Xunit;

namespace BlazorGamesTests.Roygbiv
{
    public class HandTests
    {
        [Fact]
        public void HandWith123IsSorted()
        {
            Hand hand = new();
            hand.Cards.Add(new Card(1));
            hand.Cards.Add(new Card(2));
            hand.Cards.Add(new Card(3));
            Assert.True(hand.IsSorted());
        }

        [Fact]
        public void HandWith321IsNotSorted()
        {
            Hand hand = new();
            hand.Cards.Add(new Card(3));
            hand.Cards.Add(new Card(2));
            hand.Cards.Add(new Card(1));
            Assert.False(hand.IsSorted());
        }
    }
}
