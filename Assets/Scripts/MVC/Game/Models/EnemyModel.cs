using UnityEngine;

using Random = UnityEngine.Random;

namespace Game.Enemy
{
    internal class EnemyModel
    {
        private float _defaultBitrhTime;
        private float _defaultDeathTime;
        private float _bitrhTime;
        private float _deathTime;

        public SubscriptionProperty<EnemyState> State = new SubscriptionProperty<EnemyState>();
        public SubscriptionProperty<float> Speed = new SubscriptionProperty<float>();
        public SubscriptionProperty<int> Health = new SubscriptionProperty<int>();

        public SubscriptionProperty<Vector3> Direction { get; set; } = new SubscriptionProperty<Vector3>();

        public EnemyModel(EnemyProfile enemyProfile) 
        {
            Speed.Value = enemyProfile.Speed;
            Health.Value = enemyProfile.Health;

            _defaultBitrhTime = enemyProfile.TimeToBirth;
            _defaultDeathTime = enemyProfile.TimeToDeath;
        }

        public void Init(SubscriptionProperty<EnemyState> state) 
        {
            State = state;
            Health.SubscribeOnChange(GetDeadState);
            State.SubscribeOnChange(OnChangeEnemyState);
            UpdateManager.Instance.SunscribeToFixedUpdate(Execute);

            _bitrhTime = _defaultBitrhTime;
            _deathTime = _defaultDeathTime;
        }

        private void DeInit() 
        {
            
        }
        private void Dispose() 
        {
            Health.UnSubscribeOnChange(GetDeadState);
            State.UnSubscribeOnChange(OnChangeEnemyState);
            UpdateManager.Instance.UnSunscribeToFixedUpdate(Execute);
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
            }
        }

        private void OnChangeEnemyState() 
        {
            switch (State.Value) 
            {
                case EnemyState.Active:
                    break;
                case EnemyState.Born:
                    SetDirection();
                    break;
                case EnemyState.Dead:
                    break;
                case EnemyState.Deactive:
                    DeInit();
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
        private void SetDirection() 
        {
            Direction.Value = new Vector3(Random.Range(-1f, 2f), 0, Random.Range(-1f, 2f));
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
        public void OnChangeHealth(int i)
        {
            Health.Value -= i;
        }
        public void OnChangeDirection()
        {
            Direction.Value = new Vector3(Direction.Value.x * -1, 0, Direction.Value.z * -1);
        }
    }
}