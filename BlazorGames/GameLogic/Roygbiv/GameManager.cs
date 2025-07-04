using BlazorGames.Models.Roygbiv;

namespace BlazorGames.GameLogic.Roygbiv
{
    public class GameManager
    {
        public const int MaxHandSize = 10;

        public int TurnCounter { get; private set; } = 0;
        public Deck Deck { get; } = new();
        public DrawPile DrawPile { get; } = new();
        public DiscardPile DiscardPile { get; } = new();
        public List<Player> Players { get; } = new();
        public bool IsMatchStarted { get {  return Players[0].Hand.Cards.Count > 0; } }
        public bool IsGameInProgress { get { return IsMatchStarted && !IsGameOver(); } }
        public bool DrawPileIsRevealed { get; private set; } = false;
        public bool DrawPileIsSelected { get; private set; } = false;
        public bool DiscardPileIsSelected { get; private set; } = false;
        public Player ActivePlayer { get { return Players[TurnCounter % Players.Count]; } }

        public void AddPlayer(string playerName)
        {
            Players.Add(new Player(playerName));
        }

        public void DealCards()
        {
            Deck.Shuffle();
            foreach (Player player in Players)
            {
                for (int i = 0; i < MaxHandSize; i++)
                {
                    if (player.Hand.Cards.Count >= MaxHandSize)
                    {
                        continue;
                    }
                    Card card = Deck.DrawTopCard();
                    player.Hand.Cards.Add(card);
                }
            }
            while (Deck.Count > 0)
            {
                Card card = Deck.DrawTopCard();
                DrawPile.Cards.Add(card);
            }
        }

        public bool IsGameOver()
        {
            foreach (Player player in Players)
            {
                if (player.Hand.IsSorted())
                {
                    return true;
                }
            }
            return false;
        }

        public void RevealDrawPile()
        {
            DrawPileIsRevealed = true;
            DrawPileIsSelected = true;
            DiscardPileIsSelected = false;
        }

        public void SelectDiscardPile()
        {
            if (DrawPileIsRevealed)
            {
                return;
            }

            DiscardPileIsSelected = true;
        }

        public void HandleHandCardClick(Player targetPlayer, Card targetCard)
        {
            if (targetPlayer != ActivePlayer)
            {
                return;
            }

            if (!DrawPileIsSelected && !DiscardPileIsSelected)
            {
                return;
            }

            if (DrawPileIsSelected)
            {
                DrawPileIsRevealed = false;
                DrawPileIsSelected = false;

                Card drawnCard = DrawPile.DrawTopCard();
                targetPlayer.Hand.Replace(targetCard, drawnCard);
            }

            if (DiscardPileIsSelected)
            {
                DiscardPileIsSelected = false;

                Card drawnCard = DiscardPile.Cards.Pop();
                targetPlayer.Hand.Replace(targetCard, drawnCard);
            }

            DiscardPile.Cards.Push(targetCard);
            TurnCounter++;
        }
    }
}
