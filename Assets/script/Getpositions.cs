using UnityEngine;

public class GetPositions : MonoBehaviour
{
    public GameObject objectA;  // Assign in inspector or dynamically
    public GameObject objectB;

    void Update()
    {
        Vector2 posA = new Vector2(objectA.transform.position.x, objectA.transform.position.y);
        Vector2 posB = new Vector2(objectB.transform.position.x, objectB.transform.position.y);

        Debug.Log("Object A Position: " + posA);
        Debug.Log("Object B Position: " + posB);

        // You can now use posA.x, posA.y, posB.x, posB.y for any logic you want
    }
}