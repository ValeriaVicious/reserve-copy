using UnityEngine;


namespace GeekBrains
{
    public class PlayerPrefsData : IData<SavedData>
    {

        #region Methods

        public void Save(SavedData savedData, string path = null)
        {
            PlayerPrefs.SetString("Name", savedData.Name);
            PlayerPrefs.SetFloat("PositionX", savedData.Position.X);
            PlayerPrefs.SetFloat("PositionY", savedData.Position.Y);
            PlayerPrefs.SetFloat("PositionZ", savedData.Position.Z);
            PlayerPrefs.SetString("IsEnebled", savedData.IsEnabled.ToString());
            PlayerPrefs.Save();
        }
        public SavedData Load(string path = null)
        {
            var result = new SavedData();
            var key = "Name";
            if (PlayerPrefs.HasKey(key))
            {
                result.Name = PlayerPrefs.GetString(key);
            }

            key = "PositionX";
            if (PlayerPrefs.HasKey(key))
            {
                result.Position.X = PlayerPrefs.GetFloat(key);
            }

            key = "PositionY";
            if (PlayerPrefs.HasKey(key))
            {
                result.Position.Y = PlayerPrefs.GetFloat(key);
            }

            key = "PositionZ";
            if (PlayerPrefs.HasKey(key))
            {
                result.Position.Z = PlayerPrefs.GetFloat(key);
            }

            key = "IsEnabled";
            if (PlayerPrefs.HasKey(key))
            {
                result.IsEnabled = PlayerPrefs.GetString(key).TryBool();
            }
            return result;
        }

        public void Clear()
        {
            PlayerPrefs.DeleteAll();
        }

        #endregion
    }
}