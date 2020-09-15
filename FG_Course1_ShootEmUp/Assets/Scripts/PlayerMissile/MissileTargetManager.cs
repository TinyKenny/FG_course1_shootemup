using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class MissileTargetManager : MonoBehaviour
    {
        private static MissileTargetManager _currentMissileTargetManager = null;

        private static MissileTargetManager CurrentMissileTargetManager
        {
            get
            {
                if (!_currentMissileTargetManager)
                {
                    _currentMissileTargetManager = FindObjectOfType<MissileTargetManager>();
                }
                return _currentMissileTargetManager;
            }
        }

        private List<GameObject> targets;

        public delegate void OnTargetRemovedDelegate(GameObject target);
        public OnTargetRemovedDelegate onTargetRemoved;

        private void Awake()
        {
            if (!_currentMissileTargetManager)
            {
                _currentMissileTargetManager = this;
            }
            else if (_currentMissileTargetManager != this)
            {
                Destroy(this);
                return;
            }
            
            targets = new List<GameObject>();
        }

        public static void AddTarget(GameObject targetToAdd)
        {
            CurrentMissileTargetManager.targets.Add(targetToAdd);
        }

        public static void RemoveTarget(GameObject targetToRemove)
        {
            if (CurrentMissileTargetManager)
            {
                CurrentMissileTargetManager.targets.Remove(targetToRemove);
                CurrentMissileTargetManager.onTargetRemoved?.Invoke(targetToRemove);
            }
        }

        public static void UnregisterTargetRemovalListener(OnTargetRemovedDelegate listenerToRemove)
        {
            if (CurrentMissileTargetManager)
            {
                CurrentMissileTargetManager.onTargetRemoved -= listenerToRemove;
            }
        }

        public static GameObject GetTarget(OnTargetRemovedDelegate onTargetRemovedListener)
        {
            if (CurrentMissileTargetManager.targets.Count == 0)
            {
                return null;
            }

            CurrentMissileTargetManager.onTargetRemoved += onTargetRemovedListener;
            int targetIndex = Random.Range(0, CurrentMissileTargetManager.targets.Count);
            return CurrentMissileTargetManager.targets[targetIndex];
        }
    }
}
