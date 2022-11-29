using UnityEngine;

namespace Game
{
    internal class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Transform _containerUi;
        private GameController _gameController;

        private void Start()
        {
            GameModel gameModel = new GameModel();
            _gameController = new GameController(_containerUi, gameModel);
        }

        private void OnDestroy()
        {
            _gameController?.Dispose();
        }
    }
}