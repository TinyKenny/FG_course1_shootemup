using UnityEngine;

namespace ShootEmUp
{
    [RequireComponent(typeof(Missile))]
    public class HomingMissileController : MonoBehaviour
    {
        private Missile missile;
        private GameObject target;

        private void Awake()
        {
            missile = GetComponent<Missile>();
        }

        private void OnEnable()
        {
            target = MissileTargetManager.GetTarget(OnTargetRemovedFromManager);
            if (!target)
            {
                enabled = false;
            }
        }

        private void Update()
        {
            missile.targetDirection = target.transform.position - transform.position;
        }

        private void OnTargetRemovedFromManager(GameObject removedTarget)
        {
            if (target != removedTarget)
            {
                return;
            }

            enabled = false;
        }

        private void OnDisable()
        {
            missile.targetDirection = transform.up;
            MissileTargetManager.UnregisterTargetRemovalListener(OnTargetRemovedFromManager);
        }
    }
}
