using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    internal class MainMenuController : DisposableObject
    {
        private readonly string _resourcePath = "UI/MainMenu/MainPanel";
        private readonly MainMenuView _mainMenuView;
        private readonly MainModel _mainModel;

        public MainMenuController(Transform uiContainer, MainModel mainModel) 
        {
            _mainMenuView = LoadMainMenu(uiContainer);
            AddGameObject(_mainMenuView.gameObject);
            _mainMenuView.Init(PlayGame, OpenSettings, ExitGame);

            _mainModel = mainModel;
        }
        private MainMenuView LoadMainMenu(Transform uiContainer) 
        {
            MainMenuView mainMenuViewPrefab = Resources.Load<MainMenuView>(_resourcePath);
            return GameObject.Instantiate(mainMenuViewPrefab, uiContainer, false);
        }

        private void PlayGame() => SceneManager.LoadScene(1);

        private void OpenSettings() =>
            _mainModel.CurrentState.Value = MainMenuState.Settings;
        private void ExitGame() => Application.Quit();
    }
}