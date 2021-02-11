using System;
using UnityEngine;


namespace GeekBrains
{
    [Serializable]
    public sealed class SavedData
    {
        #region Fields

        public string Name;
        public Vector3Serializable Position;
        public bool IsEnabled;

        #endregion


        #region Methods

        public override string ToString()
        {
            return $"Name {Name} Position {Position} IsVisible {IsEnabled}";
        }

        #endregion
    }
}
