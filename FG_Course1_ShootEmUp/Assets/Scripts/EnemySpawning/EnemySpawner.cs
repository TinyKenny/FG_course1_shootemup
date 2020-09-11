using UnityEngine;

namespace ShootEmUp
{
    
    public class EnemySpawner : MonoBehaviour
    {

        [SerializeField] private GameObject enemyPrefab = null;
        [SerializeField] private EnemySpawnTableEntry[] spawnTable = null;

        private float spawnValueCap = 0.0f;

        private void Awake()
        {
            foreach (EnemySpawnTableEntry entry in spawnTable)
            {
                entry.Initialize();
                spawnValueCap += entry.GetSpawnValue();
            }
        }

        private void Update()
        {
            // TODO list (or similar) of active enemies
            // TODO automatic spawning
            if (Input.GetKeyDown(KeyCode.O))
            {
                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            bool enemySpawned = false;
            float spawnValue = Random.Range(0.0f, spawnValueCap);
            float entrySpawnValue = 0.0f;

            foreach (EnemySpawnTableEntry entry in spawnTable)
            {
                entrySpawnValue = entry.GetSpawnValue();
                if (enemySpawned || entrySpawnValue <= 0.0f)
                {
                    spawnValueCap += entry.IncrementSpawnValue();
                    continue;
                }

                spawnValue -= entrySpawnValue;
                if (spawnValue <= 0.0f)
                {
                    enemySpawned = true;
                    spawnValueCap -= entry.ResetSpawnValue();
                    // TODO variation in spawn positions
                    ObjectPoolManager.GetPooledObject(entry.GetPrefab(), Vector3.zero, Quaternion.identity);
                    
                }
                else
                {
                    spawnValueCap += entry.IncrementSpawnValue();
                }
            }
        }
    }
}
