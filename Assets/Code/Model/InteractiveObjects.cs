using UnityEngine;
using Random = UnityEngine.Random;


namespace GeekBrains
{
    public abstract class InteractiveObjects : MonoBehaviour, IExecute
    {
        #region Fields

        protected Color _color;
        public const string PlayerTag = "Player";
        private bool _isInteractable;

        #endregion


        #region UnityMethods

        private void Start()
        {
            IsInterectable = true;
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = _color;
            }
            Action();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInterectable || !other.CompareTag(PlayerTag))
            {
                return;
            }
            else
            {
                Interaction();
                IsInterectable = false;
                Destroy(gameObject);
            }
        }

        #endregion


        #region Methods

        protected abstract void Interaction();

        public void Action()
        {
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = Random.ColorHSV();
            }
        }

        public abstract void Execute();

        protected bool IsInterectable
        {
            get
            {
                return _isInteractable;
            }
            private set
            {
                _isInteractable = value;
                GetComponent<Renderer>().enabled = _isInteractable;
                GetComponent<Collider>().enabled = _isInteractable;
            }
        }

        #endregion
    }
}
