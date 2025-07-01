namespace BlazorGames.Models.Roygbiv
{
    public class Player
    {
        public string Name { get; private set; }
        public Hand Hand { get; set; } = new();
        public Player(string name)
        {
            Name = name;
        }
    }
}
