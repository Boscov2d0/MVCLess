using UnityEngine;

namespace Game
{
    internal class GameModel
    {
        public readonly SubscriptionProperty<GameState> CurrentState;
        public readonly SubscriptionProperty<int> Score;
        public readonly SubscriptionProperty<bool> GameIsPause;
        public SubscriptionProperty<int> CountOfEnemy;
        private int _condition = 0;

        public GameModel() 
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentState.Value = GameState.Game;

            Score = new SubscriptionProperty<int>();
            Score.Value = 0;

            GameIsPause = new SubscriptionProperty<bool>();
            GameIsPause.SunscribeOnChangeWhithParameter(SetGamePause);
            GameIsPause.Value = false;

            CountOfEnemy = new SubscriptionProperty<int>();
            CountOfEnemy.SunscribeOnChangeWhithParameter(GetGameCondition);
        }

        public void GetGameCondition(int count) 
        {
            if (count <= _condition) 
            {
                CurrentState.Value = GameState.Lose; 
            }
        }
        public void SetGamePause(bool b) 
        {
            if (b == true)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }
        public void IncreaseScore() =>
            Score.Value++;

        public void Dispose() 
        {
            GameIsPause.UnSubscribeOnChangeWhithParameter(SetGamePause);
            CountOfEnemy.UnSubscribeOnChangeWhithParameter(GetGameCondition);
        }
    }
}