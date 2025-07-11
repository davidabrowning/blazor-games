using BlazorGames.GameLogic.Roygbiv;
using BlazorGames.Models.Roygbiv;
using Xunit;


namespace BlazorGamesTests.Roygbiv
{
    public class UIManagerTests
    {
        private readonly UIManager _uiManager;

        public UIManagerTests()
        {
            _uiManager = new UIManager();
        }

        [Fact]
        public void RevealDrawPileRevealsAndSelectsDrawPile()
        {
            _uiManager.RevealDrawPile();
            Assert.True(_uiManager.DrawPileIsRevealed);
            Assert.True(_uiManager.DrawPileIsSelected);
        }

        [Fact]
        public void DiscardPileStartsNotSelected()
        {
            Assert.False(_uiManager.DiscardPileIsSelected);
        }

        [Fact]
        public void DiscardPileIsSelectedAfterBeingSelected()
        {
            _uiManager.SelectDiscardPile();
            Assert.True(_uiManager.DiscardPileIsSelected);
        }

        [Fact]
        public void DiscardPileIsNotSelectedAfterBeingSelectedIfDrawPileWasAlreadyRevealed()
        {
            _uiManager.RevealDrawPile();
            _uiManager.SelectDiscardPile();
            Assert.False(_uiManager.DiscardPileIsSelected);
        }
    }
}
