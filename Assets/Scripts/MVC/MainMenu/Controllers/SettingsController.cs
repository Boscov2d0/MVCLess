using UnityEngine;

namespace MainMenu.Settings
{
    internal class SettingsController : DisposableObject
    {
        private readonly string _resourcePath = "UI/MainMenu/SettingsPanel";
        private readonly SettingsView _settingsView;
        private readonly MainModel _mainModel;

        public SettingsController(Transform uiContainer, MainModel mainModel) 
        {
            _settingsView = LoadSettingsView(uiContainer);
            AddGameObject(_settingsView.gameObject);
            _settingsView.Init(OpenMainMenu);

            _mainModel = mainModel;
        }
        private SettingsView LoadSettingsView(Transform uiContainer)
        {
            SettingsView settingsViewPrefab = Resources.Load<SettingsView>(_resourcePath);
            return GameObject.Instantiate(settingsViewPrefab, uiContainer, false);
        }
        private void OpenMainMenu() => 
            _mainModel.CurrentState.Value = MainMenuState.MainMenu;
    }
}