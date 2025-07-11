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

        [Fact]
        public void ReplacingMiddleCardDoesNotChangeFirstCard()
        {
            Hand hand = new();
            Card c1 = new Card(1);
            Card c2 = new Card(2);
            Card c3 = new Card(3);
            Card c4 = new Card(4);
            hand.Cards.Add(c1);
            hand.Cards.Add(c2);
            hand.Cards.Add(c3);
            hand.Replace(c2, c4);
            Assert.Equal(c1, hand.Cards.First());
        }

        [Fact]
        public void ReplacingMiddleCardDoesNotChangeHandSize()
        {
            Hand hand = new();
            Card c1 = new Card(1);
            Card c2 = new Card(2);
            Card c3 = new Card(3);
            Card c4 = new Card(4);
            hand.Cards.Add(c1);
            hand.Cards.Add(c2);
            hand.Cards.Add(c3);

            int initialSize = hand.Cards.Count;
            hand.Replace(c2, c4);
            int finalSize = hand.Cards.Count;

            Assert.Equal(initialSize, finalSize);
        }

        [Fact]
        public void ReplacingMiddleCardChangesMiddleCardToNewValue()
        {
            Hand hand = new();
            Card c1 = new Card(1);
            Card c2 = new Card(2);
            Card c3 = new Card(3);
            Card c4 = new Card(4);
            hand.Cards.Add(c1);
            hand.Cards.Add(c2);
            hand.Cards.Add(c3);
            hand.Replace(c2, c4);
            Assert.Equal(c4, hand.Cards[1]);
        }

        [Fact]
        public void HandStartsWithHasSwappedAsFalse()
        {
            Hand hand = new();
            Assert.False(hand.HasSwapped);
        }

        [Fact]
        public void HandHasSwappedAsTrueAfterSwappingTwoCards()
        {
            Hand hand = new();
            Card c1 = new Card(1);
            Card c2 = new Card(2);
            hand.Swap(c1, c2);
        }

        [Fact]
        public void CardsChangePositionAfterSwap()
        {
            Hand hand = new();
            Card c1 = new Card(1);
            Card c2 = new Card(2);
            hand.Cards.Add(c1);
            hand.Cards.Add(c2);
            Assert.Equal(c1, hand.Cards[0]);
            Assert.Equal(c2, hand.Cards[1]);
            hand.Swap(c1, c2);
            Assert.Equal(c2, hand.Cards[0]);
            Assert.Equal(c1, hand.Cards[1]);
        }

        [Fact]
        public void SwapDoesNotChangeHandSize()
        {
            Hand hand = new();
            Card c1 = new Card(23);
            Card c2 = new Card(7);
            Card c3 = new Card(5);
            hand.Cards.Add(c1);
            hand.Cards.Add(c2);
            hand.Cards.Add(c3);
            int initialHandSize = hand.Cards.Count;
            hand.Swap(c1, c3);
            int finalHandSize = hand.Cards.Count;
            Assert.Equal(initialHandSize, finalHandSize);
        }
    }
}
