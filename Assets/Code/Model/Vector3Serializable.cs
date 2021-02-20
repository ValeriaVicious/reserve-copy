using System;
using UnityEngine;


namespace GeekBrains
{
    [Serializable]
    public struct Vector3Serializable
    {
        #region Fields

        public float X;
        public float Y;
        public float Z;

        #endregion


        #region ClassLifeCycles

        private Vector3Serializable(float valueX, float valueY, float valueZ)
        {
            X = valueX;
            Y = valueY;
            Z = valueZ;
        }

        #endregion


        #region Methods

        public static implicit operator Vector3(Vector3Serializable value)
        {
            return new Vector3(value.X, value.Y, value.Z);
        }

        public static implicit operator Vector3Serializable(Vector3 value)
        {
            return new Vector3Serializable(value.x, value.y, value.z);
        }

        public override string ToString() => $" (X = {X} Y = {Y} Z = {Z})";
        
        #endregion
    }
}
