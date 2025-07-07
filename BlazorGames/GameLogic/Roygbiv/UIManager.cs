namespace BlazorGames.GameLogic.Roygbiv
{
    public class UIManager
    {
        public bool DrawPileIsRevealed { get; private set; } = false;
        public bool DrawPileIsSelected { get; private set; } = false;
        public bool DiscardPileIsSelected { get; private set; } = false;

        public void RevealDrawPile()
        {
            DrawPileIsRevealed = true;
            DrawPileIsSelected = true;
            DiscardPileIsSelected = false;
        }

        public void DeselectAllPiles()
        {
            DrawPileIsSelected = false;
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
    }
}
