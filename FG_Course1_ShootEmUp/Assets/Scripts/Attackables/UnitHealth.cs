using UnityEngine;

namespace ShootEmUp
{
    public class UnitHealth : MonoBehaviour, IAttackable
    {
        public float TakeDamage(float damage)
        {
            return damage;
        }
    }
}
