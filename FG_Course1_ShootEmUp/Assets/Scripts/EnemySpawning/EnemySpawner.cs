using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Assertions;

namespace ShootEmUp
{
    
    public class EnemySpawner : MonoBehaviour
    {
        private static EnemySpawner _currentEnemySpawner = null;
        
        [SerializeField, Min(0.0f)] private float minimumTimeBetweenSpawns = 1.0f;
        [SerializeField, Min(0.0f)] private float maximumTimeBetweenSpawns = 1.0f;
        [SerializeField] private EnemySpawnTableEntry[] spawnTable = null;
        [SerializeField] private Vector2 spawnMinPoint = Vector2.zero;
        [SerializeField] private Vector2 spawnMaxPoint = Vector2.zero;

        private float spawnValueCap = 0.0f;

        private void Awake()
        {
            if (!_currentEnemySpawner)
            {
                _currentEnemySpawner = this;
            }
            else if (_currentEnemySpawner != this)
            {
                Destroy(gameObject);
                return;
            }
            
            Assert.IsFalse(maximumTimeBetweenSpawns < minimumTimeBetweenSpawns,
                "max time between spawns can't be lower than min time between spawns");
            Assert.IsTrue(spawnTable.Length > 0, "List of enemies points can't be empty");
            foreach (EnemySpawnTableEntry entry in spawnTable)
            {
                entry.Initialize();
                spawnValueCap += entry.GetSpawnValue();
            }
        }

        private void Start()
        {
            StartCoroutine(SpawnOverTime());
        }

        private IEnumerator SpawnOverTime()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(minimumTimeBetweenSpawns, maximumTimeBetweenSpawns));
                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            bool enemyToSpawnFound = false;
            float spawnValue = Random.Range(0.0f, spawnValueCap);
            float entrySpawnValue = 0.0f;
            EnemySpawnTableEntry entryToSpawn = null;

            foreach (EnemySpawnTableEntry entry in spawnTable)
            {
                entrySpawnValue = entry.GetSpawnValue();
                if (enemyToSpawnFound || entrySpawnValue <= 0.0f)
                {
                    spawnValueCap += entry.IncrementSpawnValue();
                    continue;
                }

                spawnValue -= entrySpawnValue;
                if (spawnValue <= 0.0f)
                {
                    enemyToSpawnFound = true;
                    entryToSpawn = entry;
                }
                else
                {
                    spawnValueCap += entry.IncrementSpawnValue();
                }
            }

            if (!enemyToSpawnFound)
            {
                spawnValueCap = 0.0f;
                entryToSpawn = spawnTable[0];
                foreach (EnemySpawnTableEntry entry in spawnTable)
                {
                    spawnValueCap += entry.GetSpawnValue();
                    if (entry.GetSpawnValue() > entryToSpawn.GetSpawnValue())
                    {
                        entryToSpawn = entry;
                    }
                }
            }
            
            SpawnEnemyByTableEntry(entryToSpawn);
        }

        private void SpawnEnemyByTableEntry(EnemySpawnTableEntry entry)
        {
            spawnValueCap -= entry.ResetSpawnValue();

            Vector3 positionToSpawnAt = new Vector3(Random.Range(spawnMinPoint.x, spawnMaxPoint.x),
                Random.Range(spawnMinPoint.y, spawnMaxPoint.y));
            
            ObjectPoolManager.GetPooledObject(entry.GetPrefab(), positionToSpawnAt, Quaternion.identity);
        }

        
        private void OnDrawGizmosSelected()
        {
            Color oldColor = Gizmos.color;

            if (spawnMinPoint.x < spawnMaxPoint.x && spawnMinPoint.y < spawnMaxPoint.y)
            {
                Gizmos.color = Color.green;
            }
            else
            {
                Gizmos.color = Color.magenta;
            }

            Vector2 spawnAreaSize = spawnMaxPoint - spawnMinPoint;
            Vector2 spawnCenter = spawnMinPoint + (0.5f * spawnAreaSize);
            
            Gizmos.DrawWireCube(spawnCenter, spawnAreaSize);
            
            Gizmos.color = oldColor;
        }
        
    }
}
