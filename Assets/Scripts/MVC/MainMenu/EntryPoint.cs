using UnityEngine;

namespace MainMenu
{
    internal class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Transform _placeForUi;

        private MainController _mainController;


        private void Start()
        {
            _mainController = new MainController(_placeForUi);
        }

        private void OnDestroy()
        {
            _mainController.Dispose();
        }
    }
}