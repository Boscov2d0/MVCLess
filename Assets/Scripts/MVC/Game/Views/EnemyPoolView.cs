using Game.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    internal class EnemyPoolView : MonoBehaviour
    {
        [field: SerializeField] public List<EnemyView> Enemies { get; private set; }
    }
}