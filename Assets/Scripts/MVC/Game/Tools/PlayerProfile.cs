using UnityEngine;

namespace Game.Player
{
    [CreateAssetMenu(fileName = nameof(PlayerProfile), menuName = "Setings/" + nameof(PlayerProfile))]
    public class PlayerProfile : ScriptableObject
    {
        [field: SerializeField] public int Power { get; private set; }
    }
}