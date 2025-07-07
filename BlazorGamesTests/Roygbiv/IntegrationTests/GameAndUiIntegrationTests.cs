using BlazorGames.GameLogic.Roygbiv;
using BlazorGames.Models.Roygbiv;
using Xunit;

namespace BlazorGamesTests.Roygbiv.IntegrationTests
{
    public class GameAndUiIntegrationTests
    {

        [Fact]
        public void PilesAreUnselectedAfterHandlingHandClick()
        {
            UIManager uiManager = new();
            GameManager gameManager = new(uiManager);

            gameManager.AddPlayer("Player 1");

            gameManager.DealCards();
            uiManager.RevealDrawPile();
            Player targetPlayer = gameManager.Players.First();
            Card targetCard = targetPlayer.Hand.Cards.First();
            gameManager.HandleHandCardClick(targetPlayer, targetCard);
            Assert.False(uiManager.DrawPileIsSelected);
            Assert.False(uiManager.DiscardPileIsSelected);
        }
    }
}
