using UnityEngine;

public class TransformPickup : MonoBehaviour
{
    bool used = false;

    void OnTriggerEnter(Collider other)
    {
        if (used) return;

        PlayerTransform player = other.GetComponent<PlayerTransform>();
        if (player != null)
        {
            used = true;              // 🔒 ล็อกทันที
            player.ActivateTransform();
            Destroy(gameObject);      // หรือ Disable collider
        }
    }
}
