using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MainMenu.Settings
{
    internal class SettingsView : MonoBehaviour
    {
        [field: SerializeField] public Button ButtonBack;

        public void Init(UnityAction back)
        {
            ButtonBack.onClick.AddListener(back);
        }
    }
}