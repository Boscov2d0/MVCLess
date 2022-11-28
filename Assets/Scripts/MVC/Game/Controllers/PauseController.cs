using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Pause
{
    internal class PauseController : DisposableObject
    {
        private readonly string _resourceCameraPlayerViewPath = "UI/Game/PausePanel";
        private readonly PauseView _pauseView;
        private readonly GameModel _gameModel;

        public PauseController(Transform uiContainer, GameModel gameModel)
        {
            _pauseView = LoadPauseView(uiContainer);
            AddGameObject(_pauseView.gameObject);

            _gameModel = gameModel;

            _pauseView.Init(ReturnToMainMenu, ContinuePlay);

            _gameModel.GameIsPause.Value = true;
        }
        private PauseView LoadPauseView(Transform uiContainer)
        {
            PauseView _pauseViewPrefab = Resources.Load<PauseView>(_resourceCameraPlayerViewPath);
            return GameObject.Instantiate(_pauseViewPrefab, uiContainer, false);
        }
        private void ReturnToMainMenu() =>
            SceneManager.LoadScene(0);

        private void ContinuePlay()
        {
            _gameModel.CurrentState.Value = GameState.Game;
            _gameModel.GameIsPause.Value = false;
        }
    }
}