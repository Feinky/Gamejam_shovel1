using UnityEngine;
using UnityEngine.Rendering;

public class AccessGetPositions : MonoBehaviour
{
    public float frictionForce;
    private Vector3 lastCursorPosition;
    public GetPositions getPositionsScript;
    public CollisionDetector Collidebool;
    public Rigidbody2D rb;

    void Start()
    {
        if (getPositionsScript == null)
            getPositionsScript = FindObjectOfType<GetPositions>();

        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Collidebool.isColliding)
        {
            Vector3 currentCursorPos = Input.mousePosition;
            float deltaX = currentCursorPos.x - lastCursorPosition.x;

            if (Mathf.Abs(deltaX) > 0.01f)
            {
                float direction = Mathf.Sign(deltaX);
                rb.AddForce(new Vector2(direction * frictionForce, 0f));
            }

            lastCursorPosition = currentCursorPos;
        }

        if (getPositionsScript != null && rb != null)
        {
            float currentForce = getPositionsScript.force;
            float angleDegrees = getPositionsScript.GetAngleToTarget();

            float correctedAngleDegrees = (360f - angleDegrees) % 360f;
            float angleRadians = correctedAngleDegrees * Mathf.Deg2Rad;

            Vector2 forceDirection = new Vector2(-Mathf.Cos(angleRadians), Mathf.Sin(angleRadians));
            if (angleRadians > 0 && angleRadians < 1.4 || angleRadians > 4.4 && angleRadians < 6)
            {
                rb.AddForce(new Vector2(currentForce * -1f * 200, 0f), ForceMode2D.Force); // push right
                Debug.Log("Pushing right");

            }
            if (angleRadians > 1.4 && angleRadians < 4.4)
            {
                rb.AddForce(new Vector2(currentForce * 1f * 200, 0f), ForceMode2D.Force); // push right
                Debug.Log("Pushing left");
            }
                // ✅ Apply main directional force
                rb.AddForce(forceDirection * currentForce * 25);

             
        }
    }
}
