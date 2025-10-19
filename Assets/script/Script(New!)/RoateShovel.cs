using UnityEngine;

public class RotateOnClick : MonoBehaviour
{
    public float rotationAngle = 90f; // degrees per click

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // 0 = left click
        {
            transform.Rotate(0f, 0f, rotationAngle);
        }
    }
}
