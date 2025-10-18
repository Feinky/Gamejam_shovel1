using UnityEngine;

public class CircularBoundary : MonoBehaviour
{
    public Transform centerObject;  // Assign via Inspector (the object that defines the circle center)
    public float radius = 5f;       // Radius of the boundary

    void Update()
    {
        if (centerObject == null) return;

        Vector2 center = centerObject.position;
        Vector2 pos = transform.position;
        Vector2 directionFromCenter = pos - center;

        // Clamp position if outside radius
        if (directionFromCenter.magnitude > radius)
        {
            Vector2 clampedPos = center + directionFromCenter.normalized * radius;
            transform.position = new Vector3(clampedPos.x, clampedPos.y, transform.position.z);
        }
    }
}
