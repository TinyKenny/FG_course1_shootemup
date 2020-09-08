using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    [RequireComponent(typeof(DamageImmune))]
    public class Shield : MonoBehaviour, IAttackable
    {
        [SerializeField] private float shieldDuration = 1.0f;
        
        private void OnEnable()
        {
            StartCoroutine(DisableShield(shieldDuration));
        }

        private IEnumerator DisableShield(float delay)
        {
            yield return new WaitForSeconds(delay);
            gameObject.SetActive(false);
        }

        public float TakeDamage(float damage)
        {
            return damage * 2.0f;
        }
    }
}
