using Game.Lose;
using Game.Pause;
using Game.Player;
using UnityEngine;

namespace Game
{
    internal class MainController : DisposableObject
    {
        private readonly Transform _uiContainer;
        private readonly GameModel _gameModel;

        private GameController _gameController;
        private PlayerController _playerController;
        private EnemyPoolController _enemyPoolController;
        private PauseController _pauseController;
        private LoseController _loseController; 

        public MainController(Transform container, GameModel gameModel)
        {
            _uiContainer = container;
            _gameModel = gameModel;

            gameModel.CurrentState.SunscribeOnChange(OnChangeGameState);
            OnChangeGameState(_gameModel.CurrentState.Value);

            _gameController = new GameController(_uiContainer, _gameModel);
            _enemyPoolController = new EnemyPoolController(_gameModel);
            _playerController = new PlayerController();
        }
        protected override void OnDispose()
        {
            DisposeObjects();
        }
        private void OnChangeGameState(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Game:
                    _pauseController?.Dispose();
                    break;
                case GameState.Pause:
                    _pauseController = new PauseController(_uiContainer, _gameModel);
                    break;
                case GameState.Lose:
                    _loseController = new LoseController(_uiContainer);
                    DisposeObjects();
                    break;
            }
        }
        private void DisposeObjects() 
        {
            _gameController?.Dispose();
            _enemyPoolController?.Dispose();
            _playerController?.Dispose();
            _pauseController?.Dispose();
        }
    }
}