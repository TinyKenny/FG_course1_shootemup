using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class ObjectPoolManager : MonoBehaviour
    {
        private static ObjectPoolManager _currentObjectPoolManager = null;
        private static ObjectPoolManager CurrentOjbectPoolManager
        {
            get
            {
                if (!_currentObjectPoolManager)
                {
                    _currentObjectPoolManager = FindObjectOfType<ObjectPoolManager>();
                }
                return _currentObjectPoolManager;
            }
        }
        
        private Dictionary<GameObject, ObjectPool> objectPools;

        private void Awake()
        {
            if (!_currentObjectPoolManager)
            {
                _currentObjectPoolManager = this;
            }
            else if (_currentObjectPoolManager != this)
            {
                Destroy(gameObject);
                return;
            }
            
            objectPools = new Dictionary<GameObject, ObjectPool>();
        }

        public static GameObject GetPooledObject(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            if (!CurrentOjbectPoolManager.objectPools.ContainsKey(prefab))
            {
                CurrentOjbectPoolManager.objectPools[prefab] = new ObjectPool(prefab);
            }
            return CurrentOjbectPoolManager.objectPools[prefab].GetPooledObject(position, rotation);
        }
    }
}
