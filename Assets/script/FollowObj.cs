using UnityEngine;

public class FollowTargetDirection : MonoBehaviour
{
    public Transform target;
    public float rotateSpeed = 5f;

    void Update()
    {
        if (target == null) return;

        // �p���V
        Vector2 direction = (target.position - transform.position).normalized;

        // �p�⨤�ס]�ন�׼ơ^
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // ���Ʊ���¦V�ؼФ�V
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);
    }
}
