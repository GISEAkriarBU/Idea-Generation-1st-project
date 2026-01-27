using UnityEngine;

public class TransformPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerTransform>()?.ActivateTransform();
            Destroy(gameObject);
        }
    }
}
