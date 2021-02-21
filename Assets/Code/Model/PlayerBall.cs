using UnityEngine;


namespace GeekBrains
{
    public sealed class PlayerBall : PlayerBase
    {
        #region Fields

        private Rigidbody _rigidBody;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        #endregion


        #region Methods

        public void SetSpeedBonus(float speedMultiplier)
        {
            Speed *= speedMultiplier;
        }

        public override void Move(float x, float y, float z)
        {
            _rigidBody.AddForce(new Vector3(x, y, z) * Speed);
        }

        #endregion

    }

}

