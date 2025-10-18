using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public float moveSpeed = 10f;  // Speed of following

    void Update()
    {
        // Get mouse position in world coordinates
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Move object towards mouse position at moveSpeed
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);
    }
}