using UnityEngine;

public class GetPositions : MonoBehaviour
{
    public GameObject objectA;
    public GameObject objectB;
    public float force;  // Public field
    public float GetAngleToTarget()
    {
        Vector2 direction = (objectB.transform.position - objectA.transform.position);
        return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }

    public Vector2 GetDirectionToTarget()
    {
        Vector2 direction = (objectB.transform.position - objectA.transform.position).normalized;
        return direction;
    }
    void DebugDirectionAngle()
    {
        Vector3 posA = objectA.transform.position;
        Vector3 posB = objectB.transform.position;

        Vector3 direction = (posB - posA).normalized;

        // Calculate angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Draw a ray in the Scene view to visualize direction
        Debug.DrawRay(posA, direction * 2f, Color.yellow);

        // Log angle in console
       // Debug.Log($"Direction Angle from A to B: {angle} degrees");
    }
    void Update()
    {
        //DebugDirectionAngle();
        Vector2 posA = new Vector2(objectA.transform.position.x, objectA.transform.position.y);
        Vector2 posB = new Vector2(objectB.transform.position.x, objectB.transform.position.y);

        // Update the public field, do NOT re-declare it locally
        force = ((posA.x - posB.x) * (posA.x - posB.x) + (posA.y - posB.y) * (posA.y - posB.y));

        //Debug.Log("Object A Position: " + posA + ", Object B Position: " + posB + ", Force: " + force);
    }

    // Added function to get angle in degrees from A to B and direction vector
     
}
