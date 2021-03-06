﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace GeekBrains
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        #region Fields

        private ListExecuteObject _interactiveObject;
        private DisplayEndGame _displayEndGame;
        private DisplayBonuses _displayBonuses;
        private DisplayWonGame _displayWon;
        private CameraController _cameraController;
        private InputController _inputController;
        private Reference _reference;
        private Coins _coin;
        private int _numberOfScene = 0;
        private int _maxPointCoin = 5;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _interactiveObject = new ListExecuteObject();
            _coin = new Coins();
            _reference = new Reference();

            _cameraController = new CameraController(_reference.PlayerBall.transform,
                _reference.MainCamera.transform);
            _interactiveObject.AddExecuteObject(_cameraController);

            _inputController = new InputController(_reference.PlayerBall);
            _interactiveObject.AddExecuteObject(_inputController);

            _displayEndGame = new DisplayEndGame(_reference.EndGame);
            _displayBonuses = new DisplayBonuses(_reference.Coin);
            _displayWon = new DisplayWonGame(_reference.GameWon);

            foreach (var item in _interactiveObject)
            {
                if (item is Mantrap mantrap)
                {
                    mantrap.OnCaughtPlayerChange += CaughtPlayer;
                    mantrap.OnCaughtPlayerChange += _displayEndGame.GameOver;
                }

                if (item is Coins coin)
                {
                    coin.OnPointChange += AddBonuse;
                    coin.OnPointChange += _displayBonuses.Display;
                }
            }
            _reference.RestartButton.onClick.AddListener(RestartGame);
            _reference.RestartButton.gameObject.SetActive(false);
        }

        private void Update()
        {
            DrawningObjects();
            _displayBonuses.Display(_coin.Point);
            CheckCountPoint();
        }

        #endregion


        #region Methods

        public void RestartGame()
        {
            SceneManager.LoadScene(_numberOfScene);
            Time.timeScale = 1.0f;
        }

        public void Dispose()
        {
            foreach (var item in _interactiveObject)
            {
                if (item is Mantrap mantrap)
                {
                    mantrap.OnCaughtPlayerChange -= CaughtPlayer;
                    mantrap.OnCaughtPlayerChange -= _displayEndGame.GameOver;
                }

                if (item is Coins coins)
                {
                    coins.OnPointChange -= AddBonuse;
                    coins.OnPointChange -= _displayBonuses.Display;
                }
                Destroy(gameObject);
            }
        }

        private void DrawningObjects()
        {
            for (var i = 0; i < _interactiveObject.Length; i++)
            {
                var interactiveObject = _interactiveObject[i];

                if (interactiveObject == null)
                {
                    continue;
                }
                interactiveObject.Execute();
            }
        }

        private void CaughtPlayer(string value, Color args)
        {
            _reference.RestartButton.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }

        private void AddBonuse(int value)
        {
            _coin.Point += value;
            _displayBonuses.Display(_coin.Point);
        }

        private void CheckCountPoint()
        {
            if (_coin.Point == _maxPointCoin)
            {
                _displayWon.GameWon();
                Time.timeScale = 0;
            }
        }

        #endregion
    }
}
