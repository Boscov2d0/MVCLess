using Game.Enemy;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    internal class EnemyPoolModel
    {
        private readonly List<EnemyView> EnemyViews = new List<EnemyView>();
        private readonly List<EnemyController> EnemyControllers = new List<EnemyController>();
        private readonly GameModel _gameModel;
        private float _timeToSpawn = 5f;
        private float _spawnTimer;

        private SubscriptionPropertyWhithParameter<int> _countOfActiveEnemies = new SubscriptionPropertyWhithParameter<int>();

        public EnemyPoolModel(List<EnemyView> enemies, GameModel gameModel) 
        {
            EnemyViews = enemies;
            _gameModel = gameModel;

            CreateEnemiesController();
            _spawnTimer = 0f;

            UpdateManager.Instance.SunscribeToFixedUpdate(SpawnTimer);
            UpdateManager.Instance.SunscribeToUpdate(CheckActiveEnemies);
            _countOfActiveEnemies.SunscribeOnChange(_gameModel.GetGameCondition);
        }

        public void SpawnTimer() 
        {
            _spawnTimer -= Time.fixedDeltaTime;
            if (_spawnTimer <= 0) 
            {
                PlaceEnemy();
                _spawnTimer = _timeToSpawn;
            }
        }

        private void CreateEnemiesController() 
        {
            for (int i = 0; i < EnemyViews.Count; i++) 
            {
                EnemyController enemyController = new EnemyController(EnemyViews[i]);
                EnemyControllers.Add(enemyController);

                EnemyViews[i].State.SubscribeOnChange(CheckEnemyStateOnDeath);
            }
        }

        private void PlaceEnemy()
        {
            foreach (EnemyView enemy in EnemyViews)
            {
                if (enemy.State.Value == EnemyState.Deactive)
                {
                    enemy.State.Value = EnemyState.Active;
                    enemy.Transform.position = SetStartPosition();
                    return;
                }
            }
        }
        private Vector3 SetStartPosition()
        {
            return new Vector3(Random.Range(-6f, 7f), 1, Random.Range(-6f, 7f));
        }
        private void CheckActiveEnemies() 
        {
            int count = 0;

            foreach (EnemyView enemy in EnemyViews)
            {
                if (enemy.State.Value != EnemyState.Deactive)
                {
                    count++;
                }
            }

            _countOfActiveEnemies.Value = count;
        }
        private void CheckEnemyStateOnDeath() 
        {
            foreach (EnemyView enemy in EnemyViews)
            {
                if (enemy.State.Value == EnemyState.Dead)
                {
                    _gameModel.Score.Value++;
                }
            }
        }
    }
}