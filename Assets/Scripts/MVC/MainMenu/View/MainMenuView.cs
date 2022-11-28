using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MainMenu
{
    internal class MainMenuView : MonoBehaviour
    {
        [field: SerializeField] public Button ButtonPlay;
        [field: SerializeField] public Button ButtonSettings;
        [field: SerializeField] public Button ButtonExit;

        public void Init(UnityAction play, UnityAction openSettings, UnityAction exit)
        {
            ButtonPlay.onClick.AddListener(play);
            ButtonSettings.onClick.AddListener(openSettings);
            ButtonExit.onClick.AddListener(exit);
        }
    }
}