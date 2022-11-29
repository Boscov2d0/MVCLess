using System;
using UnityEngine;

namespace Game.Enemy
{
    internal class EnemyView : MonoBehaviour
    {
        private SubscriptionProperty<EnemyState> _state;

        [field: SerializeField] public Transform Transform { get; private set; }
        [field: SerializeField] public GameObject Body { get; private set; }
        [field: SerializeField] public GameObject BirthEffect { get; private set; }
        [field: SerializeField] public GameObject DeathEffect { get; private set; }


        public Action OnCollisionEnterAction;
        public Action<int> OnClickAction;

        public Vector3 Direction;
        public float Speed;

        public void Init(SubscriptionProperty<EnemyState> state)
        {
            _state = state;
            _state.SunscribeOnChangeWhithParameter(OnChangeEnemyState);
        }
        private void OnChangeEnemyState(EnemyState state)
        {
            switch (state)
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
        public void OnClick(int i)
        {
            if (_state.Value == EnemyState.Born)
            {
                OnClickAction?.Invoke(i);
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
        public void Move() =>
            Transform.position += new Vector3(Direction.x * Speed, 0, Direction.z * Speed);

        private void FixedUpdate() =>
            Move();

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
        private void OnDestroy()
        {
            _state.SunscribeOnChangeWhithParameter(OnChangeEnemyState);
        }
    }
}