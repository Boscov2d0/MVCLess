using UnityEngine;

namespace Game
{
    internal class EntryPoint : MonoBehaviour
    {
        [SerializeField] private GameSceneSettings _sceneSettings;
        [SerializeField] private Transform _containerUi;

        private MainController _mainController;

        private void Start()
        {
            GameModel gameModel = new GameModel(_sceneSettings.GameState, _sceneSettings.Score);
            _mainController = new MainController(_containerUi, gameModel);
        }

        private void OnDestroy()
        {
            _mainController.Dispose();
        }
    }
}