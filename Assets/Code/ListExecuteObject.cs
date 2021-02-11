using System;
using System.Collections;
using Object = UnityEngine.Object;


namespace GeekBrains
{
    public sealed class ListExecuteObject : IEnumerator, IEnumerable
    {
        #region Fields

        private IExecute[] _interactiveObjects;
        private InteractiveObjects _current;
        private int _index = -1;

        #endregion


        #region ClassLifeCycles

        public ListExecuteObject()
        {
            var interactiveObjects = Object.FindObjectsOfType<InteractiveObjects>();
            for (int i = 0; i < interactiveObjects.Length; i++)
            {
                if (interactiveObjects[i] is IExecute interactiveObject)
                {
                    AddExecuteObject(interactiveObject);
                }
            }
        }

        public void AddExecuteObject(IExecute execute)
        {
            if (_interactiveObjects == null)
            {
                _interactiveObjects = new[]
                {
                    execute
                };
                return;
            }
            Array.Resize(ref _interactiveObjects, Length + 1);
            _interactiveObjects[Length - 1] = execute;
        }

        #endregion


        #region Methods

        public IExecute this[int index]
        {
            get => _interactiveObjects[index];
            private set => _interactiveObjects[index] = value;
        }

        public int Length => _interactiveObjects.Length;

        public object Current => _interactiveObjects[_index];

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (_index == _interactiveObjects.Length - 1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }

        public void Reset() => _index = -1;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
