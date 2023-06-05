using UnityEngine;
using ScriptableObjectArchitecture;

[RequireComponent(typeof(Animator))]
public class LoadingScreenUI : MonoBehaviour
{
    [Header("Broadcasting on")]
    [SerializeField] private BoolGameEvent loadingScreenToggled;

    Animator animator;

    private void Awake() => animator = GetComponent<Animator>();

    public void ToggleScreen(bool enable)
    {
        if (enable)
            animator.SetTrigger("Show");
        else
            animator.SetTrigger("Hide");
    }

    public void TriggerToggleScreenHide() => loadingScreenToggled?.Raise(false);

    public void TriggerToggleScreenShow() => loadingScreenToggled?.Raise(true);
}
