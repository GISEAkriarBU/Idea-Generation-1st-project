using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int hp = 1;
    public int scoreValue = 10;

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // เพิ่ม Score
        ScoreManager.Instance?.AddScore(scoreValue);

        Destroy(gameObject);
    }
}
