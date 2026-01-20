using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 3f;
    public int damage = 1;

    Vector3 direction;

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // ตัวอย่าง
            // other.GetComponent<EnemyHealth>()?.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
