using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    [field: SerializeField] public Text PointsText { get; private set; }
    [field: SerializeField] public Button ButtonPause { get; private set; }
}