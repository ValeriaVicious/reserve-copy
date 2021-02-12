using System.IO;
using UnityEngine;
using static UnityEngine.Debug;


namespace GeekBrains
{
    public sealed class SaveDataRepository
    {
        #region Fields

        private readonly IData<SavedData> _data;
        private readonly string _path;
        private const string _folderName = "SaveInformation";
        private const string _fileName = "info.bat";

        #endregion


        #region ClassLifeCycles

        public SaveDataRepository()
        {
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                _data = new PlayerPrefsData();
            }
            else
            {
                _data = new JsonData<SavedData>();
            }
            _path = Path.Combine(Application.dataPath, _folderName);
        }

        #endregion


        #region Methods

        public void Save(PlayerBase playerBase)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }

            var savePlayer = new SavedData
            {
                Position = playerBase.transform.position,
                Name = "player_01",
                IsEnabled = true
            };

            _data.Save(savePlayer, Path.Combine(_path, _fileName));
        }

        public void Load(PlayerBase playerBase)
        {
            var file = Path.Combine(_path, _fileName);

            if (!File.Exists(file))
            {
                return;
            }

            var newPlayer = _data.Load(file);
            playerBase.transform.position = newPlayer.Position;
            playerBase.name = newPlayer.Name;
            playerBase.gameObject.SetActive(newPlayer.IsEnabled);

            Log(newPlayer);
        }

        #endregion
    }
}
