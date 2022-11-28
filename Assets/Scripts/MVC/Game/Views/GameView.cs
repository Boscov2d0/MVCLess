using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game
{
    internal class GameView : MonoBehaviour
    {
        [field: SerializeField] public Text TextScore { get; private set; }
        [field: SerializeField] public Button ButtonPause { get; private set; }
        private SubscriptionPropertyWhithParameter<int> _score;


        public void Init(UnityAction pause, SubscriptionPropertyWhithParameter<int> score)
        {
            ButtonPause.onClick.AddListener(pause);
            _score = score;
            _score.SunscribeOnChange(ShowScore);
        }

        private void ShowScore(int value) 
        {
            TextScore.text = value.ToString();
        }
        private void OnDestroy()
        {
            ButtonPause.onClick.RemoveAllListeners();
        }
    }
}