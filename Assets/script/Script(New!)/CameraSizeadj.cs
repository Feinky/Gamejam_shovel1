using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraZoomByVelocity : MonoBehaviour
{
    public Rigidbody2D targetRb;   // Assign your player or moving object
    public float baseSize = 5f;    // Default camera size
    public float zoomOutFactor = 0.1f; // How much zoom per unit of velocity
    public float smoothSpeed = 5f; // Smoothing for size change

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        cam.orthographicSize = baseSize;
    }

    void LateUpdate()
    {
        if (targetRb == null) return;

        // Get current speed magnitude
        float speed = targetRb.linearVelocity.magnitude;

        // Calculate target camera size
        float targetSize = baseSize + speed * zoomOutFactor;

        // Smoothly interpolate camera size for smooth zoom
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, Time.deltaTime * smoothSpeed);
    }
}
