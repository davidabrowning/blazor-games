using BlazorGames.Models.Roygbiv;
using Xunit;

namespace BlazorGamesTests.Roygbiv
{
    public class HandTests
    {
        [Fact]
        public void Hand_With_123_Is_Sorted()
        {
            Hand hand = new();
            hand.Add(new Card(1));
            hand.Add(new Card(2));
            hand.Add(new Card(3));
            Assert.True(hand.IsSorted());
        }

        [Fact]
        public void Hand_With_321_Is_Not_Sorted()
        {
            Hand hand = new();
            hand.Add(new Card(3));
            hand.Add(new Card(2));
            hand.Add(new Card(1));
            Assert.False(hand.IsSorted());
        }
    }
}
