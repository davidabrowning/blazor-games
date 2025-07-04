namespace BlazorGames.Models.Roygbiv
{
    public class Card
    {
        public int Value { get; private set; }
        public string Color { get { return $"hsl({CalculateHue()},100%,80%)"; } }
        public Card(int value)
        {
            Value = value;
        }

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

        private int CalculateHue()
        {
            // 0 => 0
            // 60 => 240
            return Value * 4;
        }
    }
}
