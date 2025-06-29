namespace BlazorGames.Models.Roygbiv
{
    public class Card
    {
        public int Value { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Card))
                return false;
            Card cardObj = (Card)obj;
            if (cardObj.Value != Value)
                return false;
            return true;
        }
    }
}
