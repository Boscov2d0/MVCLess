using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = nameof(EnemyProfile), menuName = "Setings/" + nameof(EnemyProfile))]
    public class EnemyProfile : ScriptableObject
    {
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float TimeToBirth { get; private set; }
        [field: SerializeField] public float TimeToDeath { get; private set; }
    }
}