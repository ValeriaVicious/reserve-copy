using System;


namespace GeekBrains
{
    public static class ExtensionMethods
    {
        #region Methods

        public static float TrySingle(this string str)
        {
            var value = float.TryParse(str, out float result);
            if (value)
            {
                return result;
            }
            else
            {
                return float.NaN;
            }
        }

        public static bool TryBool(this string str)
        {
            return bool.TryParse(str, out var result) && result;
        }

        #endregion
    }
}
