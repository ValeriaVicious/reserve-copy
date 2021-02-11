using System;
using UnityEngine;
using static UnityEngine.Debug;
using static UnityEngine.Random;


namespace GeekBrains
{
    public sealed class Mantrap : InteractiveObjects, IFlay, IFlicker, IExecute
    {
        #region Fields

        public event Action<string, Color> OnCaughtPlayerChange = delegate (string str, Color color) { };

        private Material _material;
        private float _lengthFlay;
        private float _minFlayRange = 1.0f;
        private float _maxFlayRange = 5.0f;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFlay = Range(_minFlayRange, _maxFlayRange);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(PlayerTag))
            {
                Log("I kill you!");
                Interaction();
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
            OnCaughtPlayerChange?.Invoke(gameObject.name, _color);
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
