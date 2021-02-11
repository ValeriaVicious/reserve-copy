using UnityEngine;
using UnityEngine.UI;


namespace GeekBrains
{
    public class Reference
    {
        #region Fields

        private PlayerBall _playerBall;
        private Camera _mainCamera;
        private GameObject _coin;
        private GameObject _endGame;
        private GameObject _gameWon;
        private Canvas _canvas;
        private Button _restartButton;
        private string _pathCoin = "UI/CoinCurrent";
        private string _pathEndGame = "UI/EndGame";
        private string _pathButton = "UI/Restart";
        private string _pathWonGame = "UI/Won";

        #endregion


        #region Methods

        public Button RestartButton
        {
            get
            {
                if (_restartButton == null)
                {
                    var gameObject = Resources.Load<Button>(_pathButton);
                    _restartButton = Object.Instantiate(gameObject, Canvas.transform);
                }
                return _restartButton;
            }
        }

        public Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                return _canvas;
            }
        }

        public GameObject Coin
        {
            get
            {
                if (_coin == null)
                {
                    var gameObject = Resources.Load<GameObject>(_pathCoin);
                    _coin = Object.Instantiate(gameObject, Canvas.transform);
                }
                return _coin;
            }
        }

        public GameObject EndGame
        {
            get
            {
                if (_endGame == null)
                {
                    var gameObject = Resources.Load<GameObject>(_pathEndGame);
                    _endGame = Object.Instantiate(gameObject, Canvas.transform);
                }
                return _endGame;
            }
        }

        public GameObject GameWon
        {
            get
            {
                if(_gameWon == null)
                {
                    var gameObject = Resources.Load<GameObject>(_pathWonGame);
                    _gameWon = Object.Instantiate(gameObject, Canvas.transform);
                }
                return _gameWon;
            }
        }

        public PlayerBall PlayerBall
        {
            get
            {
                if (_playerBall == null)
                {
                    var gameObject = Resources.Load<PlayerBall>(InteractiveObjects.PlayerTag);
                    _playerBall = Object.Instantiate(gameObject);
                }
                return _playerBall;
            }
        }

        public Camera MainCamera
        {
            get
            {
                if (_mainCamera == null)
                {
                    _mainCamera = Camera.main;
                }
                return _mainCamera;
            }
        }

        #endregion
    }
}
