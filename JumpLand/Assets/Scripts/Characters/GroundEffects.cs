using UnityEngine;

public class GroundEffects : MonoBehaviour
{
    [Header("Dependencies")]
    public Rigidbody2D rb;


    public void ElasticGround(float bounce)
    {
        rb.AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
        if (rb.velocity.magnitude > bounce)
            rb.velocity = Vector2.up * bounce;
    }
}

