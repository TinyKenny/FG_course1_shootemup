using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public class EnemyAttackController : MonoBehaviour
    {
        [SerializeField, Min(0.01f)] private float minimumCooldown = 1.0f;
        [SerializeField, Min(0.01f)] private float maximumCooldown = 1.0f;
        
        private EnemyProjectileAttack[] projectileAttacks;

        private void Awake()
        {
            projectileAttacks = GetComponentsInChildren<EnemyProjectileAttack>();
        }

        private void OnEnable()
        {
            /*
            foreach (EnemyAbility ability in abilities)
            {
                StartCoroutine(ability.UseAbilityRepeating(Random.Range(minimumCooldown, maximumCooldown)));
            }
            */
            StartCoroutine(UseAbilityRepeating());
        }

        private IEnumerator UseAbilityRepeating()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(maximumCooldown, maximumCooldown));
                foreach (EnemyProjectileAttack attack in projectileAttacks)
                {
                    attack.PerformAttack();
                }
            }
        }
    }
}
