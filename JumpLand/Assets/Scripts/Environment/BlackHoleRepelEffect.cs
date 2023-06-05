using UnityEngine;

public class BlackHoleRepelEffect : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private float repelForce = 500.0f;
    [SerializeField, Range(0.0f, 5.0f)] private float stayTime = 1.0f;

    float currentTime;

    private void OnTriggerStay2D(Collider2D collision)
    { 
        if (collision.gameObject.CompareTag("Player") && currentTime >= stayTime)
            ApplyForceUp(collision.gameObject);
        else
            currentTime += Time.deltaTime;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
            currentTime = 0;
    }

    void ApplyForceUp(GameObject player)
    {
        Rigidbody2D rb = player.GetComponentInParent<Rigidbody2D>();
        rb.AddForce(Vector2.up * repelForce, ForceMode2D.Force);
    }
}
