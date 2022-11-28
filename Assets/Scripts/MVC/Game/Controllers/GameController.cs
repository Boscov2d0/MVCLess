using UnityEngine;

namespace Game
{
    internal class GameController : DisposableObject
    {
        private readonly string _resourcePath = "UI/Game/GamePanel";
        private readonly GameView _gameView;
        private readonly GameModel _gameModel;

        public GameController(Transform uiContainer, GameModel gameModel)
        {
            _gameView = LoadGameView(uiContainer);
            AddGameObject(_gameView.gameObject);

            _gameModel = gameModel;

            _gameView.Init(Pause, _gameModel.Score);
        }
        private GameView LoadGameView(Transform uiContainer) 
        {
            GameView _gameViewPrefab = Resources.Load<GameView>(_resourcePath);
            return GameObject.Instantiate(_gameViewPrefab, uiContainer, false);
        }
        private void Pause() =>
            _gameModel.CurrentState.Value = GameState.Pause;
    }
}