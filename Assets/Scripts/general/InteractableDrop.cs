using UnityEngine;

public class InteractableDrop : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform dropPoint;

    public void Interact()
    {
        SpawnItem();
        Destroy(gameObject);
    }

    void SpawnItem()
    {
        Instantiate(
            itemPrefab,
            dropPoint != null ? dropPoint.position : transform.position,
            Quaternion.identity
        );
    }
}
