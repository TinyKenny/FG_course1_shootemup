using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public class EnemyProjectileAttack : MonoBehaviour
    {
        [SerializeField] private GameObject projectile = null;

        public void PerformAttack()
        {
            ObjectPoolManager.GetPooledObject(projectile, transform.position, transform.rotation);
        }
    }
}
