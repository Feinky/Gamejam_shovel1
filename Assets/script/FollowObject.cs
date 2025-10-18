using UnityEngine;

public class AttachToObject : MonoBehaviour
{
    public Transform target;  // Assign the object to follow

    void Start()
    {
        if (target != null)
        {
            // Set this object as child of the target
            transform.SetParent(target, worldPositionStays: false);
            // worldPositionStays false means local position resets relative to parent
        }
    }
}