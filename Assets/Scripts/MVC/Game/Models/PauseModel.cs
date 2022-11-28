using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Pause
{
    internal class PauseModel
    {
        public PauseModel() { }

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