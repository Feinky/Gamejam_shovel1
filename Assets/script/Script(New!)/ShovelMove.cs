using System.Diagnostics;
using UnityEngine;
using System.Collections;

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
            UnityEngine.Debug.Log("Slowed");

            // Freeze in place for a few frames
           
        }

        Vector2 targetPosition = target.position;

        // Smoothly move rigidbody towards target position
        Vector2 newPos = Vector2.MoveTowards(rb.position, targetPosition, moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
    }
     
}
