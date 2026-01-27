using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 3, -8);
    public float smoothTime = 0.15f;

    Vector3 velocity;
    CameraShake shake;

    void Start()
    {
        shake = GetComponent<CameraShake>();
    }

    void LateUpdate()
    {
        if (!target) return;

        Vector3 targetPos = target.position + offset;

        Vector3 basePos = Vector3.SmoothDamp(
            transform.position,
            targetPos,
            ref velocity,
            smoothTime
        );

        if (shake != null)
            basePos += shake.GetOffset();

        transform.position = basePos;
    }
}
