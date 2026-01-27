using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    //public GameObject enemyPrefab;
    public Transform player;
    public GameObject[] enemyPrefabs;

    public float spawnRadius = 12f;
    public float spawnInterval = 1.5f;
    public int maxEnemies = 50;
    //float difficultyTimer;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval && EnemyCount() < maxEnemies)
        {
            SpawnEnemy();
            timer = 0;
        }

        //difficultyUpTime
        //difficultyTimer += Time.deltaTime;

        //spawnInterval = Mathf.Max(0.3f, 1.5f - difficultyTimer * 0.02f);
    }

    void SpawnEnemy()
    {
        Vector3 randomDir = Random.insideUnitSphere;
        randomDir.y = 0;
        randomDir.Normalize();

        Vector3 spawnPos = player.position + randomDir * spawnRadius;

        //Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

        //EnemyType
        Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], spawnPos, Quaternion.identity);
    }

    int EnemyCount()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
    
}
