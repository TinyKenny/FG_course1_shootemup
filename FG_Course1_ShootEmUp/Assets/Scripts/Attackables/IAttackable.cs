using UnityEngine.Events;

namespace ShootEmUp
{
    public interface IAttackable
    {
        event UnityAction onDeath;
        float TakeDamage(float damage);
    }
}