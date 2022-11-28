using UnityEngine;

namespace Game
{
    internal class EnemyPoolController : DisposableObject
    {
        private readonly string _resourceCameraPlayerViewPath = "EnemyPool";
        private readonly EnemyPoolModel _enemyPoolModel;
        private readonly GameModel _gameModel;
        private EnemyPoolView _enemyPoolView;

        public EnemyPoolController(GameModel gameModel) 
        {
            _enemyPoolView = LoadEnemyPoolView();
            AddGameObject(_enemyPoolView.gameObject);

            _enemyPoolModel = new EnemyPoolModel(_enemyPoolView.Enemies, gameModel);
        }

        private EnemyPoolView LoadEnemyPoolView() 
        {
            EnemyPoolView enemyPoolViewPrefab = Resources.Load<EnemyPoolView>(_resourceCameraPlayerViewPath);
            return GameObject.Instantiate<EnemyPoolView>(enemyPoolViewPrefab);
        }
    }
}