using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class ObjectPooler : MonoBehaviour
    {
        #region Poolable component
        // This class is automatically added to objects that are instantiated by the ObjectPooler
        // It's an inner class to prevent it from appearing in the "Add Component" menu in the unity editor
        public class Poolable : MonoBehaviour
        {
            public delegate void OnDisableDelegate(GameObject caller, GameObject callerPrefab);
            private OnDisableDelegate onDisableCallback;
        
            private GameObject sourcePrefab;

            public void SetUpPoolable(OnDisableDelegate callback, GameObject prefab)
            {
                sourcePrefab = prefab;
                onDisableCallback = callback;
            }
        
            private void OnDisable()
            {
                onDisableCallback?.Invoke(gameObject, sourcePrefab);
            }
        }
        #endregion // Poolable component
        
        private static ObjectPooler _currentObjectPooler = null;
        private static ObjectPooler currentOjbectPooler
        {
            get
            {
                if (!_currentObjectPooler)
                {
                    _currentObjectPooler = FindObjectOfType<ObjectPooler>();
                }
                return _currentObjectPooler;
            }
        }
        
        // TODO implementera egen stack-typ som är o(1) för både push och pop
        private Dictionary<GameObject, Stack<GameObject>> objectPools;

        private void Awake()
        {
            if (!_currentObjectPooler)
            {
                _currentObjectPooler = this;
            }
            else if (_currentObjectPooler != this)
            {
                Destroy(gameObject);
            }
            
            objectPools = new Dictionary<GameObject, Stack<GameObject>>();
        }

        public static GameObject GetPooledObject(GameObject prefab)
        {
            return GetPooledObject(prefab, prefab.transform.position, prefab.transform.rotation);
        }

        public static GameObject GetPooledObject(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            GameObject pooledObject = null;
            if (!currentOjbectPooler.objectPools.ContainsKey(prefab))
            {
                currentOjbectPooler.objectPools[prefab] = new Stack<GameObject>();
            }

            if (currentOjbectPooler.objectPools[prefab].Count == 0)
            {
                pooledObject = Instantiate(prefab, position, rotation);
                Poolable poolableComponent = pooledObject.AddComponent<Poolable>();
                poolableComponent.SetUpPoolable(currentOjbectPooler.AddObjectToPool, prefab);
            }
            else
            {
                pooledObject = currentOjbectPooler.objectPools[prefab].Pop();
                pooledObject.transform.SetPositionAndRotation(position, rotation);
                pooledObject.SetActive(true);
            }

            return pooledObject;
        }

        private void AddObjectToPool(GameObject objectToAdd, GameObject sourcePrefab)
        {
            objectPools[sourcePrefab].Push(objectToAdd);
        }
    }
}
