using System;
using UnityEngine;
using UnityEngine.UI;


namespace GeekBrains
{
    public sealed class DisplayBonuses
    {
        #region Fields

        [SerializeField] private Text _coinLabel;

        #endregion


        #region ClassLifeCycles

        public DisplayBonuses(GameObject coin)
        {
            _coinLabel = coin.GetComponentInChildren<Text>();
            _coinLabel.text = string.Empty;
        }

        #endregion


        #region Methods

        public void Display(int value)
        {
            PlayerBall.CoinTake += OnPlayerCoinsChanged;
            _coinLabel.text = $"Coins: {value}";
        }

        private void OnPlayerCoinsChanged(int totalCoins) => _coinLabel.text = totalCoins.ToString();

        #endregion
    }
}
