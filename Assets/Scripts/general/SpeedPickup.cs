using UnityEngine;

public class SpeedPickup : MonoBehaviour
{
    public float speedBonus = 5f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerControl pm = other.GetComponent<PlayerControl>();
            if (pm != null)
            {
                pm.AddSpeed(speedBonus);
            }

            Destroy(gameObject);
        }
    }
}
