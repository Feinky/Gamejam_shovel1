using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class FollowTargetPhysics : MonoBehaviour
{
    public Rigidbody2D shovelrb;
    public CollisionDetector Collidebool;
    public Transform target;          // Assign target GameObject's Transform here
    public float moveSpeed = 10f;    // Speed to move towards the target
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Collidebool.isColliding)
        {
            //Debug.Log("Slowing down!!!!!");
            shovelrb.linearVelocity = shovelrb.linearVelocity * 0.01f;
        }
        if (target == null) return;

        Vector2 targetPosition = target.position;

        // Smoothly move rigidbody towards target position
        Vector2 newPos = Vector2.MoveTowards(rb.position, targetPosition, moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
    }
}
