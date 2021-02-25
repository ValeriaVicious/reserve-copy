using UnityEngine;


namespace GeekBrains
{
    public sealed class InputController : IExecute
    {
        #region Fields

        private readonly PlayerBase _playerBase;
        private readonly SaveDataRepository _saveDataRepository;
        private readonly KeyCode _savePlayer = KeyCode.C;
        private readonly KeyCode _loadPlayer = KeyCode.V;

        #endregion


        #region ClassLifeCycles

        public InputController(PlayerBase player)
        {
            _playerBase = player;
            _saveDataRepository = new SaveDataRepository();
        }

        #endregion


        #region Methods

        public void Execute()
        {
            _playerBase.Move(Input.GetAxis(PlayerBase.HorizontalInput), 0.0f,
                Input.GetAxis(PlayerBase.VerticalInput));

            if (Input.GetKeyDown(_savePlayer))
            {
                _saveDataRepository.Save(_playerBase);
            }
            if (Input.GetKeyDown(_loadPlayer))
            {
                _saveDataRepository.Load(_playerBase);
            }
        }

        #endregion
    }
}
