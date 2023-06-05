using ScriptableObjectArchitecture;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerDead : MonoBehaviour
{
    [Header("Config.")]
    [SerializeField] private float timeBeforeDie;

    [Header("Dependencies")]
    [SerializeField] private PlayerInput input;

    [Header("Events")]
    [SerializeField] private UnityEvent onDead;

    [Header("Broadcasting On")]
    [SerializeField] private GameEvent gameOverEvent;

    bool isDead = false;
    public void SendKillEvent() => StartCoroutine(KillPlayer());

    IEnumerator KillPlayer()
    {
        if (!isDead)
        {
            isDead = true;
            input.enabled = false;
            onDead!.Invoke();

            yield return new WaitForSeconds(timeBeforeDie);

            gameOverEvent!.Raise();
        }
    }
    
}
