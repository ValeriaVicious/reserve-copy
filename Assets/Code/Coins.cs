using System;
using UnityEngine;
using static UnityEngine.Debug;
using static UnityEngine.Random;


namespace GeekBrains
{
    public sealed class Coins : InteractiveObjects, IFlay, IFlicker
    {
        #region Fields

        public int Point;
        public event Action<int> OnPointChange = delegate (int i) { };

        private Material _material;
        private float _lengthFlay;
        private float _minRange = 1.0f;
        private float _maxRange = 5.0f;
        private int _valueOfBonus = 5;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFlay = Range(_minRange, _maxRange);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(PlayerTag))
            {
                Log("I'm here");
                Interaction();
                Destroy(gameObject);
            }
        }

        #endregion


        #region Methods

        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFlay), transform.localPosition.z);
        }

        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g,
                _material.color.b, Mathf.PingPong(Time.time, 1.0f));
        }

        protected override void Interaction()
        {
            _valueOfBonus++;
            OnPointChange?.Invoke(Point);
        }

        public override void Execute()
        {
            if (!IsInterectable)
            {
                return;
            }
            Flicker();
            Flay();
        }

        #endregion
    }
}
