using BlazorGames.GameLogic.Roygbiv;
using BlazorGames.Models.Roygbiv;
using Xunit;

namespace BlazorGamesTests.Roygbiv.IntegrationTests
{
    public class GameManagerAndDrawPileIntegrationTests
    {
        [Fact]
        public void DrawPileCountNeverGoesToZero()
        {
            GameManager gameManager = new(new UIManager());

            gameManager.AddPlayers(1);
            gameManager.DealCards();

            Player player = gameManager.Players.First();

            player.Hand.Swap(player.Hand.Cards[0], player.Hand.Cards[1]);

            for (int i = 0; i < 500; i++)
            {
                gameManager.HandleDrawPileClick();
                gameManager.HandleHandCardClick(player, player.Hand.Cards.First());
            }
            Assert.True(gameManager.DrawPile.Cards.Count > 0);
        }
    }
}
