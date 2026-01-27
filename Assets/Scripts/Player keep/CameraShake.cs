using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeIntensity = 0.1f;

    bool isShaking;
    Vector3 currentOffset;

    public Vector3 GetOffset()
    {
        if (!isShaking) return Vector3.zero;

        Vector3 offset = Random.insideUnitSphere * shakeIntensity;
        offset.z = 0;
        return offset;
    }

    public void StartShake()
    {
        isShaking = true;
    }

    public void StopShake()
    {
        isShaking = false;
    }
}
