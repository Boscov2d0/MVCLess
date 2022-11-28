using MainMenu.Settings;
using UnityEngine;

namespace MainMenu
{
    internal class MainController : DisposableObject
    {
        private readonly Transform _placeForUi;

        private MainModel _mainModel;
        private MainMenuController _mainMenuController;
        private SettingsController _settingsController;

        public MainController(Transform placeForUi)
        {
            _placeForUi = placeForUi;
            _mainModel = new MainModel();

            _mainModel.CurrentState.SunscribeOnChange(OnChangeGameState);
            OnChangeGameState(_mainModel.CurrentState.Value);
        }

        protected override void OnDispose()
        {
            DisposeObjects();
        }


        private void OnChangeGameState(MainMenuState state)
        {
            DisposeObjects();

            switch (state)
            {
                case MainMenuState.MainMenu:
                    _mainMenuController = new MainMenuController(_placeForUi, _mainModel);
                    break;
                case MainMenuState.Settings:
                    _settingsController = new SettingsController(_placeForUi, _mainModel);
                    break;
            }
        }

        private void DisposeObjects()
        {
            _mainMenuController?.Dispose();
            _settingsController?.Dispose();
        }
    }
}