using UnityEngine;


namespace GeekBrains
{
    public sealed class InputController : IExecute
    {
        #region Fields

        private readonly PlayerBase _playerBase;

        #endregion


        #region ClassLifeCycles

        public InputController(PlayerBase player)
        {
            _playerBase = player;
        }

        #endregion

        #region Methods

        public void Execute()
        {
            _playerBase.Move(Input.GetAxis(PlayerBase.HorizontalInput), 0.0f,
                Input.GetAxis(PlayerBase.VerticalInput));
        }

        #endregion
    }
}
