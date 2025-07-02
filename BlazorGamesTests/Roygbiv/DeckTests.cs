using BlazorGames.Models.Roygbiv;
using Xunit;

namespace BlazorGamesTests.Roygbiv
{
    public class DeckTests
    {
        public DeckTests()
        {
            Deck deck = new();
            deck.Shuffle();
        }

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
            Assert.IsType<Card>(deck.DrawTopCard());
        }

        [Fact]
        public void NewDeckIsNotShuffled()
        {
            Deck unshuffledDeck = new();
            Card firstCard = unshuffledDeck.DrawTopCard();
            Card secondCard = unshuffledDeck.DrawTopCard();
            Assert.Equal(1, firstCard.Value);
            Assert.Equal(2, secondCard.Value);
        }

        [Fact]
        public void UnshuffledDecksAlwaysHaveFirstCardValueOfOne()
        {
            for (int i = 0; i < 100; i++)
            {
                Deck unshuffledDeck = new();
                Assert.Equal(1, unshuffledDeck.DrawTopCard().Value);
            }
        }

        [Fact]
        public void ShuffledDeckDoesNotAlwaysReturnFirstCardValueOfOne()
        {
            bool foundNonOneFirstValue = false;
            for (int i = 0; i < 100; i++)
            {
                Deck shuffledDeck = new();
                shuffledDeck.Shuffle();
                if (shuffledDeck.DrawTopCard().Value != 1)
                {
                    foundNonOneFirstValue = true;
                }
            }
            Assert.True(foundNonOneFirstValue);
        }
    }
}
