using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float fireRate = 1f;
    public float range = 10f;
    public bool tripleShot = false;
    public float spreadAngle = 15f;

    float timer;
    [Header("Sound")]
    [SerializeField] private AudioSource shootAudio;
    [SerializeField] private AudioClip shootClip;
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
        dir.y = 0;

        GameObject proj = Instantiate(
            projectilePrefab,
            transform.position + Vector3.up * 1f,
            Quaternion.identity
        );

        proj.GetComponent<Projectile>().SetDirection(dir);

        // 🔊 เล่นเสียงยิง
        if (shootAudio != null && shootClip != null)
        {
            shootAudio.PlayOneShot(shootClip);
        }
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
