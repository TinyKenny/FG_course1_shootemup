using UnityEngine;

namespace ShootEmUp
{
    [System.Serializable]
    public class EnemySpawnTableEntry
    {
        [SerializeField] private GameObject prefab = null;
        [SerializeField] private float spawnValue = 1.0f;
        [SerializeField] private float spawnValueIncrementSize = 1.0f;

        public float currentSpawnValue = 0.0f;

        public void Initialize()
        {
            currentSpawnValue = spawnValue;
        }

        public float GetSpawnValue()
        {
            return currentSpawnValue;
        }

        public float IncrementSpawnValue()
        {
            currentSpawnValue += spawnValueIncrementSize;
            return spawnValueIncrementSize;
        }

        public float ResetSpawnValue()
        {
            float spawnValueChange = currentSpawnValue - spawnValue;
            currentSpawnValue = spawnValue;
            return spawnValueChange;
        }

        public GameObject GetPrefab()
        {
            return prefab;
        }
    }
}
