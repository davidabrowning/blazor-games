using BlazorGames.Models.Roygbiv;
using Xunit;

namespace BlazorGamesTests.Roygbiv
{
    public class PlayerTests
    {
        [Fact]
        public void PlayerNameMatchesConstructorName()
        {
            Player p1 = new Player("John");
            Assert.Equal("John", p1.Name);
        }
    }
}
