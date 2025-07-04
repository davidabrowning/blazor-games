﻿using BlazorGames.GameLogic.Roygbiv;
using BlazorGames.Models.Roygbiv;

namespace BlazorGames.Pages.Games
{
    public partial class Roygbiv
    {
        private readonly GameManager _gameManager;

        public IEnumerable<Player> Players { get { return _gameManager.Players; } }
        public Card? DrawPileTopCard { get { return _gameManager.DrawPile.TopCard; } }
        public Card? DiscardPileTopCard { get { return _gameManager.DiscardPile.TopCard; } }
        public bool GameInProgress { get { return _gameManager.IsGameInProgress; } }
        public bool DrawPileIsRevealed { get { return _gameManager.DrawPileIsRevealed; } }
        public bool DrawPileIsSelected { get { return _gameManager.DrawPileIsSelected; } }
        public bool DiscardPileIsSelected { get { return _gameManager.DiscardPileIsSelected; } }
        public Player ActivePlayer { get {  return _gameManager.ActivePlayer; } }

        public Roygbiv(GameManager gameManager)
        {
            _gameManager = gameManager;
            _gameManager.AddPlayer("Player 1");
            _gameManager.AddPlayer("Player 2");
        }

        public void DealCards()
        {
            _gameManager.DealCards();
        }

        public void RevealDrawPile()
        {
            _gameManager.RevealDrawPile();
        }

        public void SelectDiscardPile()
        {
            _gameManager.SelectDiscardPile();
        }

        public void HandleHandCardClick(Player player, Card card)
        {
            _gameManager.HandleHandCardClick(player, card);
        }
    }
}
