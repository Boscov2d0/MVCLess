namespace Game.Enemy
{
    internal class EnemyController : DisposableObject
    {
        private readonly EnemyView _enemyView;
        private readonly EnemyModel _enemyModel;
            
        public EnemyController(EnemyView enemyView, GameModel gameModel)
        {
            _enemyModel = new EnemyModel(gameModel);
            _enemyModel.Direction.SubscribeOnChange(SetDirection);
            _enemyModel.Speed.SubscribeOnChange(SetSpeed);

            _enemyView = enemyView;
            _enemyView.Init(_enemyModel.State);
            _enemyView.OnClickAction += _enemyModel.OnChangeHealth;
            _enemyView.OnCollisionEnterAction += _enemyModel.OnChangeDirection;

            SetSpeed();
        }
        private void SetDirection() =>
            _enemyView.Direction = _enemyModel.Direction.Value;

        private void SetSpeed() =>
            _enemyView.Speed = _enemyModel.Speed.Value;

        protected override void OnDispose()
        {
            _enemyView.OnClickAction -= _enemyModel.OnChangeHealth;
            _enemyView.OnCollisionEnterAction -= _enemyModel.OnChangeDirection;

            _enemyModel.Direction.UnSubscribeOnChange(SetDirection);

            _enemyModel.Dispose();
        }
    }
}