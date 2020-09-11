using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public class EnemyProjectileAttack : EnemyAbility
    {
        [SerializeField] private GameObject projectile = null;

        protected override void UseAbility()
        {
            ObjectPoolManager.GetPooledObject(projectile, transform.position, transform.rotation);
        }
    }
}
