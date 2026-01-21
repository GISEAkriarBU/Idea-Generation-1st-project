using UnityEngine;

public class CameraBeU : MonoBehaviour
{
    public Transform target;

    public float smoothTime = 0.2f;

    public float followZStrength = 0.3f; // 0 = ไม่ตาม Z
    public float fixedY = 6f;

    public float minX, maxX;

    Vector3 velocity;

    void LateUpdate()
    {
        if (!target) return;

        Vector3 desired = transform.position;

        // Follow X 
        desired.x = target.position.x;

        // Follow Z 
        desired.z = Mathf.Lerp(
            transform.position.z,
            target.position.z,
            followZStrength
        );

        // HeightLockOnCamera
        desired.y = fixedY;

        // Camera_Left-Right_limit
        desired.x = Mathf.Clamp(desired.x, minX, maxX);

        transform.position = Vector3.SmoothDamp(
            transform.position,
            desired,
            ref velocity,
            smoothTime
        );
    }
}
