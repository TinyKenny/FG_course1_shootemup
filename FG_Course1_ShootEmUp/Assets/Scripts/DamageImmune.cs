using UnityEngine;

namespace ShootEmUp
{
    [RequireComponent(typeof(Collider2D))]
    public class DamageImmune : MonoBehaviour, IAttackable
    {
        public float TakeDamage(float damage)
        {
            return damage * 2.0f;
        }
    }
}
