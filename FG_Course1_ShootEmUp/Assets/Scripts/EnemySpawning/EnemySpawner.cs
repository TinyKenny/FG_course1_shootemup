﻿using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Assertions;

namespace ShootEmUp
{
    
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField, Min(0.0f)] private float minimumTimeBetweenSpawns = 1.0f;
        [SerializeField, Min(0.0f)] private float maximumTimeBetweenSpawns = 1.0f;
        [SerializeField] private List<Vector3> spawnPoints = null;
        [SerializeField] private EnemySpawnTableEntry[] spawnTable = null;

        private float spawnValueCap = 0.0f;
        private Vector3 previousSpawnPoint;

        private void Awake()
        {
            Assert.IsFalse(maximumTimeBetweenSpawns < minimumTimeBetweenSpawns,
                "max time between spawns can't be lower than min time between spawns");
            Assert.IsTrue(spawnPoints.Count > 0, "List of enemy spawn points can't be empty");
            Assert.IsTrue(spawnTable.Length > 0, "List of enemies points can't be empty");
            foreach (EnemySpawnTableEntry entry in spawnTable)
            {
                entry.Initialize();
                spawnValueCap += entry.GetSpawnValue();
            }

            previousSpawnPoint = spawnPoints[0];
            spawnPoints.RemoveAt(0);
            StartCoroutine(SpawnOverTime());
        }

        private void Update()
        {
            // TODO list (or similar) of active enemies
            if (Input.GetKeyDown(KeyCode.O))
            {
                SpawnEnemy();
            }
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
            Vector3 positionToSpawnAt = previousSpawnPoint;

            if (spawnPoints.Count > 0)
            {
                int spawnPointIndex = Random.Range(0, spawnPoints.Count);
                positionToSpawnAt = spawnPoints[spawnPointIndex];
                spawnPoints.RemoveAt(spawnPointIndex);
                spawnPoints.Add(previousSpawnPoint);
                previousSpawnPoint = positionToSpawnAt;
            }
            
            ObjectPoolManager.GetPooledObject(entry.GetPrefab(), positionToSpawnAt, Quaternion.identity);
        }
    }
}