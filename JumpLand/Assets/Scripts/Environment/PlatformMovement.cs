using System.Collections;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private Transform destination;
    [SerializeField, Range(0, 5.0f)] private float speed = 1.0f;

    // Private references
    Vector3 origin;
    Vector3 target;
    // Private variables
    bool hasArrive;
    float startTime;
    float ptDistance;

    private void Start()
    {
        origin = transform.position;
        target = destination.position;

        startTime = Time.time;
        ptDistance = Vector3.Distance(origin, target);
    }

    private void Update()
    {
        float distanceCovered = (Time.time - startTime) * speed;
        float distInterpolation = distanceCovered / ptDistance;
        if (!hasArrive)
            StartCoroutine(MoveToDestination(distInterpolation));
        else
            StartCoroutine(MoveToOrigin(distInterpolation));
    }

    IEnumerator MoveToDestination(float interpolator)
    {
        transform.position = Vector3.Lerp(origin, target, interpolator);

        while(transform.position != target)
            yield return null;

        hasArrive = true;
        startTime = Time.time;
    }

    IEnumerator MoveToOrigin(float interpolator)
    {
        transform.position = Vector3.Lerp(target, origin, interpolator);

        while (transform.position != origin)
            yield return null;

        hasArrive = false;
        startTime = Time.time;
    }
}
