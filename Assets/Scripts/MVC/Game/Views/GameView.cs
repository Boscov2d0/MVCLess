using Game.Enemy;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game
{
    internal class GameView : MonoBehaviour
    {
        [field: SerializeField] public Text TextScore { get; private set; }
        private SubscriptionProperty<int> _score;

        [field: SerializeField] public List<EnemyView> Enemies { get; private set; }

        public void Init(UnityAction pause, SubscriptionProperty<int> score)
        {
            _score = score;
            _score.SunscribeOnChangeWhithParameter(ShowScore);
        }
        private void ShowScore(int value) =>
            TextScore.text = value.ToString();

        private void OnDestroy()
        {
            _score.UnSubscribeOnChangeWhithParameter(ShowScore);
            Enemies.Clear();
        }
    }
}