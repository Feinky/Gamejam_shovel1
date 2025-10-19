using UnityEngine;

public class AccessGetPositions : MonoBehaviour
{
    public float frictionForce;
    private Vector3 lastCursorPosition; 
    public GetPositions getPositionsScript;
    public CollisionDetector Collidebool;// Assign in Inspector or dynamically
    public Rigidbody2D rb;                    // Rigidbody2D to apply force on

    void Start()
    {
        if (getPositionsScript == null)
        {
            getPositionsScript = FindObjectOfType<GetPositions>();
        }
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        if (getPositionsScript == null)
        {
            //Debug.LogError("GetPositions script not found!");
        }

        if (rb == null)
        {
           // Debug.LogError("Rigidbody2D component not found!");
        }
    }

    void Update()
    {
        if(Collidebool.isColliding)
        {
            Vector3 currentCursorPos = Input.mousePosition;
           // Debug.Log($" Is collide!!!!!");
            // Calculate horizontal movement of cursor
            float deltaX = currentCursorPos.x - lastCursorPosition.x;

            // Small threshold to avoid noise
            if (Mathf.Abs(deltaX) > 0.01f)
            {
                // Rigidbody2D component
                Rigidbody2D rb = GetComponent<Rigidbody2D>();

                if (rb != null)
                {
                    // Normalize direction: right = +1, left = -1
                    float direction = Mathf.Sign(deltaX);

                    // Apply force to the Rigidbody2D horizontally (friction-like)
                        // You can adjust this force value
                    rb.AddForce(new Vector2(direction * frictionForce, 0f));
                }
            }

            lastCursorPosition = currentCursorPos;  // Update for next frame

        }
        if (getPositionsScript != null && rb != null)
        {
            float currentForce = getPositionsScript.force;
            float angleDegrees = getPositionsScript.GetAngleToTarget();

            // Fix for reversed angle: subtract from 360 to flip direction
            float correctedAngleDegrees = (360f - angleDegrees) % 360f;

            // Convert corrected angle to radians for math functions
            float angleRadians = correctedAngleDegrees * Mathf.Deg2Rad;

            // Calculate force direction vector using corrected angle
            Vector2 forceDirection = new Vector2(-Mathf.Cos(angleRadians), Mathf.Sin(angleRadians));

            // Flip X direction to reverse left and right force
             
            // Apply force along the corrected direction, scaled by force magnitude
            rb.AddForce(forceDirection * currentForce * 10);

            //Debug.Log($"Applied force {currentForce} in direction {forceDirection} (angle corrected: {correctedAngleDegrees} degrees)");
        }
    }
}
