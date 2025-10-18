using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public bool isColliding = false;  // Public bool to indicate collision state

    // Called when this object's collider starts colliding with another collider
    void OnCollisionEnter2D(Collision2D collision)
    {
        // You can add filter for specific tags if needed:
        // if (collision.gameObject.tag == "Solid")
        isColliding = true;
        //Debug.Log("Collision detected with: " + collision.gameObject.name);
    }

    // Called while this object's collider stays in contact with another collider
    void OnCollisionStay2D(Collision2D collision)
    {
        isColliding = true;
    }

    // Called when this object's collider stops colliding
    void OnCollisionExit2D(Collision2D collision)
    {
        isColliding = false;
        //.Log("Collision ended with: " + collision.gameObject.name);
    }
}
