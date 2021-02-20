using UnityEngine;


namespace GeekBrains
{
    public sealed class MiniMap : MonoBehaviour
    {
        #region Fields

        private Transform _playerPosition;
        private string _pathOfTexture = "MiniMap/MapTexture";
        private float _xValue = 90.0f;
        private float _yValue = 5.0f;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _playerPosition = Camera.main.transform;
            transform.parent = null;
            transform.rotation = Quaternion.Euler(_xValue, 0.0f, 0.0f);
            transform.position = _playerPosition.position + new Vector3(0.0f, _yValue, 0.0f);

            var renderTexture = Resources.Load<RenderTexture>(_pathOfTexture);
            GetComponent<Camera>().targetTexture = renderTexture;
        }

        private void LateUpdate()
        {
            var newPosition = _playerPosition.position;
            newPosition.y = transform.position.y;
            transform.position = newPosition;
            transform.rotation = Quaternion.Euler(_xValue, _playerPosition.eulerAngles.y, 0.0f);
        }

        #endregion
    }
}
