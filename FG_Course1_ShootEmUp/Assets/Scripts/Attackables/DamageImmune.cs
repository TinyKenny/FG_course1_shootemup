using UnityEngine;
using UnityEngine.Events;

namespace ShootEmUp
{
    [RequireComponent(typeof(Collider2D))]
    public class DamageImmune : MonoBehaviour, IAttackable
    {
        public event UnityAction onDeath;
        
        public float TakeDamage(float damage)
        {
            return damage * 2.0f;
        }
    }
}
