using UnityEngine;
using UnityEngine.Events;

public class CollisionChecker : MonoBehaviour
{
    [Tooltip("The tag of the object that the collider is going to check.")]
    [SerializeField] private string tagName;

    [Header("Events")]
    public UnityEvent onCollisionEnter;
    public UnityEvent onCollisionExit;
    public UnityEvent onCollisionStay;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagName))
            onCollisionEnter?.Invoke();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagName))
            onCollisionExit?.Invoke();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagName))
            onCollisionStay?.Invoke();
    }
}
