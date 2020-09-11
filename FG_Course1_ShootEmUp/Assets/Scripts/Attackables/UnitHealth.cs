using UnityEngine;
using UnityEngine.Events;

namespace ShootEmUp
{
    [RequireComponent(typeof(Collider2D))]
    public class UnitHealth : MonoBehaviour, IAttackable
    {
        [SerializeField] private HealthData data = null;

        private float currentHealth;
        public event UnityAction onDeath;

        private void OnEnable()
        {
            currentHealth = data.MaxHealth;
        }

        public float TakeDamage(float damage)
        {
            currentHealth -= damage;

            if (currentHealth <= 0.0f)
            {
                onDeath?.Invoke();
                return damage + currentHealth;
            }
            else
            {
                return damage;
            }
        }
    }
}
