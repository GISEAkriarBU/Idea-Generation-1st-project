using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float fireRate = 1f;
    public float range = 10f;
    public bool tripleShot = false;
    public float spreadAngle = 15f;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= fireRate)
        {
            Shoot();
            timer = 0;
        }

    }

    void Shoot()
    {
        GameObject target = FindNearestEnemy();
        if (!target) return;

        Vector3 dir = target.transform.position - transform.position;
        dir.y = 0; // ยิงบนระนาบ 2.5D

        GameObject proj = Instantiate(
            projectilePrefab,
            transform.position + Vector3.up * 1f,
            Quaternion.identity
        );

        proj.GetComponent<Projectile>().SetDirection(dir);

    }

    GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearest = null;
        float minDist = Mathf.Infinity;

        foreach (GameObject e in enemies)
        {
            float dist = Vector3.Distance(transform.position, e.transform.position);
            if (dist < minDist && dist <= range)
            {
                minDist = dist;
                nearest = e;
            }
        }

        return nearest;
    }
    
}
