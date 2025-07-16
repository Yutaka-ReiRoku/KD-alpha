using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTime;
    
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnTime);
    }

    void SpawnEnemy()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
