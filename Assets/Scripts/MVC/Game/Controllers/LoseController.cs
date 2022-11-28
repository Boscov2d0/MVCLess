using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Lose
{
    internal class LoseController : DisposableObject
    {
        private readonly string _resourceCameraPlayerViewPath = "UI/Game/LosePanel";
        private readonly LoseView _loseView;
        private readonly LoseModel _loseModel;
        public LoseController(Transform uiContainer)
        {
            _loseView = LoadLoseView(uiContainer);
            AddGameObject(_loseView.gameObject);
            _loseView.Init(ToMainMenu, RestartGame);

            _loseModel = new LoseModel();
        }
        private LoseView LoadLoseView(Transform uiContainer) 
        {
            LoseView loseViewPrefab = Resources.Load<LoseView>(_resourceCameraPlayerViewPath);
            return GameObject.Instantiate(loseViewPrefab, uiContainer, false);
        }
        private void ToMainMenu() =>
            SceneManager.LoadScene(0);

        private void RestartGame() =>
            SceneManager.LoadScene(1);
    }
}