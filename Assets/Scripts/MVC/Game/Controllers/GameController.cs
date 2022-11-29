using Game.Enemy;
using Game.Player;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    internal class GameController : DisposableObject
    {
        private readonly Transform _uiContainer;
        private readonly GameView _gameView;
        private readonly GameModel _gameModel;

        private PlayerController _playerController;
        private List<EnemyController> enemyControllers = new List<EnemyController>();

        public GameController(Transform container, GameModel gameModel)
        {
            _uiContainer = container;


            _gameView = GameObject.Find("GamePanel").GetComponent<GameView>();
            _gameModel = gameModel;
            _gameModel.CurrentState.SunscribeOnChangeWhithParameter(OnChangeGameState);
            AddGameObject(_gameView.gameObject);
            _gameView.Init(Pause, _gameModel.Score);

            OnChangeGameState(_gameModel.CurrentState.Value);

            _playerController = new PlayerController();

            CreateEnemyControllers();
        }
        private void CreateEnemyControllers() 
        {
            foreach (EnemyView enemy in _gameView.Enemies)
            {
                EnemyController controller = new EnemyController(enemy, _gameModel);
                enemyControllers.Add(controller);
            }
        }
        protected override void OnDispose()
        {
            _gameModel.CurrentState.UnSubscribeOnChangeWhithParameter(OnChangeGameState);

            DisposeObjects();

            foreach (EnemyController controller in enemyControllers)
            {
                controller?.Dispose();
            }

            enemyControllers.Clear();
        }
        private void Pause() =>
            _gameModel.CurrentState.Value = GameState.Pause;

        private void OnChangeGameState(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Pause:
                    Debug.Log("Pause");
                    break;
                case GameState.Lose:
                    Debug.Log("GameOver");
                    DisposeObjects();
                    break;
            }
        }
        private void DisposeObjects() 
        {
            _playerController?.Dispose();
        }
    }
}