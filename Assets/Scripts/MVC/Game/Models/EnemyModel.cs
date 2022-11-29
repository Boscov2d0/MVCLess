using UnityEngine;

using Random = UnityEngine.Random;

namespace Game.Enemy
{
    internal class EnemyModel
    {
        private readonly GameModel _gameMode;
        private readonly float _defaultBitrhTime;
        private readonly float _defaultDeathTime;
        private readonly float _defaultSpeed;
        private readonly int _defaultHealth;

        private float _bitrhTime;
        private float _deathTime;

        public SubscriptionProperty<EnemyState> State = new SubscriptionProperty<EnemyState>();
        public SubscriptionProperty<float> Speed = new SubscriptionProperty<float>();
        public SubscriptionProperty<int> Health = new SubscriptionProperty<int>();

        public SubscriptionProperty<Vector3> Direction { get; set; } = new SubscriptionProperty<Vector3>();

        public EnemyModel(GameModel gameModel) 
        {
            _gameMode = gameModel;

            _defaultBitrhTime = 2;
            _defaultDeathTime = 2;
            _defaultHealth = 2;
            _defaultSpeed = 0.05f;

            Health.SubscribeOnChange(GetDeadState);
            State.SubscribeOnChange(OnChangeEnemyState);
            UpdateManager.Instance.SunscribeToFixedUpdate(Execute);

            State.Value = EnemyState.Active;
        }

        private void Init() 
        {
            Health.Value = _defaultHealth;
            _bitrhTime = _defaultBitrhTime;
            _deathTime = _defaultDeathTime;

            _gameMode.CountOfEnemy.Value++;
        }
        private void Execute() 
        {           
            if (State.Value == EnemyState.Active) 
            {
                BirthTimer();
            }
            if (State.Value == EnemyState.Dead)
            {
                DeathTimer();
                Speed.Value = 0;
            }
        }
        private void OnChangeEnemyState() 
        {
            switch (State.Value) 
            {
                case EnemyState.Active:
                    Init();
                    break;
                case EnemyState.Born:
                    Speed.Value = _defaultSpeed;
                    SetDirection();
                    break;
                case EnemyState.Dead:
                    _gameMode.CountOfEnemy.Value--;
                    _gameMode.IncreaseScore();
                    break;
                case EnemyState.Deactive:
                    break;
            }
        }
        private void BirthTimer() 
        {
            _bitrhTime -= Time.fixedDeltaTime;
            if (_bitrhTime <= 0) 
            {
                State.Value = EnemyState.Born;
            }
        }
        private void GetDeadState()
        {
            if (Health.Value <= 0)
            {
                State.Value = EnemyState.Dead;
            }
        }
        private void DeathTimer()
        {
            _deathTime -= Time.fixedDeltaTime;
            if (_deathTime <= 0)
            {
                State.Value = EnemyState.Deactive;
            }
        }
        private void SetDirection() =>
            Direction.Value = new Vector3(Random.Range(-1f, 2f), 0, Random.Range(-1f, 2f));

        public void OnChangeHealth(int i) =>
            Health.Value -= i;

        public void OnChangeDirection() =>
            Direction.Value = new Vector3(Direction.Value.x * -1, 0, Direction.Value.z * -1);

        public void Dispose()
        {
            Health.UnSubscribeOnChange(GetDeadState);
            State.UnSubscribeOnChange(OnChangeEnemyState);
            UpdateManager.Instance.UnSunscribeToFixedUpdate(Execute);
        }
    }
}