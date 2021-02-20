using UnityEngine;
using UnityEngine.UI;


namespace GeekBrains
{
    public sealed class DisplayWonGame
    {
        #region Fields

        private Text _wonGameLabel;

        #endregion


        #region ClassLifeCycles

        public DisplayWonGame(GameObject wonGame)
        {
            _wonGameLabel = wonGame.GetComponentInChildren<Text>();
            _wonGameLabel.text = string.Empty;
        }

        #endregion


        #region Methods

        public void GameWon()
        {
            _wonGameLabel.text = "You WON!";
        }

        #endregion
    }
}
