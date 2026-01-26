using UnityEngine;

public class StructureSpaening : MonoBehaviour
{   
    public GameObject StructurePrefab;
    public Transform Player;
    public GameObject[] STructurePrefab;

    public float spawnRadius = 12f;
    public float spawnInterval = 1.5f;
    public int maxStructure = 10;
    

    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval && StructureCount() < maxStructure)
        {
            SpawnStructure();
            timer = 0;
        }

        
    }

    void SpawnStructure()
    {
        Vector3 randomDir = Random.insideUnitSphere;
        randomDir.y = 0;
        randomDir.Normalize();

        Vector3 spawnPos = Player.position + randomDir * spawnRadius;

        Instantiate(StructurePrefab, spawnPos, Quaternion.identity);

        //EnemyType
        //Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)],spawnPos,Quaternion.identity);
    }

    int StructureCount()
    {
        return GameObject.FindGameObjectsWithTag("Structure").Length;
    }
    
}
