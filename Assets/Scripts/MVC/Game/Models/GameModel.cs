using UnityEngine;

namespace Game
{
    internal class GameModel
    {
        public readonly SubscriptionPropertyWhithParameter<GameState> CurrentState;
        public readonly SubscriptionPropertyWhithParameter<int> Score;
        public readonly SubscriptionPropertyWhithParameter<bool> GameIsPause;
        private int _condition = 4;

        public GameModel(GameState initialState, int score) 
        {
            CurrentState = new SubscriptionPropertyWhithParameter<GameState>();
            CurrentState.Value = initialState;

            Score = new SubscriptionPropertyWhithParameter<int>();
            Score.Value = score;

            GameIsPause = new SubscriptionPropertyWhithParameter<bool>();
            GameIsPause.SunscribeOnChange(SetGamePause);
            GameIsPause.Value = false;
        }

        public void GetGameCondition(int count) 
        {
            if (count > _condition) 
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
    }
}