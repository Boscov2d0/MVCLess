using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Lose
{
    internal class LoseModel
    {
        public LoseModel() { }

        public void PauseOn()
        {
            Time.timeScale = 0;
        }
        public void PauseOff()
        {
            Time.timeScale = 1;
        }
    }
}