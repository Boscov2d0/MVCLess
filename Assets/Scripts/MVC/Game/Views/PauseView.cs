using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.Pause
{
    internal class PauseView : MonoBehaviour
    {
        [field: SerializeField] public Button MainMenuButton { get; private set; }
        [field: SerializeField] public Button ContinueButton { get; private set; }

        public void Init(UnityAction toMainMenu, UnityAction continuePlay)
        {
            MainMenuButton.onClick.AddListener(toMainMenu);
            ContinueButton.onClick.AddListener(continuePlay);
        }

        private void OnDestroy()
        {
            MainMenuButton.onClick.RemoveAllListeners();
            ContinueButton.onClick.RemoveAllListeners();
        }
    }
}