using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FollowTargetForce : MonoBehaviour
{
    public Transform target;          // The object to follow
    public float forceAmount = 10f;   // Strength of the force
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (target == null) return; // Safety check

        Vector2 targetPosition = target.position;
        Vector2 direction = (targetPosition - rb.position).normalized;

        // Apply force toward target object
        rb.AddForce(direction * forceAmount);
    }
}
