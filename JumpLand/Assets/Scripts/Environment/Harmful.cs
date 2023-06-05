using ScriptableObjectArchitecture;
using UnityEngine;

public class Harmful : MonoBehaviour
{
    [Header("Broadcasting on")]
    [SerializeField] private GameEvent hitEvent;

    public void SendHitEvent() => hitEvent!.Raise();
}
