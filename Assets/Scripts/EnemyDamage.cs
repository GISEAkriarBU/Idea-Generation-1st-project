using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 1;
    public float hitCooldown = 1f;

    float lastHitTime;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Time.time - lastHitTime >= hitCooldown)
            {
                other.GetComponent<PlayerHealth>()?.TakeDamage(damage);
                lastHitTime = Time.time;
            }
        }
    }
}
