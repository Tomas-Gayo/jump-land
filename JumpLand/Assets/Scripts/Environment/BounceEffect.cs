using UnityEngine;

public class BounceEffect : MonoBehaviour
{
    public float bounciness = 10.0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out GroundEffects ground))
        {
            Vector2 normal = -collision.GetContact(0).normal;

            if (CompareNormal(normal, collision.collider.gameObject))
                ground.ElasticGround(bounciness);
        }
    }

    bool CompareNormal(Vector2 contactPoint, GameObject player)
    {
        float dtProduct = Vector2.Dot(contactPoint, player.transform.up);
        return dtProduct > 0;
    }
}
