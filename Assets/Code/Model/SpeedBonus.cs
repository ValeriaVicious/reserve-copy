using System;
using UnityEngine;
using static UnityEngine.Debug;
using static UnityEngine.Random;


namespace GeekBrains
{
    public sealed class SpeedBonus : InteractiveObjects, IFlay, IRotation, IFlicker
    {

        #region Fields

        [SerializeField] private float _speedBonusPower = 3.0f;

        private Material _material;
        private PlayerBall _player;
        private float _speedRotation;
        private float _lengthFlay;
        private float _minFlayRange = 1.0f;
        private float _maxFlayRange = 5.0f;
        private float _minRotationRange = 10.0f;
        private float _maxRotationRange = 50.0f;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _lengthFlay = Range(_minFlayRange, _maxFlayRange);
            _speedRotation = Range(_minRotationRange, _maxRotationRange);
            _material = GetComponent<Renderer>().material;
            _player = gameObject.AddComponent<PlayerBall>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(PlayerTag))
            {
                Interaction();
                Log($"Woohoo. Your speed is {_player.Speed}");
                Destroy(gameObject);
            }
        }

        #endregion


        #region Methods

        protected override void Interaction()
        {
            PowerUpLoad();
        }

        protected override void PowerUpLoad()
        {
            base.PowerUpLoad();
            _player.SetSpeedBonus(_speedBonusPower);
        }

        public void RotationObject()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }

        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFlay), transform.localPosition.z);
        }

        public override void Execute()
        {
            if (IsInterectable)
            {
                return;
            }
            Flay();
            RotationObject();
        }

        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g,
                _material.color.b, Mathf.PingPong(Time.time, 1.0f));
        }

        #endregion

    }
}
