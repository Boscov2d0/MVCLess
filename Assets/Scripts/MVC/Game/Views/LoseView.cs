using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game
{
    internal class LoseView : MonoBehaviour
    {
        [field: SerializeField] public Text TextCsore;
        [field: SerializeField] public Button ButtonMenu;
        [field: SerializeField] public Button ButtonRestart;

        public void Init(UnityAction menu, UnityAction restart)
        {
            ButtonRestart.onClick.AddListener(menu);
            ButtonRestart.onClick.AddListener(restart);
        }
        public void Deinit()
        {
            ButtonRestart.onClick.RemoveAllListeners();
            ButtonRestart.onClick.RemoveAllListeners();
        }
        public void ShowScore(string text) 
        {
            TextCsore.text = text;
        }
    }
}