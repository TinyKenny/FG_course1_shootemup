using UnityEngine;

namespace ShootEmUp
{
    // ObjectPool effectively a linked-list stack specifically for objectpooling gameObjects
    public class ObjectPool
    {
        #region Poolable component
        // This class is automatically added to objects that are instantiated by the ObjectPool
        // It's an inner class to prevent it from appearing in the "Add Component" menu in the unity editor
        public class Poolable : MonoBehaviour
        {
            public Poolable nextPoolable;
            
            public delegate void OnDisableDelegate(Poolable caller);
            private OnDisableDelegate onDisableCallback;

            public void SetUpPoolable(OnDisableDelegate callback)
            {
                onDisableCallback = callback;
            }
        
            private void OnDisable()
            {
                onDisableCallback?.Invoke(this);
            }
        }
        #endregion // Poolable component

        private int count = 0;
        private bool hasNext = false;
        private Poolable nextPoolable = null;
        private GameObject sourcePrefab = null;

        public ObjectPool(GameObject prefab)
        {
            sourcePrefab = prefab;
        }

        public GameObject GetPooledObject(Vector3 position, Quaternion rotation)
        {
            GameObject toReturn = null;

            if (hasNext)
            {
                toReturn = nextPoolable.gameObject;
                toReturn.transform.SetPositionAndRotation(position, rotation);

                nextPoolable = nextPoolable.nextPoolable;
                count--;
                hasNext = count > 0;
                
                toReturn.SetActive(true);
            }
            else
            {
                toReturn = GameObject.Instantiate(sourcePrefab, position, rotation);
                Poolable poolableComponent = toReturn.AddComponent<Poolable>();
                poolableComponent.SetUpPoolable(AddObjectToPool);
            }
            
            return toReturn;
        }

        private void AddObjectToPool(Poolable objectToAdd)
        {
            objectToAdd.nextPoolable = nextPoolable;
            nextPoolable = objectToAdd;
            count++;
            hasNext = true;
        }

    }
}
