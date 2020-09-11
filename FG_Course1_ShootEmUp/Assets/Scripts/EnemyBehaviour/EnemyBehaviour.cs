using UnityEngine;
using UnityEngine.Assertions;

namespace ShootEmUp
{
    [RequireComponent(typeof(Movement), typeof(IAttackable))]
    public abstract class EnemyBehaviour : MonoBehaviour
    {
        protected Movement movement;
        protected IAttackable attackable;

        protected virtual void Awake()
        {
            movement = GetComponent<Movement>();
            attackable = GetComponent<IAttackable>();
            Assert.IsNotNull(attackable, "Enemy must have an attackable component, for example Unit Health");

            attackable.onDeath += OnDeath;
        }

        private void OnDeath()
        {
            gameObject.SetActive(false);
        }
    }
}
