using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 10;
    public int currentHP;

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log("Player HP = " + currentHP);

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("PLAYER DEAD");
        // Destroy(gameObject); // เปิดทีหลัง
    }
}
