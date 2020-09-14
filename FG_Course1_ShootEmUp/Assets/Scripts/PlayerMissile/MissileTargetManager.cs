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
        
        // TODO Dictionary, have (not yet created) enum faction as keys and list of targets as values
        // TODO attackables should have factions
        // TODO attackables register themselves as targets in the missile manager, providing their factions
        // TODO attackables unregister themselves as targets when disabled
        // TODO homing missiles can request targets based on faction
        // TODO homing missiles receive a callback if their target is unregistered

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

        public static GameObject GetTarget()
        {
            return null;
        }
    }
}
