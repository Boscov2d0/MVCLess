using UnityEngine;

namespace Game 
{
    [CreateAssetMenu(fileName = nameof(GameSceneSettings), menuName = "Setings/" + nameof(GameSceneSettings))]
    internal class GameSceneSettings : ScriptableObject
    {
        [field : SerializeField] public GameState GameState;
        [field: SerializeField] public int Score;
    } 
}