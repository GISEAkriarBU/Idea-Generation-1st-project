using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 3, -8);
    public float smoothTime = 0.15f;

    Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (!target) return;

        Vector3 targetPos = target.position + offset;
        targetPos.z = transform.position.z; // ล็อก Z สำหรับ 2.5D

        transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPos,
            ref velocity,
            smoothTime
        );
    }
}
