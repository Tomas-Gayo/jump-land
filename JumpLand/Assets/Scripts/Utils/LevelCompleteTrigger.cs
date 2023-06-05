using UnityEngine;
using UnityEngine.Events;
using ScriptableObjectArchitecture;

public class LevelCompleteTrigger : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private UnityEvent onCompleteLevel;
    [Header("Broadcasting On")]
    [SerializeField] private GameEvent levelCompleteEvent;

    bool triggered = false;

    public void SendLevelCompleteEvent()
    {
        if (!triggered)
        {
            onCompleteLevel!.Invoke();
            levelCompleteEvent!.Raise();
            triggered = true;
        }
    }
}
