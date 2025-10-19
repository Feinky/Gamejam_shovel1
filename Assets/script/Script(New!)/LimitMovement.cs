using UnityEngine;

public class CircularBoundary : MonoBehaviour
{
    public Transform centerObject;  // Assign via Inspector
    public float radiusX = 6f;      // Wider radius along X
    public float radiusY = 5f;      // Normal radius along Y

    void Update()
    {
        if (centerObject == null) return;

        Vector2 center = centerObject.position;
        Vector2 pos = transform.position;
        Vector2 directionFromCenter = pos - center;

        // Clamp position if outside "ellipse"
        float dx = directionFromCenter.x / radiusX;
        float dy = directionFromCenter.y / radiusY;

        if (dx * dx + dy * dy > 1f)
        {
            // Project back onto ellipse
            float angle = Mathf.Atan2(directionFromCenter.y / radiusY, directionFromCenter.x / radiusX);
            float clampedX = Mathf.Cos(angle) * radiusX;
            float clampedY = Mathf.Sin(angle) * radiusY;

            transform.position = new Vector3(center.x + clampedX, center.y + clampedY, transform.position.z);
        }
    }
}
