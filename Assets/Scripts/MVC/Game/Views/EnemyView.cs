using System;
using UnityEngine;

namespace Game.Enemy
{
    internal class EnemyView : MonoBehaviour 
    {
        [field: SerializeField] public Transform Transform { get; private set; }
        [field: SerializeField] public GameObject Body { get; private set; }
        [field: SerializeField] public GameObject BirthEffect { get; private set; }
        [field: SerializeField] public GameObject DeathEffect { get; private set; }

        public SubscriptionProperty<EnemyState> State = new SubscriptionProperty<EnemyState>();
        public Action OnCollisionEnterAction;
        public Action<int> OnClickAction;

        public Vector3 Direction;
        public float Speed;

        public void Init(SubscriptionProperty<EnemyState> state)
        {
            State = state;
            State.Value = EnemyState.Deactive;

            State.SubscribeOnChange(OnChangeEnemyState);
            UpdateManager.Instance.SunscribeToFixedUpdate(Execute);
        }
        public void Deinit() 
        {
            State.UnSubscribeOnChange(OnChangeEnemyState);
            UpdateManager.Instance.UnSunscribeToFixedUpdate(Execute);
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.tag == "Border") 
            {
                OnCollisionEnterAction?.Invoke();
            }
            if (collision.transform.TryGetComponent(out EnemyView enemy))
            {
                OnCollisionEnterAction?.Invoke();
            }
        }
        public void OnClick(int i) 
        {
            OnClickAction?.Invoke(i);
        }

        private void Execute()
        {
            if (State.Value == EnemyState.Born) 
            {
                Move();
            }
        }

        public void OnChangeEnemyState()
        {
            switch (State.Value)
            {
                case EnemyState.Active:
                    Activation();
                    break;
                case EnemyState.Born:
                    Birth();
                    break;
                case EnemyState.Dead:
                    Death();
                    break;
                case EnemyState.Deactive:
                    DeActive();
                    break;
            }
        }
        public void Activation() 
        {
            gameObject.SetActive(true);
            BirthEffect.SetActive(true);
        }
        public void Birth() 
        {
            Body.SetActive(true);
            BirthEffect.SetActive(false);
        }
        public void Death() 
        {
            Body.SetActive(false);
            DeathEffect.SetActive(true);
        }
        public void DeActive() 
        {
            gameObject.SetActive(false);
            DeathEffect.SetActive(false);
        }
        public void Move()
        {
            Transform.position += new Vector3(Direction.x * Speed, 0, Direction.z * Speed);
        }
    }
}