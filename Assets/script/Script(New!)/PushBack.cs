using UnityEngine;

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

            // ✅ Apply main directional force
            rb.AddForce(forceDirection * currentForce * 10);

            // ✅ Apply horizontal boost if force > 5
            if (currentForce > 5f)
            {
                // Add a horizontal "boost" — can tweak boostMultiplier
                float boostMultiplier = 500f;
                Vector2 horizontalBoost = new Vector2(forceDirection.x * currentForce * boostMultiplier, 0f);
                rb.AddForce(horizontalBoost, ForceMode2D.Impulse);

                Debug.Log($"Boost applied! Force={currentForce}, Boost={horizontalBoost}");
            }
        }
    }
}
