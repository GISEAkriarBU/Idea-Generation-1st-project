using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float moveSpeed = 3f;
    Transform player;
    Rigidbody rb;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void FixedUpdate()
    {

        if (!player) return;

        Vector3 dir = player.position - transform.position;
        dir.y = 0; // เดินบนพื้น 2.5D
        dir.Normalize();

        rb.linearVelocity = new Vector3(
            dir.x * moveSpeed,
            rb.linearVelocity.y,
            dir.z * moveSpeed
        );
    }
    void LateUpdate()
    {
        transform.forward = Camera.main.transform.forward;

        if (rb.linearVelocity.x != 0)
            transform.localScale = new Vector3(Mathf.Sign(rb.linearVelocity.x),1,1);
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>()?.TakeDamage(1);
        }
    }
}
