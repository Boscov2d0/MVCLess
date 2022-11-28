namespace MainMenu
{
    internal class MainModel
    {
        public readonly SubscriptionPropertyWhithParameter<MainMenuState> CurrentState = new SubscriptionPropertyWhithParameter<MainMenuState>();

        public MainModel()
        {
            CurrentState.Value = MainMenuState.MainMenu;
        }
    }
}