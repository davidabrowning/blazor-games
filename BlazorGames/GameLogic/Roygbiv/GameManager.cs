using BlazorGames.Models.Roygbiv;

namespace BlazorGames.GameLogic.Roygbiv
{
    public class GameManager
    {
        public const int MaxHandSize = 10;

        private readonly UIManager _uiManager;

        public int TurnCounter { get; private set; } = 0;
        public Deck Deck { get; } = new();
        public DrawPile DrawPile { get; } = new();
        public DiscardPile DiscardPile { get; } = new();
        public List<Player> Players { get; } = new();
        public bool IsMatchStarted { get { return Players.Count > 0 && Players[0].Hand.Cards.Count > 0; } }
        public bool IsGameInProgress { get { return IsMatchStarted && !IsGameOver(); } }
        public bool InitialSwapsInProgress { get { return Players.Where(p => p.Hand.HasSwapped == false).Any(); } }
        public Player ActivePlayer { get { return Players[TurnCounter % Players.Count]; } }
        public Card? ActiveSwapCard { get; private set; } = null;

        public GameManager(UIManager uiManager)
        {
            _uiManager = uiManager;
        }

        public void AddPlayers(int numPlayers)
        {
            for (int i = 0; i < numPlayers; i++)
            {
                Player player = new Player("Player " + i);
                Players.Add(player);
            }
        }

        public void DealCards()
        {
            Deck.Shuffle();
            DealHandsToPlayers();
            DealRemainingCardsToDrawPile();
        }

        private void DealHandsToPlayers()
        {
            foreach (Player player in Players)
            {
                DealHandToPlayer(player);
            }
        }

        private void DealHandToPlayer(Player player)
        {
            while (player.Hand.Cards.Count < MaxHandSize)
            {
                Card card = Deck.DrawTopCard();
                player.Hand.Cards.Add(card);
            }
        }

        private void DealRemainingCardsToDrawPile()
        {
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

        public void HandleDrawPileClick()
        {
            if (InitialSwapsInProgress)
            {
                return;
            }

            _uiManager.RevealDrawPile();
        }

        public void HandleDiscardPileClick()
        {
            if (InitialSwapsInProgress)
            {
                return;
            }

            _uiManager.SelectDiscardPile();
        }

        public void HandleHandCardClick(Player targetPlayer, Card targetCard)
        {
            if (targetPlayer != ActivePlayer)
            {
                return;
            }

            if (InitialSwapsInProgress)
            {
                HandleInitialSwapClick(targetPlayer, targetCard);
            }

            if (_uiManager.DrawPileIsSelected || _uiManager.DiscardPileIsSelected)
            {
                HandleCardPickupClick(targetPlayer, targetCard);
            }
        }

        private void HandleInitialSwapClick(Player targetPlayer, Card targetCard)
        {
            if (ActiveSwapCard == null)
            {
                ActiveSwapCard = targetCard;
                return;
            }

            if (ActiveSwapCard != targetCard)
            {
                targetPlayer.Hand.Swap(ActiveSwapCard, targetCard);
                ActiveSwapCard = null;
                TurnCounter++;
            }
        }

        private void HandleCardPickupClick(Player targetPlayer, Card targetCard)
        {
            Card? drawnCard = null;
            if (_uiManager.DrawPileIsSelected)
            {
                drawnCard = DrawPile.DrawTopCard();
                if (DrawPile.Cards.Count == 0)
                {
                    while(DiscardPile.Cards.Count > 0)
                    {
                        Deck.Cards.Add(DiscardPile.Cards.Pop());
                    }
                    Deck.Shuffle();
                    DealRemainingCardsToDrawPile();
                }
            }

            if (_uiManager.DiscardPileIsSelected)
            {
                drawnCard = DiscardPile.Cards.Pop();
            }

            if (drawnCard == null)
            {
                return;
            }

            _uiManager.UnrevealDrawPileAndDeselectAllPiles();
            targetPlayer.Hand.Replace(targetCard, drawnCard);
            DiscardPile.Cards.Push(targetCard);
            TurnCounter++;
        }
    }
}
