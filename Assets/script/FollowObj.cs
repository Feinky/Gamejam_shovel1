using UnityEngine;

public class FollowTargetDirection : MonoBehaviour
{
    public Transform target;
    public float rotateSpeed = 5f;

    void Update()
    {
        if (target == null) return;

        // 計算方向
        Vector2 direction = (target.position - transform.position).normalized;

        // 計算角度（轉成度數）
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 平滑旋轉朝向目標方向
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);
    }
}
