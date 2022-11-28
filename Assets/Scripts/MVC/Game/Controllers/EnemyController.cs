using UnityEngine;

namespace Game.Enemy
{
    internal class EnemyController : DisposableObject
    {
        private readonly EnemyProfile _enemyProfile;
        private readonly EnemyView _enemyView;
        private readonly EnemyModel _enemyModel;
            
        public EnemyController(EnemyView enemyView)
        {
            _enemyProfile = LoadEnemyProfile();
            _enemyView = enemyView;
            _enemyModel = new EnemyModel(_enemyProfile);

            _enemyView.Init(_enemyModel.State);
            _enemyModel.Init(_enemyView.State);

            _enemyView.OnClickAction += _enemyModel.OnChangeHealth;
            _enemyView.OnCollisionEnterAction += _enemyModel.OnChangeDirection;

            _enemyModel.Direction.SubscribeOnChange(SetDirection);

            SetSpeed();
        }
        private EnemyProfile LoadEnemyProfile() 
        {
            return Resources.Load<EnemyProfile>("Settings/EnemyProfile");
        }
        protected override void OnDispose() 
        {
            _enemyView.OnClickAction -= _enemyModel.OnChangeHealth;
            _enemyView.OnCollisionEnterAction -= _enemyModel.OnChangeDirection;

            _enemyModel.Direction.UnSubscribeOnChange(SetDirection);
        }
        private void SetDirection() 
        {
            _enemyView.Direction = _enemyModel.Direction.Value;
        }
        private void SetSpeed()
        {
            _enemyView.Speed = _enemyModel.Speed.Value;
        }
    }
}