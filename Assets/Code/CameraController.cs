using UnityEngine;


namespace GeekBrains
{
    public class CameraController : IExecute
    {
        #region Fields

        private Transform _mainCamera;
        private Transform _player;
        private Vector3 _offset;

        #endregion


        #region Methods

        public void Execute()
        {
            _mainCamera.position = _player.position + _offset;
        }


        public CameraController(Transform player, Transform mainCamera)
        {
            _player = player;
            _mainCamera = mainCamera;
            _mainCamera.LookAt(_player);
            _offset = _mainCamera.position - _player.position;
        }

        #endregion
    }
}

